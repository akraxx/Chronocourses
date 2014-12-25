using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Chronocourses.DataAccess.Managers;
using System.Data.Services.Client;
using Chronocourses.Model;
using System.Collections.ObjectModel;
using System.ServiceModel.Activation;

namespace Chronocourses.Services
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "Service1" à la fois dans le code et le fichier de configuration.
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class ProductService : IProductService
    {
        public ObservableCollection<Model.Product> GetProducts()
        {
            List<Product> products = ProductManager.Instance.GetListProducts();
            ObservableCollection<Product> observableProducts = new ObservableCollection<Product>();
            foreach (Product product in products)
            {
                observableProducts.Add(product);
            }
            return observableProducts;
        }

        public Model.Product GetProduct(int id)
        {
            return ProductManager.Instance.GetProduct(id);
        }


        public int SaveProduct(Model.Product product)
        {
            return ProductManager.Instance.SaveProduct(product);
        }


        public int SaveProducts()
        {
            return ProductManager.Instance.SaveProducts();
        }


        public Product GetNextProduct(int lastId)
        {
            return ProductManager.Instance.GetNextProduct(lastId);
        }


        public int AddProduct(Product product)
        {
            return ProductManager.Instance.AddProduct(product);
        }


        public int DeleteProduct(Product product)
        {
            return ProductManager.Instance.DeleteProduct(product);
        }

        public List<List<int[]>> GetShortestPath(int shopID, int[] startPos, List<Product> lP)
        {
            Shop shop = ShopManager.Instance.GetShop(shopID);
            TrackableCollection<Entity> entities = shop.Entity;
            if (entities.Count < 1)
            {
                return null; //Rapide les courses quand il n'y a rien à  acheter.
            }
            GridUtilities grid = new GridUtilities(shop);
            List<List<int[]>> lPath = new List<List<int[]>>();
            foreach (Model.Product p in lP)
            {
                int[] coord = new int[2];
                foreach (Entity e in p.Entity)
                {
                    if (e.ShopID == shopID)
                    {
                        coord[0] = e.PositionX;
                        coord[1] = e.PositionY;
                    }
                }
                List<int[]> minPath = grid.getShortestPath(startPos, coord);
                int[] good_nghb = minPath[1];
                lPath.Add(minPath);
                startPos = good_nghb; //Le nouveau point de départ  est le produit que l'on vient d'étudier.*/
            }
            return lPath;
        }
    }
}
