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
    public class TypeProductService : ITypeProductService
    {
        public ObservableCollection<TypeProduct> GetTypeProducts()
        {
            return TypeProductManager.Instance.GetTypeProducts();
        }

        public ObservableCollection<Product> GetProductsByTypeProduct(int typeProductId)
        {
            return TypeProductManager.Instance.GetProductsByTypeProduct(typeProductId);
        }

        public TypeProduct GetTypeProduct(int id)
        {
            return TypeProductManager.Instance.GetTypeProduct(id);
        }

        public int SaveTypeProduct(TypeProduct typeProduct)
        {
            return TypeProductManager.Instance.SaveTypeProduct(typeProduct);
        }

        public int AddTypeProduct(TypeProduct typeProduct)
        {
            return TypeProductManager.Instance.AddTypeProduct(typeProduct);
        }

        public int DeleteTypeProduct(TypeProduct typeProduct)
        {
            return TypeProductManager.Instance.DeleteTypeProduct(typeProduct);
        }
    }
}
