using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chronocourses.Model;
using System.Collections.ObjectModel;

namespace Chronocourses.DataAccess.Managers
{
    /// <summary>
    /// Classe d'accès aux données des Employés
    /// @remarks Gestion d'une instance static ou pas
    /// </summary>
    public class ShopManager
    {
        private static ShopManager instance;
        private static object sInstanceLocker = new object();

        /// <summary>
        /// Singleton permettant l'accés unique
        /// @remarks Utilisation du Context Static DataContext
        /// </summary>
        public static ShopManager Instance
        {
            get
            {
                lock (sInstanceLocker)
                {
                    if (instance == null)
                    {
                        instance = new ShopManager();
                    }
                    return instance;
                }
            }
        }


        /// <summary>
        /// Constructeur privé avec choix sur l'instance static ou pas
        /// </summary>
        /// <param name="withStaticDataContextInstance"></param>
        private ShopManager()
        {

        }

        public int moveEntityFromShop(Entity ent, int[] newPos, Shop shop)
        {
            using (ChronocoursesEntities entities = new ChronocoursesEntities())
            {
                ent.PositionX = newPos[0];
                ent.PositionY = newPos[1];
                entities.Entity.ApplyChanges(ent);
                return entities.SaveChanges();
            }

        }

        /// <summary>
        /// Retourne la liste des produits
        /// </summary>
        /// <returns></returns>
        public ObservableCollection<Shop> GetShops()
        {
            using (ChronocoursesEntities entities = new ChronocoursesEntities())
            {
                var requete = from shop in entities.Shop.Include("Entity").Include("Address")
                              select shop;
                return new ObservableCollection<Shop>(requete.ToList<Shop>());
            }
        }

        /// <summary>
        /// Retourne un produit par son id
        /// </summary>
        /// <returns></returns>
        public Shop GetShop(int id)
        {
            using (ChronocoursesEntities entities = new ChronocoursesEntities())
            {
                Shop s = (from shop in entities.Shop.Include("Entity").Include("Address")
                            where shop.ID.Equals(id)
                            select shop).FirstOrDefault();

                if (s != null)
                {
                    return s;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("invalid id of product");
                }
            }
        }

        /// <summary>
        /// Retourne un produit par son id
        /// </summary>
        /// <returns></returns>
        public int SaveShop(Shop shop)
        {
            using (ChronocoursesEntities entities = new ChronocoursesEntities())
            {
                entities.Shop.ApplyChanges(shop);
                return entities.SaveChanges();
            }

        }

        /// <summary>
        /// Retourne un produit par son id
        /// </summary>
        /// <returns></returns>
        public int AddShop(Shop shop)
        {
            using (ChronocoursesEntities entities = new ChronocoursesEntities())
            {
                entities.Shop.AddObject(shop);
                return entities.SaveChanges();
            }

        }

        /// <summary>
        /// Retourne un produit par son id
        /// </summary>
        /// <returns></returns>
        public int DeleteShop(Shop shopToDel)
        {
            using (ChronocoursesEntities entities = new ChronocoursesEntities())
            {
                var del = (from shop in entities.Shop.Include("Address").Include("Entity")
                           where shop.ID.Equals(shopToDel.ID)
                           select shop).FirstOrDefault();

                entities.Shop.DeleteObject(del);
                return entities.SaveChanges();
            }

        }

        public Entity GetEntityByPosition(int x, int y, Shop shop)
        {
            using (ChronocoursesEntities entities = new ChronocoursesEntities())
            {
                var request = (from entity in entities.Entity.Include("Shop").Include("Product")
                                where entity.ShopID.Equals(shop.ID)
                                && entity.PositionX.Equals(x)
                                && entity.PositionY.Equals(y)
                                select entity).FirstOrDefault();

                return request;
            }
        }

        public ObservableCollection<Product> GetProductsByProductType(int typeProductID, int shopID)
        {
            using (ChronocoursesEntities entities = new ChronocoursesEntities())
            {
                var request = (from ent in entities.Entity.Include("Shop").Include("Product")
                               where ent.ShopID.Equals(shopID)
                               select ent.Product);

                List<Product> productList = new List<Product>();
                foreach (TrackableCollection<Product> products in request)
                {
                    productList.AddRange(products.Where(prod => prod.TypeProductID.Equals(typeProductID)));
                }

                return new ObservableCollection<Product>(productList);
            }
        }

        public Entity GetStartPoint(int shopID)
        {
            using (ChronocoursesEntities entities = new ChronocoursesEntities())
            {
                var request = (from ent in entities.Entity.Include("Shop").Include("Product")
                               where ent.ShopID.Equals(shopID) && ent.Label.Equals("start")
                               select ent).FirstOrDefault();
                return request;
            }
        }
    }
}
