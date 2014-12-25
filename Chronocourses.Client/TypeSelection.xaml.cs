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
using System.Windows.Controls.Primitives;
using Chronocourses.Client.TypeProductService;

namespace Chronocourses.Client
{
    public partial class TypeSelection : PhoneApplicationPage
    {
        private TypeProductService.TypeProductServiceClient typeProductService = new TypeProductService.TypeProductServiceClient();
        private ShopService.ShopServiceClient shopService = new ShopService.ShopServiceClient();

        public TypeSelection()
        {
            InitializeComponent();

            GridCardView.Children.Add(new CartView());

            typeProductService.GetTypeProductsCompleted += new EventHandler<TypeProductService.GetTypeProductsCompletedEventArgs>(typeProductService_GetTypeProductsCompleted);
            typeProductService.GetTypeProductsAsync();
        }

        void typeProductService_GetTypeProductsCompleted(object sender, TypeProductService.GetTypeProductsCompletedEventArgs e)
        {
            Categories.ItemsSource = e.Result;
        }

        private void navigate()
        {
            if (Categories.SelectedItem != null)
            {
                NavigationService.Navigate(new Uri("/ProductsSelection.xaml?categoryId=" + ((TypeProduct)Categories.SelectedItem).ID, UriKind.Relative));
            }
            
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
            string shopId = "";
            if (NavigationContext.QueryString.TryGetValue("shopId", out shopId))
            {
                shopService.GetShopCompleted += new EventHandler<ShopService.GetShopCompletedEventArgs>(shopService_GetShopCompleted);
                shopService.GetShopAsync(int.Parse(shopId));
            }
        }

        void shopService_GetShopCompleted(object sender, ShopService.GetShopCompletedEventArgs e)
        {
            ShopText.Text = e.Result.Name;
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            navigation.Value = 28;
        }

        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {

        }

        private void Categories_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            navigate();
        }
        
    }
}