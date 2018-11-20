using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using Ticker.Model;
using Ticker.Helpers;
using Newtonsoft.Json;
using System.Windows;

namespace Ticker.ViewModel
{
    class ViewModelMain : ViewModelBase
    {
        public ObservableCollection<Stocks> Symbols { get; set; }

        object _SelectedStock;
        public object SelectedStock
        {
            get
            {
                return _SelectedStock;
            }
            set
            {
                if (_SelectedStock != value)
                {
                    _SelectedStock = value;
                    RaisePropertyChanged("SelectedStock");
                }
            }
        }
        string _TextProperty1;
        public string TextProperty1
        {
            get
            {
                return _TextProperty1;
            }
            set
            {
                if (_TextProperty1 != value)
                {
                    _TextProperty1 = value;
                    RaisePropertyChanged("TextProperty1");
                }
            }
        }

        public RelayCommand AddSymbolCommand { get; set; }
        public RelayCommand GetCompanyCommand { get; set; }

        public class Quote
        {
            public string symbol { get; set; }
            public string companyName { get; set; }
            public string latestPrice { get; set; }
        }

        public ViewModelMain()
        {
            Symbols = new ObservableCollection<Stocks>
            {
                //    new Stocks{ StockSymbol="GOOG" },
                //    new Stocks{ StockSymbol="APPL"},
            };

            AddSymbolCommand = new RelayCommand(AddSymbol);
            GetCompanyCommand = new RelayCommand(GetCompany);
        }

        void AddSymbol(object parameter)
        {
            string IEXJson = "";

            if (parameter == null) return;
            //Symbols.Add(new Stocks { StockSymbol = parameter.ToString() });
            IEXJson = Retriever.IEXTradingQuoteJson(parameter.ToString());
            if (IEXJson != "")
            {
                Quote quote = new Quote();
                quote = JsonConvert.DeserializeObject<Quote>(IEXJson);
                Symbols.Add(new Stocks { StockSymbol = quote.symbol, StockCompanyName = quote.companyName, StockPrice = quote.latestPrice });
            }
            else
            {
                
            }
        }

        void GetCompany(object parameter)
        {
            string IEXJson = "";

            if (parameter == null) return;
            //TextProperty1 = Retriever.GetCompanyName(parameter.ToString());
            IEXJson = Retriever.IEXTradingQuoteJson(parameter.ToString());
            if (IEXJson != "")
            {
                Quote quote = new Quote();
                quote = JsonConvert.DeserializeObject<Quote>(IEXJson);
                TextProperty1 = quote.companyName;
            }
        }
    }
}
