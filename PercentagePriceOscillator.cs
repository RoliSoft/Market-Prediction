namespace MarketPrediction
{
    using System;

    /// <summary>
    /// Implements a percentage price oscillation calculator, using
    /// exponential moving averaging.
    /// Reference: http://stockcharts.com/school/doku.php?id=chart_school:technical_indicators:price_oscillators_ppo
    /// </summary>
    class PercentagePriceOscillator : ISeriesTransform
    {
        /// <summary>
        /// Fast-moving (12-day exponential by default) average of the indices.
        /// </summary>
        private ExponentialMovingAverage fastAverage;

        /// <summary>
        /// Slow-moving (26-day exponential by default) average of the indices.
        /// </summary>
        private ExponentialMovingAverage slowAverage;

        /// <summary>
        /// Signal line (9-day exponential by default) of the moving average convergence divergence.
        /// </summary>
        private ExponentialMovingAverage signAverage;

        /// <summary>
        /// Initializes a new instance of the <see cref="PercentagePriceOscillator" /> class.
        /// </summary>
        /// <param name="fast">The fast-moving average of the indices.</param>
        /// <param name="slow">The slow-moving average of the indices.</param>
        /// <param name="sign">The signal line of the moving average convergence divergence.</param>
        public PercentagePriceOscillator(int fast = 12, int slow = 26, int sign = 9)
        {
            fastAverage = new ExponentialMovingAverage(fast);
            slowAverage = new ExponentialMovingAverage(slow);
            signAverage = new ExponentialMovingAverage(sign);
        }

        /// <summary>
        /// Gets the short name of the transformer.
        /// </summary>
        /// <returns>Short name of the transformer.</returns>
        public string GetShortName()
        {
            return "PPO";
        }

        /// <summary>
        /// Gets the long name of the transformer.
        /// </summary>
        /// <returns>Long name of the transformer.</returns>
        public string GetLongName()
        {
            return "Percentage Price Oscillator";
        }

        /// <summary>
        /// Adds an index to the moving average.
        /// </summary>
        /// <param name="value">The index value.</param>
        public void AddIndex(decimal value)
        {
            slowAverage.AddIndex(value);
            fastAverage.AddIndex(value);

            if (slowAverage.IsReady() && fastAverage.IsReady())
            {
                signAverage.AddIndex((fastAverage.GetValue() - slowAverage.GetValue()) / slowAverage.GetValue());
            }
        }

        /// <summary>
        /// Determines whether this instance is ready.
        /// </summary>
        /// <returns><c>true</c> if this instance is ready; otherwise, <c>false</c>.</returns>
        public bool IsReady()
        {
            return slowAverage.IsReady() && fastAverage.IsReady() && signAverage.IsReady();
        }

        /// <summary>
        /// Gets the moving average convergence divergence value for the current day.
        /// </summary>
        /// <returns>Moving average convergence divergence value for the current day.</returns>
        public decimal GetValue()
        {
            var value  = (fastAverage.GetValue() - slowAverage.GetValue()) / slowAverage.GetValue();
            var signal = signAverage.GetValue();
            var histogram = value - signal;

            return value;
        }
    }
}
