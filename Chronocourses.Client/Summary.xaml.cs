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
using Microsoft.Phone.Shell;

namespace Chronocourses.Client
{
    public partial class Summary : PhoneApplicationPage
    {
        public Summary()
        {
            InitializeComponent();

            GridCardView.Children.Add(new CartView());

            Cart cart = (App.Current as App).Cart;
            commandLines.ItemsSource = cart.CommandLines;
            if (cart.Shop == null)
            {
                getPathButton.IsEnabled = false;
                removeLineButton.IsEnabled = false;
                clearButton.IsEnabled = false;
            }
            else
            {
                shopText.Text = cart.Shop.Name;
            }
        }

        private void getPathButton_Click(object sender, RoutedEventArgs e)
        {
            
            /*ProgressIndicator progressIndicator = new ProgressIndicator()
            {

                IsVisible = true,
                IsIndeterminate = true,

                Text = "Creating path ..."
            };

            SystemTray.SetProgressIndicator(this, progressIndicator);*/

            NavigationService.Navigate(new Uri("/Map.xaml", UriKind.Relative));
        }

        private void clearButton_Click(object sender, RoutedEventArgs e)
        {
            (App.Current as App).Cart.Clear();
            commandLines.ItemsSource = null;
            commandLines.ItemsSource = (App.Current as App).Cart.CommandLines;
        }

        private void removeLineButton_Click(object sender, RoutedEventArgs e)
        {
            if (commandLines.SelectedItem != null)
            {
                CommandLine commandLine = (CommandLine)commandLines.SelectedItem;
                (App.Current as App).Cart.RemoveProduct(commandLine.Product);
                commandLines.ItemsSource = null;
                commandLines.ItemsSource = (App.Current as App).Cart.CommandLines;
            }
        }
    }
}