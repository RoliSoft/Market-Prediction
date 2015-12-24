namespace MarketPrediction.Indicators
{
    using System.Collections.Generic;

    /// <summary>
    /// Implements detrended price oscillation calculator, in order to remove
    /// trends from a time series data, which can be further used to identify
    /// independent high/low cycles.
    /// Reference: http://stockcharts.com/school/doku.php?id=chart_school:technical_indicators:detrended_price_osci
    /// </summary>
    public class DetrendedPriceOscillation : ISeriesTransform
    {
        /// <summary>
        /// The period for which the price oscillation is being computed.
        /// </summary>
        private readonly int _period;

        /// <summary>
        /// The period with which the moving average is being displaced.
        /// </summary>
        private readonly int _shift;

        /// <summary>
        /// The current index value.
        /// </summary>
        private decimal _current;

        /// <summary>
        /// The EMA values for the previous days, for shifting.
        /// </summary>
        private readonly Queue<decimal> _previous;

        /// <summary>
        /// The moving average of the indices on tracked period.
        /// </summary>
        private readonly SimpleMovingAverage _periodAverage;

        /// <summary>
        /// Initializes a new instance of the <see cref="DetrendedPriceOscillation"/> class.
        /// </summary>
        public DetrendedPriceOscillation() : this(20)
        {
            
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DetrendedPriceOscillation"/> class.
        /// </summary>
        /// <param name="period">The period.</param>
        public DetrendedPriceOscillation(int period)
        {
            _period = period;
            _shift  = period / 2 + 1;
            _periodAverage = new SimpleMovingAverage(period);
            _previous      = new Queue<decimal>(_shift);
        }
        
        /// <summary>
        /// Gets the short name of the transformer.
        /// </summary>
        /// <returns>Short name of the transformer.</returns>
        public string GetShortName()
        {
            return "DPO";
        }

        /// <summary>
        /// Gets the long name of the transformer.
        /// </summary>
        /// <returns>Long name of the transformer.</returns>
        public string GetLongName()
        {
            return "Detrended Price Oscillation";
        }

        /// <summary>
        /// Adds an index to the moving average.
        /// </summary>
        /// <param name="value">The index value.</param>
        public void AddIndex(decimal value)
        {
            _current = value;

            if (!_periodAverage.IsReady())
            {
                _periodAverage.AddIndex(value);
            }
            else if (_previous.Count >= _shift)
            {
                _periodAverage.AddIndex(_previous.Dequeue());
            }

            _previous.Enqueue(value);
        }

        /// <summary>
        /// Determines whether this instance is ready.
        /// </summary>
        /// <returns><c>true</c> if this instance is ready; otherwise, <c>false</c>.</returns>
        public bool IsReady()
        {
            return _periodAverage.IsReady() && _previous.Count >= _shift;
        }

        /// <summary>
        /// Gets the moving average convergence divergence value for the current day.
        /// </summary>
        /// <returns>Moving average convergence divergence value for the current day.</returns>
        public decimal GetValue()
        {
            return _current - _periodAverage.GetValue();
        }
    }
}
