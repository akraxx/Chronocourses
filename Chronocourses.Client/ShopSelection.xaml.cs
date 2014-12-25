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
using System.Threading;
using Chronocourses.Client.ShopService;
using System.Windows.Controls.Primitives;

namespace Chronocourses.Client
{
    public partial class ShopSelection : PhoneApplicationPage
    {
        ShopService.ShopServiceClient shopService = new ShopService.ShopServiceClient();

        public ShopSelection()
        {
            InitializeComponent();

            GridCardView.Children.Add(new CartView());

            shopService.GetShopsCompleted += new EventHandler<ShopService.GetShopsCompletedEventArgs>(shopService_GetShopsCompleted);
            
            shopService.GetShopsAsync();
        }

        void shopService_GetShopsCompleted(object sender, ShopService.GetShopsCompletedEventArgs e)
        {
            shopSelector.ItemsSource = e.Result;
        }

        private void navigate()
        {
            if (shopSelector.Text == "")
            {

                Popup popup = new Popup();
                ErrorMessageBox control = new ErrorMessageBox();
                control.btnOK.Click += (s, args) =>
                {
                    popup.IsOpen = false;
                    navigation.Value = 28;
                };


                popup.Child = control;
                popup.IsOpen = true;
                error.HorizontalAlignment = HorizontalAlignment.Left;
                error.Content = popup;
            }
            else
            {
                Shop shop = ((Shop)shopSelector.SelectedItem);
                (App.Current as App).Cart.Shop = shop;
                NavigationService.Navigate(new Uri("/TypeSelection.xaml?shopId=" + shop.ID, UriKind.Relative));
            }
        }
        private void navigation_ManipulationCompleted(object sender, ManipulationCompletedEventArgs e)
        {
            if(navigation.Value > 55) {
                navigate();
            }
            else if(navigation.Value < 5) {
                if(NavigationService.CanGoBack){
                    
                    NavigationService.GoBack();
                }
            }
            else{
                navigation.Value = 28;
            }
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            navigation.Value = 28;
        }

        private void shopSelector_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key.Equals(Key.Enter))
            {
                navigate();
            }
        }

        
    }
}