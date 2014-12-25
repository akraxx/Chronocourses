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
using System.Collections.Generic;
using Chronocourses.Client.ProductService;
using System.ComponentModel;

namespace Chronocourses.Client
{
    public class Cart : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        private List<CommandLine> commandLines = new List<CommandLine>();

        public List<CommandLine> CommandLines
        {
            get
            {
                return commandLines;
            }
        }

        private ShopService.Shop _shop;
        public ShopService.Shop Shop
        {
            get
            {
                return _shop;
            }
            set
            {
                _shop = value;
                Clear();
            }
        }

        private int _totalArticles;

        public int TotalArticles
        {
            get { return _totalArticles; }
            set
            {
                if (value != _totalArticles)
                {
                    _totalArticles = value;
                    OnPropertyChanged("TotalArticles");
                }
            }
        }

        private double _totalPrice;

        public double TotalPrice
        {
            get { return _totalPrice; }
            set
            {
                if (value != _totalPrice)
                {
                    _totalPrice = value;
                    OnPropertyChanged("TotalPrice");
                }
            }
        }

        // Create the OnPropertyChanged method to raise the event
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        public Cart()
        {
            Shop = null;
            _totalArticles = 0;
            _totalPrice = 0;
        }

        private CommandLine GetCommandLine(Product product)
        {

            foreach (CommandLine commandLine in commandLines)
            {
                if (commandLine.Product.ID.Equals(product.ID))
                {
                    return commandLine;
                }
            }

            return null;
        }
        public void AddProduct(Product product, int quantity)
        {
            CommandLine commandLine = GetCommandLine(product);
            if (commandLine != null)
            {
                commandLine.UpdateQuantity(quantity);
            }
            else
            {
                commandLine = new CommandLine(product, quantity);
                commandLines.Add(commandLine);
            }

            TotalArticles += quantity;
            TotalPrice += (product.Price * quantity);
            
        }

        public void RemoveProduct(Product product)
        {
            CommandLine commandLine = GetCommandLine(product);
            if (commandLine != null)
            {
                TotalArticles -= commandLine.Quantity;
                TotalPrice -= (product.Price * commandLine.Quantity);

                commandLines.Remove(commandLine);
            }
        }

        public void Clear()
        {
            CommandLines.Clear();
            TotalArticles = 0;
            TotalPrice = 0;
        }
    }
}
