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
using Chronocourses.Manager.ProductService;
using Chronocourses.Model;
using System.Windows.Controls.Primitives;

namespace Chronocourses.Manager
{
    /// <summary>
    /// Logique d'interaction pour Product.xaml
    /// </summary>
    public partial class ProductControl : UserControl
    {
        ProductServiceClient productService = new ProductServiceClient();
        TypeProductService.TypeProductServiceClient typeService = new TypeProductService.TypeProductServiceClient();
        BrandService.BrandServiceClient brandService = new BrandService.BrandServiceClient();


        public ProductControl(int id)
        {
            InitializeComponent();
            this.tabControl1.SelectedIndex = id;
            RefreshDataGrid(null, null);
        }

        private void RefreshDataGrid(object sender, RoutedEventArgs e)
        {
            Products.ItemsSource = productService.GetProducts();
            TypeProducts.ItemsSource = typeService.GetTypeProducts();
            Brands.ItemsSource = brandService.GetBrands();
            BrandEDIT.ItemsSource = brandService.GetBrands();
            CategorieEDIT.ItemsSource = typeService.GetTypeProducts();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (Name != null && Price != null && TypeProducts.SelectedItem != null && Brands.SelectedItem != null)
            {
                Product product = new Product();
                product.Price = Double.Parse(Price.Text);
                product.Name = Name.Text;
                
                product.Available = Available.IsChecked == true;
                product.Description = Description.Text;
                product.TypeProductID = ((TypeProduct)TypeProducts.SelectedItem).ID;
                product.BrandID = ((Brand)Brands.SelectedItem).ID;

                productService.AddProduct(product);
                MessageBox.Show(product.Name + " has been added.");
                Products.ItemsSource = productService.GetProducts();
            }
            else
            {
                MessageBox.Show(" Please fill all fields to add a product.");
            }
        }

        private void Del_Click(object sender, RoutedEventArgs e)
        {
            productService.DeleteProduct(((Product)Products.SelectedItem));
            MessageBox.Show(" has been deleted.");
            Products.ItemsSource = productService.GetProducts();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            Product prodModif = ((Product)Products.SelectedItem);
            prodModif.Name = NameEDIT.Text;
            prodModif.Price = Double.Parse(PriceEDIT.Text);
            prodModif.Available = checkBowEDIT.IsChecked == true;
            prodModif.TypeProductID = ((TypeProduct)CategorieEDIT.SelectedItem).ID;
            prodModif.BrandID = ((Brand)BrandEDIT.SelectedItem).ID;
            prodModif.Description = DescriptionEDIT.Text;
            MessageBox.Show("Modifications has been saved.");
            productService.SaveProduct(prodModif);
        }

        private void AddBrand_Click(object sender, RoutedEventArgs e)
        {
            Window window = new Window();
            window.Height = 600;
            window.Width = 800;
            window.Show();
            UserControl temp_window = new BrandControl();
            window.Content = temp_window;
            temp_window.Unloaded += new RoutedEventHandler(RefreshDataGrid);
        }        

        private void AddCat_Click(object sender, RoutedEventArgs e)
        {
            Window window = new Window();
            window.Height = 600;
            window.Width = 800;
            window.Show();
            UserControl temp_window = new Categorie();
            window.Content = temp_window;
            temp_window.Unloaded += new RoutedEventHandler(RefreshDataGrid);
        }

        private void filtreCAT_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void filtreBRAND_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
