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
    public class EntityService : IEntityService
    {
        public ObservableCollection<Model.Entity> GetEntitys()
        {
            List<Entity> Entitys = EntityManager.Instance.GetListEntitys();
            ObservableCollection<Entity> observableEntitys = new ObservableCollection<Entity>();
            foreach (Entity Entity in Entitys)
            {
                observableEntitys.Add(Entity);
            }
            return observableEntitys;
        }

        public int addProductToContainer(Product product, Entity ent)
        {
            return EntityManager.Instance.addProductToContainer(product, ent);
        }

        public Model.Entity GetEntity(int id)
        {
            return EntityManager.Instance.GetEntity(id);
        }


        public void SaveEntity(Model.Entity Entity)
        {
            EntityManager.Instance.SaveEntity(Entity);
        }

        public int setContainer(Entity ent, bool container)
        {
            return EntityManager.Instance.setContainer(ent, container);
        }


        public void SaveEntitys()
        {
            EntityManager.Instance.SaveEntitys();
        }


        public Entity GetNextEntity(int lastId)
        {
            return EntityManager.Instance.GetNextEntity(lastId);
        }


        public int AddEntity(Entity Entity)
        {
            return EntityManager.Instance.AddEntity(Entity);
        }


        public int DeleteEntity(Entity Entity)
        {
            return EntityManager.Instance.DeleteEntity(Entity);
        }
        public int RemoveProductFromContainer(Product product, Entity ent){
            return EntityManager.Instance.RemoveProductFromContainer(product,ent);
        }

        public int RemoveAllProductsFromContainer(Entity ent){
            return EntityManager.Instance.RemoveAllProductsFromContainer(ent);
        }
    }
}
