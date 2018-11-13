using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticker.Model
{
    class Profile
    {
        public string Symbol { get; set; }
        public string SymbolCode { get; set; }
        public string Exchange { get; set; }
        public string ExchangeName { get; set; }
        public string SicSector { get; set; }
        public string Industry { get; set; }
        public string SubIndustry { get; set; }
        public string BusinessSummary { get; set; }
        public string CEO { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
        public string PhoneNumber { get; set; }
        public string InstrumentType { get; set; }
    }
}
