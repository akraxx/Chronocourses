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
    public interface IEntityService
    {
        [OperationContract]
        ObservableCollection<Entity> GetEntitys();

        [OperationContract]
        int addProductToContainer(Product product, Entity ent);

        [OperationContract]
        int RemoveProductFromContainer(Product product, Entity ent);

        [OperationContract]
        int RemoveAllProductsFromContainer(Entity ent);

        [OperationContract]
        int setContainer(Entity ent, bool container);

        [OperationContract]
        Entity GetEntity(int id);

        [OperationContract]
        void SaveEntity(Entity Entity);

        [OperationContract]
        int AddEntity(Entity Entity);

        [OperationContract]
        int DeleteEntity(Entity Entity);

        [OperationContract]
        void SaveEntitys();

    }
}
