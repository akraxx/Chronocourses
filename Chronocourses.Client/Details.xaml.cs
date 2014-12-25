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
using Microsoft.Phone.Controls;

namespace Chronocourses.Client
{
    public partial class Details : PhoneApplicationPage
    {
        ProductService.ProductServiceClient productService = new ProductService.ProductServiceClient();
        ProductService.Product selectedProduct;

        public Details()
        {
            InitializeComponent();

            GridCardView.Children.Add(new CartView());

        }

        private void navigation_ManipulationCompleted(object sender, ManipulationCompletedEventArgs e)
        {
            if (navigation.Value > 55)
            {
            }
            else if (navigation.Value < 5)
            {
                if (NavigationService.CanGoBack)
                {

                    NavigationService.GoBack();
                }
            }
            else
            {
                navigation.Value = 28;
            }
        }


        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            string cId = "";
            if (NavigationContext.QueryString.TryGetValue("productId", out cId))
            {
                productService.GetProductCompleted += new EventHandler<ProductService.GetProductCompletedEventArgs>(productService_GetProductCompleted);
                productService.GetProductAsync(int.Parse(cId));
            }
        }

        void productService_GetProductCompleted(object sender, ProductService.GetProductCompletedEventArgs e)
        {
            nameText.Text = e.Result.Name;
            priceText.Text = e.Result.Price.ToString();
            description.Text = e.Result.Description;
            brandText.Text = e.Result.Brand.Name;
            productTypeText.Text = e.Result.TypeProduct.Label;
            selectedProduct = e.Result;
        }



        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            navigation.Value = 28;

        }

        private void Button_TextInput(object sender, TextCompositionEventArgs e)
        {

        }

        private void quantity_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Focus();
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            int q = 0;
            if (quantity.Text != "" && int.TryParse(quantity.Text, out q) && selectedProduct != null)
            {
                Cart cart = (App.Current as App).Cart;
                cart.AddProduct(selectedProduct, q);
            }
        }

        protected override void OnNavigatedFrom(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);
        }

    }
}