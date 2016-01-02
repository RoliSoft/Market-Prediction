namespace MarketPrediction.Algorithms
{
    using System;
    using System.Linq;
    using System.Threading;

    using AForge;
    using AForge.Neuro;
    using AForge.Neuro.Learning;

    /// <summary>
    /// Encapsulates methods related to working with neural networks.
    /// </summary>
    public static class NeuralNetwork
    {
        /// <summary>
        /// Trains and evaluates a neural network with the specified parameters.
        /// </summary>
        /// <param name="data">The data to be used for training.</param>
        /// <param name="solution">The reference to where the solution will be stored.</param>
        /// <param name="error">The reference where error rate will be stored.</param>
        /// <param name="predictions">The reference to where the predictions will be stored.</param>
        /// <param name="iterations">The number of iterations to perform.</param>
        /// <param name="inputCount">The number of inputs on the neural network.</param>
        /// <param name="hiddenCount">The number of hidden layers on the neural network.</param>
        /// <param name="learningRate">The learning rate parameter of the back propagation learning algorithm.</param>
        /// <param name="momentum">The momentum parameter of the back propagation learning algorithm</param>
        /// <param name="sigmoidAlpha">The sigmoid alpha parameter of the activation function.</param>
        /// <param name="cancelToken">The cancellation token for the async operation.</param>
        /// <param name="progressCallback">The progress callback: current iteration.</param>
        /// <returns>
        ///   <c>true</c> if the training and evaluation was successful, <c>false</c> otherwise.</returns>
        /// <exception cref="ArgumentException">Array should be size of data minus number of inputs.</exception>
        public static bool TrainAndEval(double[] data, ref double[] solution, ref double error, ref double[] predictions, int iterations, int inputCount, int hiddenCount, double learningRate, double momentum, double sigmoidAlpha, CancellationToken cancelToken, Action<int> progressCallback = null)
        {
            var min     = data.Min();
            var samples = data.Length - inputCount;
            var input   = new double[samples][];
            var output  = new double[samples][];

            for (int i = 0; i < samples; i++)
            {
                input[i]  = new double[inputCount];
                output[i] = new double[1];

                for (var j = 0; j < inputCount; j++)
                {
                    input[i][j] = data[i + j] - min;
                }

                output[i][0] = data[i + inputCount] - min;
            }

            cancelToken.ThrowIfCancellationRequested();

            Neuron.RandRange = new Range(0.3f, 0.3f);

            var nn = new ActivationNetwork(new BipolarSigmoidFunction(sigmoidAlpha), inputCount, hiddenCount, 1);
            var bp = new BackPropagationLearning(nn)
                {
                    LearningRate = learningRate,
                    Momentum     = momentum
                };

            if (solution.Length != data.Length - inputCount)
            {
                throw new ArgumentException("Array should be the size of data minus number of inputs.", nameof(solution));
            }

            for (int i = 0; i < iterations; i++)
            {
                bp.RunEpoch(input, output);

                progressCallback?.Invoke(i);

                cancelToken.ThrowIfCancellationRequested();
            }

            var test = new double[inputCount];
               error = 0.0;

            for (int i = 0, n = data.Length - inputCount; i < n; i++)
            {
                for (int j = 0; j < inputCount; j++)
                {
                    test[j] = data[i + j] - min;
                }

                solution[i] = nn.Compute(test)[0] + min;

                error += Math.Abs((solution[i] - data[inputCount + i]) / data[inputCount + i]);

                cancelToken.ThrowIfCancellationRequested();
            }

            error = error / (data.Length - inputCount) * 100;

            if (predictions.Length != 0)
            {
                Array.Copy(solution, solution.Length - inputCount, predictions, 0, inputCount);

                for (var i = inputCount; i < predictions.Length; i++)
                {
                    for (int j = 0; j < inputCount; j++)
                    {
                        test[j] = predictions[(i - inputCount) + j] - min;
                    }

                    predictions[i] = nn.Compute(test)[0] + min;

                    cancelToken.ThrowIfCancellationRequested();
                }
            }

            return true;
        }
    }
}
