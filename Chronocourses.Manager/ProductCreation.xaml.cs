using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Chronocourses.Model;

namespace Chronocourses.Manager
{
    /// <summary>
    /// Logique d'interaction pour ProductCreation.xaml
    /// </summary>
    public partial class ProductCreation : UserControl
    {
        ProductService.ProductServiceClient productService;
        BrandService.BrandServiceClient brandService;
        TypeProductService.TypeProductServiceClient typeProductService;

        public ProductCreation()
        {
            InitializeComponent();

            brandService = new BrandService.BrandServiceClient();
            typeProductService = new TypeProductService.TypeProductServiceClient();

            Brands.ItemsSource = brandService.GetBrands();
            TypeProducts.ItemsSource = typeProductService.GetTypeProducts();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            Product product = new Product();
            product.Name = Name.Text;
            product.Price = Double.Parse(Price.Text);
            if (!newProductType.Text.Equals(""))
            {
                TypeProduct typeProduct = new TypeProduct();
                typeProduct.Label = newProductType.Text;

                typeProductService.AddTypeProduct(typeProduct);
                product.TypeProduct = typeProduct;
            }
            else
            {
                product.TypeProduct = (TypeProduct)TypeProducts.SelectedItem;
            }

            if (!newProductType.Text.Equals(""))
            {
                TypeProduct typeProduct = new TypeProduct();
                typeProduct.Label = newProductType.Text;

                typeProductService.AddTypeProduct(typeProduct);
                product.TypeProduct = typeProduct;
            }
            else
            {
                product.TypeProduct = (TypeProduct)TypeProducts.SelectedItem;
            }
            

        }

    }
}
