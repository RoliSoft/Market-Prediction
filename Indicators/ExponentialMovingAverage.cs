namespace MarketPrediction.Indicators
{
    /// <summary>
    /// Implements an exponential moving average calculator.
    /// Reference: http://www.investopedia.com/articles/trading/10/simple-exponential-moving-averages-compare.asp
    /// </summary>
    public class ExponentialMovingAverage : ISeriesTransform
    {
        /// <summary>
        /// The period for which the moving average is being computed. (N)
        /// </summary>
        private readonly int _period;

        /// <summary>
        /// The smoothening factor: α = (2 / 1 + N)
        /// </summary>
        private readonly decimal _smooth;

        /// <summary>
        /// The number of indices added at this point up to the maximum period.
        /// </summary>
        private int _iteration;

        /// <summary>
        /// The value of the moving average for the current day.
        /// </summary>
        private decimal _average;

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
            _period = period;
            _smooth = 2m / (1 + period);
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
            if (_iteration < _period)
            {
                _average += value;
            }

            if (_iteration == _period)
            {
                _average /= _period;
            }

            if (_iteration > _period)
            {
                _average = (_smooth * (value - _average)) + _average;
            }

            if (_iteration <= _period + 1)
            {
                _iteration++;
            }
        }

        /// <summary>
        /// Determines whether this instance is ready.
        /// </summary>
        /// <returns><c>true</c> if this instance is ready; otherwise, <c>false</c>.</returns>
        public bool IsReady()
        {
            return _iteration > _period;
        }

        /// <summary>
        /// Gets the moving average for the current day.
        /// </summary>
        /// <returns>Moving average for the current day.</returns>
        public decimal GetValue()
        {
            return _average;
        }
    }
}
