using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Chronocourses.Client.ProductService;

namespace Chronocourses.Client
{
    public class CommandLine
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public double TotalPrice
        {
            get
            {
                return Product.Price * Quantity;
            }
        }

        public CommandLine(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;
        }

        public void UpdateQuantity(int quantity)
        {
            Quantity += quantity;
        }
    }
}
