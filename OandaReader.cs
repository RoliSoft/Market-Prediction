namespace MarketPrediction
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    class OandaReader
    {
        public static Dictionary<string, SortedDictionary<DateTime, decimal>> ReadIndices(string filename)
        {
            var indices = new Dictionary<string, SortedDictionary<DateTime, decimal>>
                {
                    { "EUR/USD", new SortedDictionary<DateTime, decimal>() },
                    { "EUR/GBP", new SortedDictionary<DateTime, decimal>() },
                    { "EUR/RON", new SortedDictionary<DateTime, decimal>() },
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
