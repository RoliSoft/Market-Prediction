namespace MarketPrediction
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    /// <summary>
    /// Implements detrended price oscillation calculator, in order to remove
    /// trends from a time series data, which can be further used to identify
    /// independent high/low cycles.
    /// Reference: http://stockcharts.com/school/doku.php?id=chart_school:technical_indicators:detrended_price_osci
    /// </summary>
    class DetrendedPriceOscillation : ISeriesTransform
    {
        /// <summary>
        /// The period for which the price oscillation is being computed.
        /// </summary>
        private readonly int period;

        /// <summary>
        /// The period with which the moving average is being displaced.
        /// </summary>
        private readonly int shift;

        /// <summary>
        /// The current index value.
        /// </summary>
        private decimal current;

        /// <summary>
        /// The EMA values for the previous days, for shifting.
        /// </summary>
        private Queue<decimal> previous;

        /// <summary>
        /// The moving average of the indices on tracked period.
        /// </summary>
        private ExponentialMovingAverage periodAverage;

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
            this.period = period;
            this.shift  = period / 2 + 1;
            periodAverage = new ExponentialMovingAverage(period);
            previous = new Queue<decimal>(shift);
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
            current = value;

            if (!periodAverage.IsReady())
            {
                periodAverage.AddIndex(value);
            }
            else if (previous.Count >= shift)
            {
                periodAverage.AddIndex(previous.Dequeue());
            }

            previous.Enqueue(value);
        }

        /// <summary>
        /// Determines whether this instance is ready.
        /// </summary>
        /// <returns><c>true</c> if this instance is ready; otherwise, <c>false</c>.</returns>
        public bool IsReady()
        {
            return periodAverage.IsReady() && previous.Count >= shift;
        }

        /// <summary>
        /// Gets the moving average convergence divergence value for the current day.
        /// </summary>
        /// <returns>Moving average convergence divergence value for the current day.</returns>
        public decimal GetValue()
        {
            return current - periodAverage.GetValue();
        }
    }
}
