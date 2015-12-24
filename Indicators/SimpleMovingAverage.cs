namespace MarketPrediction.Indicators
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Implements a simple moving average calculator.
    /// Reference: http://www.investopedia.com/articles/trading/10/simple-exponential-moving-averages-compare.asp
    /// </summary>
    public class SimpleMovingAverage : ISeriesTransform
    {
        /// <summary>
        /// The period for which the moving average is being computed.
        /// </summary>
        private readonly int _period;
        
        /// <summary>
        /// The values for the specified period.
        /// </summary>
        private readonly Queue<decimal> _values;

        /// <summary>
        /// Initializes a new instance of the <see cref="SimpleMovingAverage"/> class.
        /// </summary>
        public SimpleMovingAverage() : this(30)
        {
            
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SimpleMovingAverage"/> class.
        /// </summary>
        /// <param name="period">The _period.</param>
        public SimpleMovingAverage(int period)
        {
            _period = period;
            _values = new Queue<decimal>();
        }

        /// <summary>
        /// Gets the short name of the transformer.
        /// </summary>
        /// <returns>Short name of the transformer.</returns>
        public string GetShortName()
        {
            return "SMA";
        }

        /// <summary>
        /// Gets the long name of the transformer.
        /// </summary>
        /// <returns>Long name of the transformer.</returns>
        public string GetLongName()
        {
            return "Simple Moving Average";
        }

        /// <summary>
        /// Adds an index to the moving average.
        /// </summary>
        /// <param name="value">The index value.</param>
        public void AddIndex(decimal value)
        {
            if (_values.Count >= _period)
            {
                _values.Dequeue();
            }

            _values.Enqueue(value);
        }

        /// <summary>
        /// Determines whether this instance is ready.
        /// </summary>
        /// <returns><c>true</c> if this instance is ready; otherwise, <c>false</c>.</returns>
        public bool IsReady()
        {
            return _values.Count >= _period;
        }

        /// <summary>
        /// Gets the moving average for the current day.
        /// </summary>
        /// <returns>Moving average for the current day.</returns>
        public decimal GetValue()
        {
            return _values.Sum() / _values.Count;
        }
    }
}
