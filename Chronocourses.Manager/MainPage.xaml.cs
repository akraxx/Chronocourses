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

namespace Chronocourses.Manager
{
    /// <summary>
    /// Logique d'interaction pour MainPage.xaml
    /// </summary>
    public partial class MainPage : Window
    {
        public MainPage()
        {
            InitializeComponent();
        }

        #region Product
        private void ProductCreation_Click(object sender, RoutedEventArgs e)
        {
            contentControl1.Content = new ProductControl(0).Content;
        }
        private void ProductModification_Click(object sender, RoutedEventArgs e)
        {
            contentControl1.Content = new ProductControl(1).Content;
        }
        #endregion Product

        #region Categories

        private void Categorie_Click(object sender, RoutedEventArgs e)
        {
            contentControl1.Content = new Categorie().Content;
        }
        #endregion Categories

        #region Brands
        private void Brand_Click(object sender, RoutedEventArgs e)
        {
            contentControl1.Content = new BrandControl().Content;
        }
        #endregion Brands

        #region Positionning
        private void Map_Click(object sender, RoutedEventArgs e)
        {
            contentControl1.Content = new Map().Content;
        }
        #endregion Positionning


    }
}
