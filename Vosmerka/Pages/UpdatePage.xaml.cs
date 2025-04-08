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

namespace Vosmerka.Pages
{
    /// <summary>
    /// Логика взаимодействия для UpdatePage.xaml
    /// </summary>
    public partial class UpdatePage : Page
    {
        ConnectionClass connection = new ConnectionClass();
        public UpdatePage(int article)
        {
            InitializeComponent();
           
            CmbProductType.ItemsSource = connection.entities.Product_Type.Select(x => x.Name).ToList();
            if (article > 0)
            {
                TxtArticle.Text = article.ToString();
                TxbName.Text = connection.entities.Product
                    .Where(x => x.Article == article).FirstOrDefault().Name;

                TxbMinPrice.Text = connection.entities.Product
                    .Where(x => x.Article == article).FirstOrDefault().MinPrice.ToString();

                TxbSize.Text = connection.entities.Product
                    .Where(x => x.Article == article).FirstOrDefault().Size;

                TxbWWithB.Text = connection.entities.Product
                    .Where(x => x.Article == article).FirstOrDefault().Weight_WithBox.ToString();

                TxbWWithoutB.Text = connection.entities.Product
                    .Where(x => x.Article == article).FirstOrDefault().Weight_WithoutBox.ToString();

                TxbDescription.Text = connection.entities.Product
                    .Where(x => x.Article == article).FirstOrDefault().Description;
    
                int productTypeId = connection.entities.Product.Where(x => x.Article == article).FirstOrDefault().Id_ProductType - 1;
                CmbProductType.SelectedIndex = connection.entities.Product_Type
                    .Where(x => x.Id_Product_Type == productTypeId).FirstOrDefault().Id_Product_Type;
                BtnCreate.Visibility = Visibility.Hidden;
            }
            else
            {
                TxtArticle.Text = Convert.ToString(connection.entities.Product.Select(x => x.Article).Max() + 1);
                BtnDeletw.Visibility = Visibility.Hidden;
                BtnUpdate.Visibility = Visibility.Hidden;
            }

            //StpProduct.BindingGroup.SetValue(UidProperty, connection.entities.Product.Where(x => x.Article == article).FirstOrDefault());
        }

        private void BtnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                int art = Convert.ToInt32(TxtArticle.Text);
                string name = TxbName.Text;
                string price = TxbMinPrice.Text;
                int idPT = CmbProductType.SelectedIndex + 1;
                string size = TxbSize.Text;
                string wWithB = TxbWWithB.Text;
                string wWithoutB = TxbWWithoutB.Text;
                string description = TxbDescription.Text;
                //byte[] image = new byte[1];
                if (!String.IsNullOrEmpty(name) && !String.IsNullOrEmpty(price) &&
                    !String.IsNullOrEmpty(size) && idPT != -1 &&
                    !String.IsNullOrEmpty(wWithB) && !String.IsNullOrEmpty(wWithoutB) && !String.IsNullOrEmpty(description))
                {
                    Button button = sender as Button;
                    if (button.Name == "BtnCreate")
                    {
                        MessageBox.Show("Не fghjk");
                        ProductClass.CreateProduct(art, name, Convert.ToInt32(price), idPT, size, Convert.ToDouble(wWithB), Convert.ToDouble(wWithoutB), description);
                    }
                }
                else
                {
                    MessageBox.Show("Не все поля заполнены");
                }

            }
            catch(Exception ex) 
            {//"Данные введены неверно"
                MessageBox.Show(ex.Message);
            }

        }
    }
}
