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
using System.Net.Http;
using System.Net.Http.Headers;

namespace Ticker.Helpers
{
    public class Retriever
    {
        static HttpClient client = new HttpClient();

        public static string IEXTradingQuoteJson(string tsymbol)
        {
            string response = "";

            try
            {
                using (var wb = new WebClient())
                {
                    response = wb.DownloadString("https://api.iextrading.com/1.0/stock/" + tsymbol + "/quote");
                }
            }
            catch (Exception ex)
            {

            }
            return response;
        }

        public static string BarchartOnDemand()
        {
            string r = "";

            XmlDocument soapEnvelopeXml = new XmlDocument();
            soapEnvelopeXml.LoadXml(@"<?xml version=""1.0"" encoding=""utf-8""?>
                <soap:Envelope xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"">
                  <soap:Body>
                    <getQuote><apikey>apikey</apikey><symbols>AAPL</symbols></getQuote>
                  </soap:Body>
                </soap:Envelope>");

            HttpWebRequest wr = (HttpWebRequest)WebRequest.Create("https://marketdata.websol.barchart.com/");
            wr.Headers.Add("SOAPAction", "http://marketdata.websol.barchart.com/service");
            wr.ContentType = "text / xml; charset =\"utf-8\"";
            wr.Accept = "text/xml";
            wr.Method = "POST";

            using (Stream stream = wr.GetRequestStream())
            {
                soapEnvelopeXml.Save(stream);
            }

            using (WebResponse wresp = wr.GetResponse())
            {
                using (StreamReader sr = new StreamReader(wresp.GetResponseStream()))
                {
                    r = sr.ReadToEnd();
                }
            }
            return r.ToString();
        }
    }
}
