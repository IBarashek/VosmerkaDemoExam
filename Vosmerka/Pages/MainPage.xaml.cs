using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Vosmerka.Classes;
using Vosmerka.DB;

namespace Vosmerka.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        ConnectionClass connection = new ConnectionClass();
        List<string> productTypes = new List<string>();
        public MainPage()
        {
            InitializeComponent();
            
            productTypes = connection.entities.Product_Type.Select(x => x.Name).ToList();
            productTypes.Add("Все типы");
            CmbFilter.ItemsSource = productTypes;
            
        }

        private void CmbSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void CmbFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
            
private void ListViewItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var selectedProduct = e.Source as Product;
            if (selectedProduct != null)
            {
                MessageBox.Show(selectedProduct.Article.ToString());
            }
        }
    
    }
}
