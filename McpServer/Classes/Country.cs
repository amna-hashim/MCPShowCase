using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace McpServer.Classes
{
    public class Country
    {
        private string name = "";
        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        private string currencyCode = "";
        public string CurrencyCode
        {
            get { return this.currencyCode; }
            set { this.currencyCode = value; }
        }

        private string currencyName = "";
        public string CurrencyName
        {
            get { return this.currencyName; }
            set { this.currencyName = value; }
        }

        public Country() { }
    }
}
