using System;
using System.Collections.Generic;
using System.Linq;
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
    public partial class CartView : UserControl
    {
        public Cart Cart { get; set; }

        public CartView()
        {
            Cart = (App.Current as App).Cart;

            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            (Application.Current.RootVisual as PhoneApplicationFrame).Navigate(new Uri("/Summary.xaml", System.UriKind.Relative));
        }
    }
}
