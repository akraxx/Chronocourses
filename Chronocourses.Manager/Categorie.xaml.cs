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
    /// Logique d'interaction pour Categorie.xaml
    /// </summary>
    public partial class Categorie : UserControl
    {
        private TypeProductService.ITypeProductService categorieService = new TypeProductService.TypeProductServiceClient();

        public Categorie()
        {
            InitializeComponent();
            comboBox1.ItemsSource = categorieService.GetTypeProducts();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (textBox1.Text != "")
            {
                TypeProduct type = new TypeProduct();
                type.Label = textBox1.Text;
                categorieService.AddTypeProduct(type);

                comboBox1.ItemsSource = categorieService.GetTypeProducts();
                MessageBox.Show(type.Label + " has been added ");
            }
            else
            {
                MessageBox.Show("Please fill product type field to add category. ");
            }
        }

        private void Del_Click(object sender, RoutedEventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                categorieService.DeleteTypeProduct(((TypeProduct)comboBox1.SelectedItem));

                MessageBox.Show(((TypeProduct)comboBox1.SelectedItem).Label + " has been deleted ");
                comboBox1.ItemsSource = categorieService.GetTypeProducts();
            }
            else
            {
                MessageBox.Show(" Please select a product type to delete. ");
            }
        }

        private void Modif_Click(object sender, RoutedEventArgs e)
        {
            if (textBox2.Text != "" && comboBox1.SelectedItem != null)
            {
                TypeProduct brandModif = (TypeProduct)comboBox1.SelectedItem;
                brandModif.Label = textBox2.Text;
                categorieService.SaveTypeProduct(brandModif);

                MessageBox.Show(((TypeProduct)comboBox1.SelectedItem).Label + " has been modified ");
            }
            else
            {
                MessageBox.Show(" Please fill all fields to modify product type. ");
            }
        }
    }
}
