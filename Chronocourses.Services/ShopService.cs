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
    public class ShopService : IShopService
    {

        public ObservableCollection<Shop> GetShops()
        {
            return ShopManager.Instance.GetShops();
        }

        public Shop GetShop(int id)
        {
            return ShopManager.Instance.GetShop(id);
        }

        public int SaveShop(Shop shop)
        {
            return ShopManager.Instance.SaveShop(shop);
        }

        public int AddShop(Shop shop)
        {
            return ShopManager.Instance.AddShop(shop);
        }

        public int moveEntityFromShop(Entity ent, int[] newPos, Shop shop)
        {
            return ShopManager.Instance.moveEntityFromShop(ent, newPos, shop);
        }

        public int DeleteShop(Shop shop)
        {
            return ShopManager.Instance.DeleteShop(shop);
        }

        public Entity GetEntityByPosition(int x, int y, Shop shop)
        {
            return ShopManager.Instance.GetEntityByPosition(x, y, shop);
        }

        public ObservableCollection<Product> GetProductsByProductType(int productTypeId, int shopId)
        {
            return ShopManager.Instance.GetProductsByProductType(productTypeId, shopId);
        }


        public Entity GetStartPosition(int ShopID)
        {
            return ShopManager.Instance.GetStartPoint(ShopID);
        }

    }
}
