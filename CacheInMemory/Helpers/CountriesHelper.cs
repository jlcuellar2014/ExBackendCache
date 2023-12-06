using CacheInMemory.Model;
using Microsoft.VisualBasic.FileIO;

namespace CacheInMemory.Helpers
{
    public static class CountriesHelper
    {
        /// <summary>
        /// Reads a CSV file containing country information, where position 0 has the country code
        /// in ISO 3166-1 alpha2 format, and position 1 has the country name.
        /// </summary>
        /// <param name="filePath">The path to the CSV file.</param>
        /// <returns>A list of Country objects with country information.</returns>
        public static List<Country> GetCountiesFromStaticCsv(string filePath)
        {
            var countries = new List<Country>();

            using TextFieldParser parser = new TextFieldParser(filePath);
            parser.TextFieldType = FieldType.Delimited;
            parser.SetDelimiters(",");

            while (!parser.EndOfData)
            {
                var fields = parser.ReadFields();

                try
                {
                    var countryCode = fields?[0].Trim()?? string.Empty;

                    if(countryCode.Length.Equals(2)) {
                        var country = new Country
                        {
                            CountryCode = countryCode.ToUpper(),
                            CountryName = fields?[1].Trim() ?? string.Empty
                        };

                        countries.Add(country);
                    }
                }
                catch (Exception) { }
            }

            return countries.Distinct().ToList<Country>();
        }
    }
}
