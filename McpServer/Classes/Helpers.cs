using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace McpServer.Classes
{
    public static class Helpers
    {
        public static List<Country> Countries = new List<Country>();
        public static List<Country> GetCountriesData()
        {
            if (Countries.Count < 1)
            {
                List<Country> countries = JsonSerializer.Deserialize<List<Country>>(Constants.CountiesTestData);
                Countries.AddRange(countries);
            }
            return Countries;
        }
    }
}
