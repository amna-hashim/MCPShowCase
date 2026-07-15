using McpServer.Classes;
using ModelContextProtocol.Server;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace McpServer.Tools
{
    [McpServerToolType]
    public static class CountryTools
    {
        [McpServerTool(Name = "get_currency_country"), Description("Get currency for a specific country")]
        public static string GetCurrencyByCountry(
      [Description("Country name (e.g., 'Canada', 'India')")] string countryName)
        {
            var countries = Helpers.GetCountriesData();
            if (countries != null)
            {
                var country = countries.Find(c => c.Name.Equals(countryName, StringComparison.OrdinalIgnoreCase));
                if (country != null)
                {
                    return $"The currency of {country.Name} is {country.CurrencyCode}.";
                }
                else
                {
                    return $"Country '{countryName}' not found.";
                }
            }
            return $"Country '{countryName}' not found.";
        }


        [McpServerTool(Name = "get_countries_currency"), Description("Get countries that has a specific currency")]
        public static List<string> GetCountriesByCurrency(
      [Description("Currency code (e.g., 'USD', 'CDN')")] string currencyCode)
        {
            var countries = Helpers.GetCountriesData();
            if (countries != null)
            {
                var filteredCountries = countries.Where(c => c.CurrencyCode.Equals(currencyCode, StringComparison.OrdinalIgnoreCase)).ToList();
                if (filteredCountries.Count > 0)
                {
                    return filteredCountries.Select(c => c.Name).ToList();
                }
            }
            return null;
        }

        [McpServerTool(Name = "get_all_countries"), Description("Get all countries")]
        public static List<string> GetAllCountries()
        {
            var countries = Helpers.GetCountriesData();
            if (countries != null)
            {
                return countries.Select(c => c.Name).ToList();
            }
            return null;
        }


        [McpServerTool(Name = "add_new_country"), Description("Add a new country if not already exists")]
        public static string AddNewCountry(
          string countryName, string currencyCode, string currencyName)
        {
            var countries = Helpers.GetCountriesData();
            if (countries != null)
            {
                var countryObj = countries.FirstOrDefault(c => c.Name.Equals(countryName, StringComparison.OrdinalIgnoreCase));
                if (countryObj == null)
                {
                    Country newCountry = new Country();
                    newCountry.Name = countryName;
                    newCountry.CurrencyCode = currencyCode;
                    newCountry.CurrencyName = currencyName;

                    Helpers.Countries.Add(newCountry);

                    return countryName;
                }
            }
            return "";
        }
    }
}
