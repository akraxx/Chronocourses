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
    public interface IProductService
    {
        [OperationContract]
        ObservableCollection<Product> GetProducts();

        [OperationContract]
        Product GetProduct(int id);

        [OperationContract]
        int SaveProduct(Product product);

        [OperationContract]
        int AddProduct(Product product);

        [OperationContract]
        int DeleteProduct(Product product);

        [OperationContract]
        int SaveProducts();

        [OperationContract]
        List<List<int[]>> GetShortestPath(int shopID, int[] startPos, List<Product> lP);

    }
}
