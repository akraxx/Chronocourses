using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Chronocourses.Manager.Silverlight;
using Chronocourses.Manager.Silverlight.ProductService;

namespace Chronocourses.Manager.Silverlight
{
    public partial class MainPage : UserControl
    {
       public Product CurrentProduct { set; get; }

        public string Test { set; get; }

        private ProductService.ProductServiceClient productService;
        private BrandService.BrandServiceClient BrandService;
        
        public MainPage()
        {
            productService = new ProductService.ProductServiceClient();
            BrandService = new BrandService.BrandServiceClient();
            InitializeComponent();
            
        }

        private void  productService_GetProductsCompleted(object sender, ProductService.GetProductsCompletedEventArgs e)
        {
 	        products.ItemsSource = e.Result;
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Product currentProduct = (Product)products.SelectedItem;
            if (currentProduct != null)
            {
                productService.SaveProductAsync(currentProduct);
            }

        }

        private void products_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (products.SelectedItem != null)
            {
                CurrentProduct = (Product)products.SelectedItem;
            }
        }



        private void next_Click(object sender, RoutedEventArgs e)
        {
            if (products.SelectedIndex + 1 < products.ItemsSource.OfType<Product>().Count())
            {
                products.SelectedIndex++;
            }
        }

        private void previous_Click(object sender, RoutedEventArgs e)
        {
            if (products.SelectedIndex - 1 >= 0)
            {
                products.SelectedIndex--;
            }
        }

        private void new_Click(object sender, RoutedEventArgs e)
        {
            Product newProduct = new Product();
            newProduct.Price = newPrix.Text;
            newProduct.BrandID = ((Brand)marques.SelectedItem).ID;

            productService.AddProductAsync(newProduct);
            productService.GetProductsAsync();
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            if (products.SelectedItem != null)
            {
                Product product = (Product)products.SelectedItem;
                Console.WriteLine(product.ID);
                productService.DeleteProductAsync(product);
                productService.GetProductsAsync();

            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            productService.GetProductsCompleted += new EventHandler<ProductService.GetProductsCompletedEventArgs>(productService_GetProductsCompleted);
            BrandService.GetBrandsCompleted += new EventHandler<Silverlight.BrandService.GetBrandsCompletedEventArgs>(BrandService_GetBrandsCompleted);

            BrandService.GetBrandsAsync();
            productService.GetProductsAsync();



            products.SelectedIndex = 0;
        }

        void BrandService_GetBrandsCompleted(object sender, BrandService.GetBrandsCompletedEventArgs e)
        {
            marques.ItemsSource = e.Result;
        }


    }
}
