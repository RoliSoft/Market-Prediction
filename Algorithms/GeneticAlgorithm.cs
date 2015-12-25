namespace MarketPrediction.Algorithms
{
    using System;
    using System.Threading;

    using AForge;
    using AForge.Genetic;

    /// <summary>
    /// Encapsulates methods related to working with genetic algorithms.
    /// </summary>
    public static class GeneticAlgorithm
    {
        /// <summary>
        /// Supported gene functions.
        /// </summary>
        public enum GeneFunctions : int
        {
            /// <summary>
            /// Simple arithmetic functions: +, -, *, /
            /// </summary>
            Simple = 0,

            /// <summary>
            /// Simple and extended arithmetic functions: sin, cos, ln, exp, sqrt
            /// </summary>
            Extended = 1
        }

        /// <summary>
        /// Supported chromosomes.
        /// </summary>
        public enum Chromosomes : int
        {
            /// <summary>
            /// Genetic Tree
            /// </summary>
            GPT = 0,

            /// <summary>
            /// Gene Expression Programming
            /// </summary>
            GEP = 1
        }

        /// <summary>
        /// Supported gene selections.
        /// </summary>
        public enum Selections : int
        {
            /// <summary>
            /// Selects the specified amount of best chromosomes to the next generation.
            /// </summary>
            Elite = 0,

            /// <summary>
            /// Selects chromosomes to the new generation depending on their fitness values.
            /// </summary>
            Rank = 1,

            /// <summary>
            /// Similar to rank, but randomized with fitter chromosomes getting a higher chance.
            /// </summary>
            Roulette = 2
        }

        /// <summary>
        /// Trains and evaluates a genetic algorithm with the specified parameters.
        /// </summary>
        /// <param name="data">The data to be used for training.</param>
        /// <param name="solution">The reference to where the solution will be stored.</param>
        /// <param name="bestChromosome">The best chromosome.</param>
        /// <param name="error">The reference where error rate will be stored.</param>
        /// <param name="predictions">The reference to where the predictions will be stored.</param>
        /// <param name="iterations">The number of iterations to perform.</param>
        /// <param name="population">The size of the population.</param>
        /// <param name="inputCount">The number of inputs.</param>
        /// <param name="shuffle">Value indicating whether to shuffle the chromosomes on each epoch.</param>
        /// <param name="constants">The constant inputs.</param>
        /// <param name="geneType">Type of the gene functions.</param>
        /// <param name="chromosomeType">Type of the chromosome.</param>
        /// <param name="selectionType">Type of the chromosome selection.</param>
        /// <param name="cancelToken">The cancellation token for the async operation.</param>
        /// <param name="progressCallback">The progress callback: current iteration.</param>
        /// <returns>
        ///   <c>true</c> if the training and evaluation was successful, <c>false</c> otherwise.</returns>
        /// <exception cref="ArgumentException">Array should be size of data minus number of inputs.</exception>
        public static bool TrainAndEval(double[] data, ref double[] solution, ref string bestChromosome, ref double error, ref double[] predictions, int iterations, int population, int inputCount, bool shuffle, double[] constants, GeneFunctions geneType, Chromosomes chromosomeType, Selections selectionType, CancellationToken cancelToken, Action<int> progressCallback = null)
        {
            IGPGene gene;

            switch (geneType)
            {
                case GeneFunctions.Simple:
                    gene = new SimpleGeneFunction(inputCount + constants.Length);
                    break;

                case GeneFunctions.Extended:
                    gene = new ExtendedGeneFunction(inputCount + constants.Length);
                    break;

                default: return false;
            }

            IChromosome chromosome;

            switch (chromosomeType)
            {
                case Chromosomes.GPT:
                    chromosome = new GPTreeChromosome(gene);
                    break;

                case Chromosomes.GEP:
                    chromosome = new GEPChromosome(gene, 20);
                    break;

                default: return false;
            }

            ISelectionMethod selection;

            switch (selectionType)
            {
                case Selections.Elite:
                    selection = new EliteSelection();
                    break;

                case Selections.Rank:
                    selection = new RankSelection();
                    break;

                case Selections.Roulette:
                    selection = new RouletteWheelSelection();
                    break;

                default: return false;
            }

            cancelToken.ThrowIfCancellationRequested();

            var ga = new Population(
                population,
                chromosome,
                new TimeSeriesPredictionFitness(data, inputCount, 0, constants),
                selection
                )
            {
                AutoShuffling = shuffle
            };
            
            if (solution.Length != data.Length - inputCount)
            {
                throw new ArgumentException("Array should be the size of data minus number of inputs.", nameof(solution));
            }

            var input = new double[inputCount + constants.Length];

            for (var j = 0; j < data.Length - inputCount; j++)
            {
                solution[j] = j + inputCount;
            }

            Array.Copy(constants, 0, input, inputCount, constants.Length);

            for (var i = 0; i < iterations; i++)
            {
                ga.RunEpoch();

                progressCallback?.Invoke(i);

                cancelToken.ThrowIfCancellationRequested();
            }

                     error = 0.0;
            bestChromosome = ga.BestChromosome.ToString();

            for (int j = 0, n = data.Length - inputCount; j < n; j++)
            {
                for (int k = 0, b = j + inputCount - 1; k < inputCount; k++)
                {
                    input[k] = data[b - k];
                }

                solution[j] = PolishExpression.Evaluate(bestChromosome, input);

                error += Math.Abs(solution[j] - data[inputCount + j]);

                cancelToken.ThrowIfCancellationRequested();
            }

            if (predictions.Length != 0)
            {
                Array.Copy(solution, solution.Length - inputCount, predictions, 0, inputCount);

                for (var i = inputCount; i < predictions.Length; i++)
                {
                    for (int j = 0; j < inputCount; j++)
                    {
                        input[j] = predictions[(i - inputCount) + j];
                    }
                    
                    predictions[i] = PolishExpression.Evaluate(bestChromosome, input);

                    cancelToken.ThrowIfCancellationRequested();
                }
            }
            
            return true;
        }
    }
}
