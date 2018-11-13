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

        void RaisePropertyChanged(string prop)
        {
            if (PropertyChanged != null) { PropertyChanged(this, new PropertyChangedEventArgs(prop)); }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
