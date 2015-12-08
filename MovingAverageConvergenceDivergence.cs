namespace MarketPrediction
{
    using System;

    /// <summary>
    /// Implements a moving average convergence divergence calculator, using
    /// exponential moving averaging.
    /// Reference: http://stockcharts.com/school/doku.php?id=chart_school:technical_indicators:moving_average_convergence_divergence_macd
    /// Interpretation: https://www.incrediblecharts.com/indicators/macd.php
    /// </summary>
    class MovingAverageConvergenceDivergence
    {
        /// <summary>
        /// Fast-moving (12-day exponential) average of the indices.
        /// </summary>
        private ExponentialMovingAverage fastAverage;

        /// <summary>
        /// Slow-moving (26-day exponential) average of the indices.
        /// </summary>
        private ExponentialMovingAverage slowAverage;

        /// <summary>
        /// Signal line (9-day exponential) of the moving average convergence divergence.
        /// </summary>
        private ExponentialMovingAverage signAverage;

        /// <summary>
        /// Initializes a new instance of the <see cref="MovingAverageConvergenceDivergence"/> class.
        /// </summary>
        public MovingAverageConvergenceDivergence()
        {
            fastAverage = new ExponentialMovingAverage(12);
            slowAverage = new ExponentialMovingAverage(26);
            signAverage = new ExponentialMovingAverage(9);
        }
        
        /// <summary>
        /// Adds an index to the moving average.
        /// </summary>
        /// <param name="value">The index value.</param>
        public void AddIndex(decimal value)
        {
            slowAverage.AddIndex(value);
            fastAverage.AddIndex(value);

            // TODO only when ready
            signAverage.AddIndex(fastAverage.GetValue() - slowAverage.GetValue());
        }

        /// <summary>
        /// Gets the moving average convergence divergence value for the current day.
        /// </summary>
        /// <returns>Moving average convergence divergence value for the current day.</returns>
        public decimal GetValue()
        {
            var value  = fastAverage.GetValue() - slowAverage.GetValue();
            var signal = signAverage.GetValue();
            var histogram = value - signal;

            return value;
        }
    }
}
