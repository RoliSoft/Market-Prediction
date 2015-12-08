namespace MarketPrediction
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    class Indicators
    {
        public static decimal CalculateRSI(decimal[] prices)
        {
            decimal gain = 0, // average up move
                    loss = 0; // average down move
            
            for (int i = 1; i < prices.Length; i++)
            {
                var diff = prices[i] - prices[i - 1];

                if (diff >= 0)
                {
                    gain += diff;
                }
                else
                {
                    loss -= diff;
                }
            }

            if (gain == 0)
            {
                return 0;
            }

            if (Math.Abs(loss) < 1)
            {
                return 100;
            }

            var rs = gain / loss;
            var rsi = 100 - (100 / (1 + rs));

            // ?

            decimal upsum = 0;
            decimal downsum = 0;

            for (int i = 14; i < prices.Length; i++)
            {
                var diff = prices[i] - prices[i - 1];
                decimal cur;

                if (diff >= 0)
                {
                    cur = diff;
                }
                else
                {
                    cur = -diff;
                }

                upsum = (upsum * 13 + cur) / 14;
                downsum = (downsum * 13 + cur) / 14;

                decimal rs2 = upsum / downsum;
                decimal rsi2/*[i]*/ = 100 - (100 / (1 + rs2));
            }
        }
    }
}
