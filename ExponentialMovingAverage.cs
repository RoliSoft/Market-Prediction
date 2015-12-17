namespace MarketPrediction
{
    using System;

    /// <summary>
    /// Implements an exponential moving average calculator.
    /// Reference: http://www.investopedia.com/articles/trading/10/simple-exponential-moving-averages-compare.asp
    /// </summary>
    class ExponentialMovingAverage : ISeriesTransform
    {
        /// <summary>
        /// The period for which the moving average is being computed. (N)
        /// </summary>
        private readonly int period;

        /// <summary>
        /// The smoothening factor: α = (2 / 1 + N)
        /// </summary>
        private readonly decimal smooth;

        /// <summary>
        /// The number of indices added at this point up to the maximum period.
        /// </summary>
        private int iteration;

        /// <summary>
        /// The value of the moving average for the current day.
        /// </summary>
        private decimal average;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExponentialMovingAverage"/> class.
        /// </summary>
        public ExponentialMovingAverage() : this(30)
        {
            
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ExponentialMovingAverage"/> class.
        /// </summary>
        /// <param name="period">The period.</param>
        public ExponentialMovingAverage(int period)
        {
            this.period = period;
            this.smooth = 2m / (1 + this.period);
        }

        /// <summary>
        /// Gets the short name of the transformer.
        /// </summary>
        /// <returns>Short name of the transformer.</returns>
        public string GetShortName()
        {
            return "EMA";
        }

        /// <summary>
        /// Gets the long name of the transformer.
        /// </summary>
        /// <returns>Long name of the transformer.</returns>
        public string GetLongName()
        {
            return "Exponential Moving Average";
        }

        /// <summary>
        /// Adds an index to the moving average.
        /// </summary>
        /// <param name="value">The index value.</param>
        public void AddIndex(decimal value)
        {
            if (iteration < period)
            {
                average += value;
            }

            if (iteration == period)
            {
                average /= period;
            }

            if (iteration > period)
            {
                average = (smooth * (value - average)) + average;
            }

            if (iteration <= period + 1)
            {
                iteration++;
            }
        }

        /// <summary>
        /// Determines whether this instance is ready.
        /// </summary>
        /// <returns><c>true</c> if this instance is ready; otherwise, <c>false</c>.</returns>
        public bool IsReady()
        {
            return iteration > period;
        }

        /// <summary>
        /// Gets the moving average for the current day.
        /// </summary>
        /// <returns>Moving average for the current day.</returns>
        public decimal GetValue()
        {
            return average;
        }
    }
}
