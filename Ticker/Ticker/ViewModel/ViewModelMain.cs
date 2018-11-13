using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using Ticker.Model;
using Ticker.Helpers;

namespace Ticker.ViewModel
{
    class ViewModelMain : ViewModelBase
    {
        public ObservableCollection<Stocks> Symbols { get; set; }

        public RelayCommand AddSymbolCommand { get; set; }

        public ViewModelMain()
        {
            Symbols = new ObservableCollection<Stocks>
            {
                new Stocks{ StockSymbol="GOOG" },
                new Stocks{ StockSymbol="APPL"},
            };

            AddSymbolCommand = new RelayCommand(AddSymbol);
        }

        void AddSymbol(object parameter)
        {
            if (parameter == null) return;
            Symbols.Add(new Stocks { StockSymbol = parameter.ToString() });
        }
    }
}
