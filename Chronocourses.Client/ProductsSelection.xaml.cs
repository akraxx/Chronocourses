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
using Chronocourses.Client.ProductService;
using System.Windows.Controls.Primitives;

namespace Chronocourses.Client
{
    public partial class Products : PhoneApplicationPage
    {
        TypeProductService.TypeProductServiceClient typeProductService = new TypeProductService.TypeProductServiceClient();
        ShopService.ShopServiceClient shopService = new ShopService.ShopServiceClient();
        TypeProductService.TypeProduct selectedTypeProduct;

        public Products()
        {
            InitializeComponent();

            GridCardView.Children.Add(new CartView());
        }

        private void navigate()
        {
            if (ListProducts.SelectedItem != null)
            {
                NavigationService.Navigate(new Uri("/Details.xaml?productId=" + ((ShopService.Product)ListProducts.SelectedItem).ID, UriKind.Relative));
            }
            /*else {

                Popup popup = new Popup();
                ErrorMessageBox control = new ErrorMessageBox();
                control.btnOK.Click += (s, args) =>
                {
                    popup.IsOpen = false;
                    navigation.Value = 28;
                };


                popup.Child = control;
                popup.IsOpen = true;
            }*/
        }

        private void navigation_ManipulationCompleted(object sender, ManipulationCompletedEventArgs e)
        {
            if (navigation.Value > 55)
            {
                navigate();
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
            if (NavigationContext.QueryString.TryGetValue("categoryId", out cId))
            {
                typeProductService.GetTypeProductCompleted += new EventHandler<TypeProductService.GetTypeProductCompletedEventArgs>(typeProductService_GetTypeProductCompleted);
                typeProductService.GetTypeProductAsync(int.Parse(cId));
            }
        }

        void typeProductService_GetTypeProductCompleted(object sender, TypeProductService.GetTypeProductCompletedEventArgs e)
        {
            selectedTypeProduct = e.Result;
            category.Text = e.Result.Label;

            shopService.GetProductsByProductTypeCompleted += new EventHandler<ShopService.GetProductsByProductTypeCompletedEventArgs>(shopService_GetProductsByProductTypeCompleted);
            shopService.GetProductsByProductTypeAsync(selectedTypeProduct.ID, (App.Current as App).Cart.Shop.ID);
            
        }

        void shopService_GetProductsByProductTypeCompleted(object sender, ShopService.GetProductsByProductTypeCompletedEventArgs e)
        {
            ListProducts.ItemsSource = e.Result;
        }


        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            navigation.Value = 28;

        }

        private void Button_TextInput(object sender, TextCompositionEventArgs e)
        {

        }

        private void ListProducts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            navigate();
        }

        /*protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {
            base.OnBackKeyPress(e);
            if (products.Text != string.Empty)
            {
                var result = MessageBox.Show("You are about to discard your changes. Continue?",
                "Warning", MessageBoxButton.OKCancel);
                if (result != MessageBoxResult.OK)
                {
                    e.Cancel = true;
                }
            }
        }*/
    }
}