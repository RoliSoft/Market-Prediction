namespace MarketPrediction.Indicators
{
    /// <summary>
    /// Implements a relative strength index calculator.
    /// Reference: http://www.investopedia.com/articles/technical/03/070203.asp
    /// </summary>
    public class RelativeStrengthIndex : ISeriesTransform
    {
        /// <summary>
        /// The value of the strength index for the current day.
        /// </summary>
        private decimal _strength;

        /// <summary>
        /// The value of the previous index.
        /// </summary>
        private decimal _previous = decimal.MinValue;

        /// <summary>
        /// The moving average of the indices on days with gains.
        /// </summary>
        private readonly ExponentialMovingAverage _gainAverage;

        /// <summary>
        /// The moving average of the indices on days with losses.
        /// </summary>
        private readonly ExponentialMovingAverage _lossAverage;

        /// <summary>
        /// Initializes a new instance of the <see cref="RelativeStrengthIndex"/> class.
        /// </summary>
        public RelativeStrengthIndex() : this(30)
        {
            
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RelativeStrengthIndex" /> class.
        /// </summary>
        /// <param name="period">The period.</param>
        public RelativeStrengthIndex(int period)
        {
            _gainAverage = new ExponentialMovingAverage(period);
            _lossAverage = new ExponentialMovingAverage(period);
        }

        /// <summary>
        /// Gets the short name of the transformer.
        /// </summary>
        /// <returns>Short name of the transformer.</returns>
        public string GetShortName()
        {
            return "RSI";
        }

        /// <summary>
        /// Gets the long name of the transformer.
        /// </summary>
        /// <returns>Long name of the transformer.</returns>
        public string GetLongName()
        {
            return "Relative Strength Index";
        }

        /// <summary>
        /// Adds an index to the moving average.
        /// </summary>
        /// <param name="value">The index value.</param>
        public void AddIndex(decimal value)
        {
            if (_previous != decimal.MinValue)
            {
                if (value >= _previous)
                {
                    _gainAverage.AddIndex(value - _previous);
                    _lossAverage.AddIndex(0);
                }
                else
                {
                    _gainAverage.AddIndex(0);
                    _lossAverage.AddIndex(_previous - value);
                }
            }

            _previous = value;

            if (_lossAverage.GetValue() == 0)
            {
                _strength = 100;
                return;
            }

            var relativeStrength = _gainAverage.GetValue() / _lossAverage.GetValue();
            _strength = 100 - (100 / (1 + relativeStrength));
        }

        /// <summary>
        /// Determines whether this instance is ready.
        /// </summary>
        /// <returns><c>true</c> if this instance is ready; otherwise, <c>false</c>.</returns>
        public bool IsReady()
        {
            return _gainAverage.IsReady() && _lossAverage.IsReady();
        }

        /// <summary>
        /// Gets the strength index for the current day.
        /// </summary>
        /// <returns>Strength index for the current day.</returns>
        public decimal GetValue()
        {
            return _strength;
        }
    }
}
