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
    /// Logique d'interaction pour BrandControl.xaml
    /// </summary>
    public partial class BrandControl : UserControl
    {
        private BrandService.IBrandService brandService = new BrandService.BrandServiceClient();
        public BrandControl()
        {
            InitializeComponent();
            comboBox1.ItemsSource = brandService.GetBrands();            
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (textBox1.Text != "")
            {

                Brand brand = new Brand();
                brand.Name = textBox1.Text;
                brandService.AddBrand(brand);

                comboBox1.ItemsSource = brandService.GetBrands();
                MessageBox.Show(brand.Name + " has been added ");
            }
            else
            {
                MessageBox.Show(" Please fill name field to add brand. ");
            }
        }

        private void Del_Click(object sender, RoutedEventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                brandService.DeleteBrand(((Brand)comboBox1.SelectedItem));

                MessageBox.Show(((Brand)comboBox1.SelectedItem).Name + " has been deleted. ");
                comboBox1.ItemsSource = brandService.GetBrands();
            }
            else
            {
                MessageBox.Show(" Please select brand to delete. ");
            }
        }

        private void Modif_Click(object sender, RoutedEventArgs e)
        {
            if (textBox2.Text != "" && comboBox1.SelectedItem != null)
            {
                Brand brandModif = (Brand)comboBox1.SelectedItem;
                brandModif.Name = textBox2.Text;
                brandService.SaveBrand(brandModif);

                MessageBox.Show(((Brand)comboBox1.SelectedItem).Name + " has been modified ");
            }
            else
            {
                MessageBox.Show(" Please fill all fields to modify brand. ");
            }
        }
    }
}
