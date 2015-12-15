namespace MarketPrediction
{
    using System;

    /// <summary>
    /// Implements a relative strength index calculator.
    /// Reference: http://www.investopedia.com/articles/technical/03/070203.asp
    /// </summary>
    class RelativeStrengthIndex
    {
        /// <summary>
        /// The period for which the relative strength is being computed.
        /// </summary>
        private readonly int period;

        /// <summary>
        /// The value of the strength index for the current day.
        /// </summary>
        private decimal strength;

        /// <summary>
        /// The value of the previous index.
        /// </summary>
        private decimal previous = decimal.MinValue;

        /// <summary>
        /// The moving average of the indices on days with gains.
        /// </summary>
        private ExponentialMovingAverage gainAverage;

        /// <summary>
        /// The moving average of the indices on days with losses.
        /// </summary>
        private ExponentialMovingAverage lossAverage;

        /// <summary>
        /// Initializes a new instance of the <see cref="MovingAverageConvergenceDivergence" /> class.
        /// </summary>
        /// <param name="period">The period.</param>
        public RelativeStrengthIndex(int period)
        {
            this.period = period;
            gainAverage = new ExponentialMovingAverage(30);
            lossAverage = new ExponentialMovingAverage(30);
        }

        /// <summary>
        /// Adds an index to the moving average.
        /// </summary>
        /// <param name="value">The index value.</param>
        public void AddIndex(decimal value)
        {
            if (previous != decimal.MinValue)
            {
                if (value >= previous)
                {
                    gainAverage.AddIndex(value - previous);
                    lossAverage.AddIndex(0);
                }
                else
                {
                    gainAverage.AddIndex(0);
                    lossAverage.AddIndex(previous - value);
                }
            }

            previous = value;

            if (lossAverage.GetValue() == 0)
            {
                strength = 100;
                return;
            }

            var relativeStrength = gainAverage.GetValue() / lossAverage.GetValue();
            strength = 100 - (100 / (1 + relativeStrength));
        }

        /// <summary>
        /// Determines whether this instance is ready.
        /// </summary>
        /// <returns><c>true</c> if this instance is ready; otherwise, <c>false</c>.</returns>
        public bool IsReady()
        {
            return gainAverage.IsReady() && lossAverage.IsReady();
        }

        /// <summary>
        /// Gets the strength index for the current day.
        /// </summary>
        /// <returns>Strength index for the current day.</returns>
        public decimal GetValue()
        {
            return strength;
        }
    }
}
