namespace MarketPrediction
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    class OandaReader
    {
        public static Dictionary<string, Dictionary<DateTime, decimal>> ReadIndices(string filename)
        {
            var indices = new Dictionary<string, Dictionary<DateTime, decimal>>
                {
                    { "EUR/USD", new Dictionary<DateTime, decimal>() },
                    { "EUR/GBP", new Dictionary<DateTime, decimal>() },
                    { "EUR/RON", new Dictionary<DateTime, decimal>() },
                };

            using (var sr = new StreamReader(filename))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    if (line[0] == '#')
                    {
                        continue;
                    }

                    var vals = line.Split(",".ToCharArray());

                    var date = DateTime.Parse(vals[0].Trim("\"".ToCharArray()));

                    indices["EUR/USD"].Add(date, decimal.Parse(vals[1].Trim("\"".ToCharArray())));
                    indices["EUR/GBP"].Add(date, decimal.Parse(vals[2].Trim("\"".ToCharArray())));
                    indices["EUR/RON"].Add(date, decimal.Parse(vals[3].Trim("\"".ToCharArray())));
                }
            }

            return indices;
        }

        public static ICollection<decimal> GetIndices(Dictionary<DateTime, decimal> indices)
        {
            return indices.Values;
        } 
    }
}
