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
using System.Threading;

namespace Chronocourses.Client
{
    public partial class MainPage : PhoneApplicationPage
    {
        
        public MainPage()
        {

            InitializeComponent();
            GridCardView.Children.Add(new CartView());

        }

                
        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {
            base.OnBackKeyPress(e);
        }

        private void Button_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/ShopSelection.xaml", UriKind.Relative));
        }

        
    }
}