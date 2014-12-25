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
    public interface ITypeProductService
    {
        [OperationContract]
        ObservableCollection<TypeProduct> GetTypeProducts();

        [OperationContract]
        ObservableCollection<Product> GetProductsByTypeProduct(int typeProductId);

        [OperationContract]
        TypeProduct GetTypeProduct(int id);

        [OperationContract]
        int SaveTypeProduct(TypeProduct typeProduct);

        [OperationContract]
        int AddTypeProduct(TypeProduct typeProduct);

        [OperationContract]
        int DeleteTypeProduct(TypeProduct typeProduct);
    }
}
