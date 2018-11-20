using System;
using System.ComponentModel;

namespace Ticker.Model
{
    public class Stocks : INotifyPropertyChanged
    {
        string _StockSymbol;
        public string StockSymbol
        {
            get
            {
                return _StockSymbol;
            }
            set
            {
                if (_StockSymbol != value)
                {
                    _StockSymbol = value;
                    RaisePropertyChanged("StockSymbol");
                }
            }
        }

        string _StockCompanyName;
        public string StockCompanyName
        {
            get
            {
                return _StockCompanyName;
            }
            set
            {
                if (_StockCompanyName != value)
                {
                    _StockCompanyName = value;
                    RaisePropertyChanged("StockCompanyName");
                }
            }
        }

        string _StockPrice;
        public string StockPrice

        {
            get
            {
                return _StockPrice;
            }
            set
            {
                if (_StockPrice != value)
                {
                    _StockPrice = value;
                    RaisePropertyChanged("StockPrice");
                }
            }
        }

        void RaisePropertyChanged(string prop)
        {
            if (PropertyChanged != null) { PropertyChanged(this, new PropertyChangedEventArgs(prop)); }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
