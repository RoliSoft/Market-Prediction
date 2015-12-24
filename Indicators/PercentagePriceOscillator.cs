namespace MarketPrediction.Indicators
{
    /// <summary>
    /// Implements a percentage price oscillation calculator, using
    /// exponential moving averaging.
    /// Reference: http://stockcharts.com/school/doku.php?id=chart_school:technical_indicators:price_oscillators_ppo
    /// </summary>
    public class PercentagePriceOscillator : ISeriesTransform
    {
        /// <summary>
        /// Fast-moving (12-day exponential by default) average of the indices.
        /// </summary>
        private readonly ExponentialMovingAverage _fastAverage;

        /// <summary>
        /// Slow-moving (26-day exponential by default) average of the indices.
        /// </summary>
        private readonly ExponentialMovingAverage _slowAverage;

        /// <summary>
        /// Signal line (9-day exponential by default) of the moving average convergence divergence.
        /// </summary>
        private readonly ExponentialMovingAverage _signAverage;

        /// <summary>
        /// Initializes a new instance of the <see cref="PercentagePriceOscillator"/> class.
        /// </summary>
        public PercentagePriceOscillator() : this(12, 26, 9)
        {
            
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PercentagePriceOscillator" /> class.
        /// </summary>
        /// <param name="fast">The fast-moving average of the indices.</param>
        /// <param name="slow">The slow-moving average of the indices.</param>
        /// <param name="sign">The signal line of the moving average convergence divergence.</param>
        public PercentagePriceOscillator(int fast, int slow, int sign)
        {
            _fastAverage = new ExponentialMovingAverage(fast);
            _slowAverage = new ExponentialMovingAverage(slow);
            _signAverage = new ExponentialMovingAverage(sign);
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
            _slowAverage.AddIndex(value);
            _fastAverage.AddIndex(value);

            if (_slowAverage.IsReady() && _fastAverage.IsReady())
            {
                _signAverage.AddIndex((_fastAverage.GetValue() - _slowAverage.GetValue()) / _slowAverage.GetValue());
            }
        }

        /// <summary>
        /// Determines whether this instance is ready.
        /// </summary>
        /// <returns><c>true</c> if this instance is ready; otherwise, <c>false</c>.</returns>
        public bool IsReady()
        {
            return _slowAverage.IsReady() && _fastAverage.IsReady() && _signAverage.IsReady();
        }

        /// <summary>
        /// Gets the moving average convergence divergence value for the current day.
        /// </summary>
        /// <returns>Moving average convergence divergence value for the current day.</returns>
        public decimal GetValue()
        {
            var value  = (_fastAverage.GetValue() - _slowAverage.GetValue()) / _slowAverage.GetValue();
            var signal = _signAverage.GetValue();
            var histogram = value - signal;

            return value;
        }
    }
}
