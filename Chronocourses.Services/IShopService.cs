using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Chronocourses.Model;
using System.Data.Services.Client;
using System.Collections.ObjectModel;
using System.ServiceModel.Activation;

namespace Chronocourses.Services
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom d'interface "IService1" à la fois dans le code et le fichier de configuration.
    [ServiceContract]
    public interface IShopService
    {
        [OperationContract]
        ObservableCollection<Shop> GetShops();

        [OperationContract]
        Shop GetShop(int id);

        [OperationContract]
        int SaveShop(Shop shop);

        [OperationContract]
        int moveEntityFromShop(Entity ent, int[] newPos, Shop shop);

        [OperationContract]
        int AddShop(Shop shop);

        [OperationContract]
        int DeleteShop(Shop shop);

        [OperationContract]
        Entity GetEntityByPosition(int x, int y, Shop shop);

        [OperationContract]
        ObservableCollection<Product> GetProductsByProductType(int productTypeId, int shopId);

        [OperationContract]
        Entity GetStartPosition(int ShopID);

    }
}
