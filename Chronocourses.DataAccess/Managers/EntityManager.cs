using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chronocourses.Model;
using System.Data.Objects;
using System.Collections.ObjectModel;

namespace Chronocourses.DataAccess.Managers
{
    /// <summary>
    /// Classe d'accès aux données des Employés
    /// @remarks Gestion d'une instance static ou pas
    /// </summary>
    public class EntityManager
    {
        private static EntityManager instance;
        private static object sInstanceLocker = new object();

        /// <summary>
        /// Singleton permettant l'accés unique
        /// @remarks Utilisation du Context Static DataContext
        /// </summary>
        public static EntityManager Instance
        {
            get
            {
                lock (sInstanceLocker)
                {
                    if (instance == null)
                    {
                        instance = new EntityManager();
                    }
                    return instance;
                }
            }
        }


        /// <summary>
        /// Constructeur privé avec choix sur l'instance static ou pas
        /// </summary>
        /// <param name="withStaticDataContextInstance"></param>
        private EntityManager()
        {

        }

        /// <summary>
        /// Retourne la liste des produits
        /// </summary>
        /// <returns></returns>
        public int addProductToContainer(Product product, Entity ent)
        {
            using (ChronocoursesEntities entities = new ChronocoursesEntities())
            {
                ent.Product.Add(product);
                entities.Entity.ApplyChanges(ent);
                return entities.SaveChanges();
            }
        }

        /// <summary>
        /// Retourne la liste des produits
        /// </summary>
        /// <returns></returns>
        public List<Entity> GetListEntitys()
        {
            using (ChronocoursesEntities entities = new ChronocoursesEntities())
            {
                var requete = from employee in entities.Entity
                              select employee;
                return requete.ToList<Entity>();
            }
        }

        public int setContainer(Entity ent, bool container)
        {
            using (ChronocoursesEntities entities = new ChronocoursesEntities())
            {
                ent.Container = container;
                entities.Entity.ApplyChanges(ent);
                return entities.SaveChanges();
            }
        }

        /// <summary>
        /// Retourne un produit par son id
        /// </summary>
        /// <returns></returns>
        public Entity GetEntity(int id)
        {
            using (ChronocoursesEntities entities = new ChronocoursesEntities())
            {
                Entity prod = (from Entity in entities.Entity.Include("Product")
                                where Entity.ID.Equals(id)
                                select Entity).FirstOrDefault();

                if (prod != null)
                {
                    return prod;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("invalid id of Entity");
                }
            }
        }

        /// <summary>
        /// Retourne un produit par son id
        /// </summary>
        /// <returns></returns>
        public Entity GetNextEntity(int lastId)
        {
            using (ChronocoursesEntities entities = new ChronocoursesEntities())
            {
                Entity prod = (from Entity in entities.Entity
                                where Entity.ID > lastId
                                orderby Entity.ID
                                select Entity).FirstOrDefault();

                return prod;
            }
        }

        /// <summary>
        /// Retourne un produit par son id
        /// </summary>
        /// <returns></returns>
        public void SaveEntity(Entity Entity)
        {
            using (ChronocoursesEntities entities = new ChronocoursesEntities())
            {
                entities.Entity.ApplyChanges(Entity);
                entities.SaveChanges();
            }

        }

        /// <summary>
        /// Retourne un produit par son id
        /// </summary>
        /// <returns></returns>
        public int AddEntity(Entity Entity)
        {
            using (ChronocoursesEntities entities = new ChronocoursesEntities())
            {
                entities.Entity.AddObject(Entity);
                return entities.SaveChanges();
            }

        }

        /// <summary>
        /// Retourne un produit par son id
        /// </summary>
        /// <returns></returns>
        public int DeleteEntity(Entity EntityToDel)
        {
            using (ChronocoursesEntities entities = new ChronocoursesEntities())
            {
                var del = (from Entity in entities.Entity
                           where Entity.ID.Equals(EntityToDel.ID)
                           select Entity).FirstOrDefault();

                entities.Entity.DeleteObject(del);
                return entities.SaveChanges();
            }

        }

        /// <summary>
        /// Retourne un produit par son id
        /// </summary>
        /// <returns></returns>
        public void SaveEntitys()
        {
            using (ChronocoursesEntities entities = new ChronocoursesEntities())
            {
                entities.SaveChanges();
            }

        }
        public int RemoveProductFromContainer(Product product, Entity ent){
            using (ChronocoursesEntities entities = new ChronocoursesEntities())
            {
                foreach (Product p in ent.Product)
                {
                    if (p.ID == product.ID)
                    {
                        ent.Product.Remove(p);
                        break;
                    }
                }
                entities.Entity.ApplyChanges(ent);
                return entities.SaveChanges();

            }
        }

        public int RemoveAllProductsFromContainer(Entity ent)
        {
            using (ChronocoursesEntities entities = new ChronocoursesEntities())
            {
                ent.Product.Clear();
                entities.Entity.ApplyChanges(ent);
                return entities.SaveChanges();
            }
        }

    }
}
