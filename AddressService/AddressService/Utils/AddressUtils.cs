using AddressService.Utils;
using System.Collections.Generic;
using System.Linq;

namespace AddressService
{
    public static class AddressUtils
    {
        public static string GetAggregateCity(Address address, IEnumerable<string> aggregateCities, int eps = 4)
        {
            var normCity = StringUtils.NormaliseCityName(address.City);
            var levDistances = new Dictionary<int, string>();
            
            foreach (var agCity in aggregateCities)
            {
                var levDistance = StringUtils.LevenshteinDistance(normCity, agCity);
                if (levDistance == 0)
                {
                    return agCity;
                }
                else
                {
                    // Ignore second city with same Lev distance. No sensible way to resolve.
                    if (!levDistances.ContainsKey(levDistance))
                    {
                        levDistances.Add(levDistance, agCity);
                    }
                }
            }

            if (!levDistances.Any())
            {
                return normCity;
            }
            int  minKey = levDistances.Keys.Min();
            if (minKey < eps)
            {
                return levDistances[minKey];
            }
            else
            {
                return normCity;
            }
        }
    }
}
