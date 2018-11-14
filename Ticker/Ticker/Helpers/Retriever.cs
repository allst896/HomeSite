using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net;
using System.IO;
using System.Xml;
using IronPython.Hosting;
using Microsoft.Scripting.Hosting;

namespace Ticker.Helpers
{
    public class Retriever
    {
        public static string GetCompanyName(string ssymbol)
        {
            string retSymbol = string.Empty;

            try
            {
                //var url = Properties.Settings.Default.BarchartURL + "getProfile.xml?";
                //var apikey = "apikey=" + Properties.Settings.Default.BarchartAPIKey;
                //var uri = url + apikey + "&symbols=" + ssymbol;


                string temp = BarchartOnDemand();
            }
            catch (Exception ex) { string temp = ex.Message; }
            return retSymbol;
        }

        public static string BarchartOnDemand()
        {
            var engine = Python.CreateEngine();
            var scope = engine.CreateScope();

            ScriptSource source = engine.CreateScriptSourceFromFile(Directory.GetCurrentDirectory() + "\\ondemand.py");
            object result = source.Execute(scope);
            return result.ToString();
        }
    }
}
