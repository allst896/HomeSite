using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net;

namespace Ticker.Helpers
{
    class Retriever
    {
        public string GetCompanyName(string ssymbol)
        {
            string retSymbol = string.Empty;

            try
            {
                var url = Properties.Settings.Default.BarchartURL;

            }
            catch (Exception) { }
            return retSymbol;
        }
    }
}
