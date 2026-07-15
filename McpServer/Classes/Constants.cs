using System;
using System.Collections.Generic;
using System.Text;

namespace McpServer.Classes
{
    public class Constants
    {
        public const string CountiesTestData = @"[
                                  { ""Name"": ""Afghanistan"", ""CurrencyCode"": ""AFN"", ""CurrencyName"": ""Afghan Afghani"" },
                                  { ""Name"": ""Albania"", ""CurrencyCode"": ""ALL"", ""CurrencyName"": ""Albanian Lek"" },
                                  { ""Name"": ""Algeria"", ""CurrencyCode"": ""DZD"", ""CurrencyName"": ""Algerian Dinar"" },
                                  { ""Name"": ""Angola"", ""CurrencyCode"": ""AOA"", ""CurrencyName"": ""Angolan Kwanza"" },
                                  { ""Name"": ""Argentina"", ""CurrencyCode"": ""ARS"", ""CurrencyName"": ""Argentine Peso"" },
                                  { ""Name"": ""Australia"", ""CurrencyCode"": ""AUD"", ""CurrencyName"": ""Australian Dollar"" },
                                  { ""Name"": ""Bangladesh"", ""CurrencyCode"": ""BDT"", ""CurrencyName"": ""Bangladeshi Taka"" },
                                  { ""Name"": ""Brazil"", ""CurrencyCode"": ""BRL"", ""CurrencyName"": ""Brazilian Real"" },
                                  { ""Name"": ""Canada"", ""CurrencyCode"": ""CDN"", ""CurrencyName"": ""Canadian Dolllar"" },
                                  { ""Name"": ""Chile"", ""CurrencyCode"": ""CLP"", ""CurrencyName"": ""Chilean Peso"" },
                                  { ""Name"": ""China"", ""CurrencyCode"": ""CNY"", ""CurrencyName"": ""Chinese Yuan"" },
                                  { ""Name"": ""Colombia"", ""CurrencyCode"": ""COP"", ""CurrencyName"": ""Colombian Peso"" },
                                  { ""Name"": ""Egypt"", ""CurrencyCode"": ""EGP"", ""CurrencyName"": ""Egyptian Pound"" },
                                  { ""Name"": ""Ethiopia"", ""CurrencyCode"": ""ETB"", ""CurrencyName"": ""Ethiopian Birr"" },
                                    { ""Name"": ""Germany"", ""CurrencyCode"": ""EUR"", ""CurrencyName"": ""Euro"" },                                  
                                    { ""Name"": ""France (Eurozone)"", ""CurrencyCode"": ""EUR"", ""CurrencyName"": ""Euro"" },
                                  { ""Name"": ""Ghana"", ""CurrencyCode"": ""GHS"", ""CurrencyName"": ""Ghanaian Cedi"" },
                                  { ""Name"": ""India"", ""CurrencyCode"": ""INR"", ""CurrencyName"": ""Indian Rupee"" },
                                  { ""Name"": ""Indonesia"", ""CurrencyCode"": ""IDR"", ""CurrencyName"": ""Indonesian Rupiah"" },
                                  { ""Name"": ""Iran"", ""CurrencyCode"": ""IRR"", ""CurrencyName"": ""Iranian Rial"" },
                                  { ""Name"": ""Iraq"", ""CurrencyCode"": ""IQD"", ""CurrencyName"": ""Iraqi Dinar"" },
                                  { ""Name"": ""Israel"", ""CurrencyCode"": ""ILS"", ""CurrencyName"": ""Israeli New Shekel"" },
                                  { ""Name"": ""Japan"", ""CurrencyCode"": ""JPY"", ""CurrencyName"": ""Japanese Yen"" },
                                  { ""Name"": ""Kazakhstan"", ""CurrencyCode"": ""KZT"", ""CurrencyName"": ""Kazakhstani Tenge"" },
                                  { ""Name"": ""Kenya"", ""CurrencyCode"": ""KES"", ""CurrencyName"": ""Kenyan Shilling"" },
                                  { ""Name"": ""Kuwait"", ""CurrencyCode"": ""KWD"", ""CurrencyName"": ""Kuwaiti Dinar"" },
                                  { ""Name"": ""Malaysia"", ""CurrencyCode"": ""MYR"", ""CurrencyName"": ""Malaysian Ringgit"" },
                                  { ""Name"": ""Mexico"", ""CurrencyCode"": ""MXN"", ""CurrencyName"": ""Mexican Peso"" },
                                  { ""Name"": ""Morocco"", ""CurrencyCode"": ""MAD"", ""CurrencyName"": ""Moroccan Dirham"" },
                                  { ""Name"": ""Myanmar"", ""CurrencyCode"": ""MMK"", ""CurrencyName"": ""Burmese Kyat"" },
                                  { ""Name"": ""Nepal"", ""CurrencyCode"": ""NPR"", ""CurrencyName"": ""Nepalese Rupee"" },
                                  { ""Name"": ""New Zealand"", ""CurrencyCode"": ""NZD"", ""CurrencyName"": ""New Zealand Dollar"" },
                                  { ""Name"": ""Nigeria"", ""CurrencyCode"": ""NGN"", ""CurrencyName"": ""Nigerian Naira"" },
                                  { ""Name"": ""Norway"", ""CurrencyCode"": ""NOK"", ""CurrencyName"": ""Norwegian Krone"" },
                                  { ""Name"": ""Pakistan"", ""CurrencyCode"": ""PKRR"", ""CurrencyName"": ""Pakistani Rupeee"" },
                                  { ""Name"": ""Philippines"", ""CurrencyCode"": ""PHP"", ""CurrencyName"": ""Philippine Peso"" },
                                  { ""Name"": ""Russia"", ""CurrencyCode"": ""RUB"", ""CurrencyName"": ""Russian Ruble"" },
                                  { ""Name"": ""Saudi Arabia"", ""CurrencyCode"": ""SAR"", ""CurrencyName"": ""Saudi Riyal"" },
                                  { ""Name"": ""Singapore"", ""CurrencyCode"": ""SGD"", ""CurrencyName"": ""Singapore Dollar"" },
                                  { ""Name"": ""South Africa"", ""CurrencyCode"": ""ZAR"", ""CurrencyName"": ""South African Rand"" },
                                  { ""Name"": ""South Korea"", ""CurrencyCode"": ""KRW"", ""CurrencyName"": ""South Korean Won"" },
                                  { ""Name"": ""Sweden"", ""CurrencyCode"": ""SEK"", ""CurrencyName"": ""Swedish Krona"" },
                                  { ""Name"": ""Switzerland"", ""CurrencyCode"": ""CHF"", ""CurrencyName"": ""Swiss Franc"" },
                                  { ""Name"": ""Taiwan"", ""CurrencyCode"": ""TWD"", ""CurrencyName"": ""New Taiwan Dollar"" },
                                  { ""Name"": ""Tanzania"", ""CurrencyCode"": ""TZS"", ""CurrencyName"": ""Tanzanian Shilling"" },
                                  { ""Name"": ""Thailand"", ""CurrencyCode"": ""THB"", ""CurrencyName"": ""Thai Baht"" },
                                  { ""Name"": ""Turkey"", ""CurrencyCode"": ""TRY"", ""CurrencyName"": ""Turkish Lira"" },
                                  { ""Name"": ""Uganda"", ""CurrencyCode"": ""UGX"", ""CurrencyName"": ""Ugandan Shilling"" },
                                  { ""Name"": ""Ukraine"", ""CurrencyCode"": ""UAH"", ""CurrencyName"": ""Ukrainian Hryvnia"" },
                                  { ""Name"": ""United Kingdom"", ""CurrencyCode"": ""GBP"", ""CurrencyName"": ""British Pound Sterling"" },
                                  { ""Name"": ""United States"", ""CurrencyCode"": ""USD"", ""CurrencyName"": ""US Dollar"" },
                                  { ""Name"": ""Vietnam"", ""CurrencyCode"": ""VND"", ""CurrencyName"": ""Vietnamese Dong"" }
                                ]";
    }
}
