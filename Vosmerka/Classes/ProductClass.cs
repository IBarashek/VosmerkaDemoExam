using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Vosmerka.DB;

namespace Vosmerka.Classes
{
    class ProductClass:Product
    {

        public static void CreateProduct(int article, string name, int minPrice, int id_PT, string size, double w_WitB, double w_WithoutD, byte[] imageProduct, string description)
        {
            ConnectionClass connection = new ConnectionClass();
           
            Product product = new Product()
            {
                Article = article,
                Name = name,
                MinPrice = minPrice,
                Id_ProductType = id_PT,
                Size = size,
                Weight_WithBox = w_WitB,
                Weight_WithoutBox = w_WithoutD,
                Image = imageProduct,
                Description = description
            };

            connection.entities.Product.Add(product);
            connection.entities.SaveChanges();
        }

        public static void DeleteProduct(int article)
        {
            ConnectionClass connection = new ConnectionClass();

            Product product = new Product();
            product = connection.entities.Product.FirstOrDefault(x => x.Article == article);

            connection.entities.Product.Remove(product);
            connection.entities.SaveChanges();
        }

    }
}
