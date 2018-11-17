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

        public ViewModelMain()
        {
            Symbols = new ObservableCollection<Stocks>
            {
                new Stocks{ StockSymbol="GOOG" },
                new Stocks{ StockSymbol="APPL"},
            };

            AddSymbolCommand = new RelayCommand(AddSymbol);
            GetCompanyCommand = new RelayCommand(GetCompany);
        }

        void AddSymbol(object parameter)
        {
            if (parameter == null) return;
            Symbols.Add(new Stocks { StockSymbol = parameter.ToString() });
        }

        void GetCompany(object parameter)
        {
            if (parameter == null) return;
            TextProperty1 = Retriever.GetCompanyName(parameter.ToString());
        }
    }
}
