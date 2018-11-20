using System.Windows;
using System.Windows.Controls;

namespace Ticker.ViewModel
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void txtSymbol_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tname = sender as TextBox;
            if (tname.Text == "Type Symbol Here")
            {
                tname.Clear();
            }
        }

        private void dgStocks_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            switch (e.Column.Header.ToString())
            {
                case "StockSymbol":
                    e.Column.Header = "Symbol";
                    break;
                case "StockCompanyName":
                    e.Column.Header = "Company Name";
                    break;
                case "StockPrice":
                    e.Column.Header = "Latest Price";
                    break;
            }
        }
    }
}
