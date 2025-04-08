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
using Vosmerka.Windows;

namespace Vosmerka.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        int selectedProductArt;
        ConnectionClass connection = new ConnectionClass();
        List<string> productTypes = new List<string>();
        public MainPage()
        {
            InitializeComponent();
            
            LstProducts.ItemsSource = connection.entities.Product.ToList();
            productTypes = connection.entities.Product_Type.Select(x => x.Name).ToList();
            productTypes.Add("Все типы");
            CmbFilter.ItemsSource = productTypes;
            
        }

        private void CmbSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void CmbFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string namePT = CmbFilter.SelectedItem.ToString();
            if (namePT != "Все типы")
            {
                LstProducts.ItemsSource = connection.entities.Product.Where(x =>
                          x.Id_ProductType == connection.entities.Product_Type.Where(y =>
                               y.Name == namePT).FirstOrDefault().Id_Product_Type).ToList();
            }
            else
            {
                LstProducts.ItemsSource = connection.entities.Product.ToList();
            }
        }
            
private void ListViewItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
           
            var itemIndex = LstProducts.SelectedIndex;
            selectedProductArt = connection.entities.Product
                .Where(x => x.Id_Product == itemIndex + 1)
                .Select(x => x.Article).FirstOrDefault();

        }

        private void SearchNameDesc(object sender, TextChangedEventArgs e)
        {
            string search = TxbSearch.Text;
            if (search != null)
            {
                LstProducts.ItemsSource = connection.entities.Product
                .Where(x => x.Name.Contains(search) || x.Description.Contains(search)).ToList();
            }
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            if (selectedProductArt != 0)
            {
                UpdateWindow window = new UpdateWindow(selectedProductArt);
                window.Show();
            }
            else
            {
                MessageBox.Show("Выберите продукт для изменения");
            }
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            
            UpdateWindow window = new UpdateWindow(0);
            window.Show();
        }
    }
}
