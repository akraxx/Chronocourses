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
    public class ProductManager
    {
        private static ProductManager instance;
        private static object sInstanceLocker = new object();

        /// <summary>
        /// Singleton permettant l'accés unique
        /// @remarks Utilisation du Context Static DataContext
        /// </summary>
        public static ProductManager Instance
        {
            get
            {
                lock (sInstanceLocker)
                {
                    if (instance == null)
                    {
                        instance = new ProductManager();
                    }
                    return instance;
                }
            }
        }


        /// <summary>
        /// Constructeur privé avec choix sur l'instance static ou pas
        /// </summary>
        /// <param name="withStaticDataContextInstance"></param>
        private ProductManager()
        {

        }

        /// <summary>
        /// Retourne la liste des produits
        /// </summary>
        /// <returns></returns>
        public List<Product> GetListProducts()
        {
            using (ChronocoursesEntities entities = new ChronocoursesEntities())
            {
                var requete = from employee in entities.Product.Include("Brand").Include("TypeProduct").Include("Entity")
                              select employee;
                return requete.ToList<Product>();
            }
        }

        /// <summary>
        /// Retourne un produit par son id
        /// </summary>
        /// <returns></returns>
        public Product GetProduct(int id)
        {
            using (ChronocoursesEntities entities = new ChronocoursesEntities())
            {
                Product prod = (from product in entities.Product.Include("Brand").Include("TypeProduct").Include("Entity")
                                where product.ID.Equals(id)
                                select product).FirstOrDefault();

                if (prod != null)
                {
                    return prod;
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
        public Product GetNextProduct(int lastId)
        {
            using (ChronocoursesEntities entities = new ChronocoursesEntities())
            {
                Product prod = (from product in entities.Product.Include("Brand").Include("TypeProduct").Include("Entity")
                                where product.ID > lastId
                                orderby product.ID
                                select product).FirstOrDefault();

                return prod;
            }
        }

        /// <summary>
        /// Retourne un produit par son id
        /// </summary>
        /// <returns></returns>
        public int SaveProduct(Product product)
        {
            using (ChronocoursesEntities entities = new ChronocoursesEntities())
            {
                entities.Product.ApplyChanges(product);
                return entities.SaveChanges();
            }

        }

        /// <summary>
        /// Retourne un produit par son id
        /// </summary>
        /// <returns></returns>
        public int AddProduct(Product product)
        {
            using (ChronocoursesEntities entities = new ChronocoursesEntities())
            {
                entities.Product.AddObject(product);
                return entities.SaveChanges();
            }

        }

        /// <summary>
        /// Retourne un produit par son id
        /// </summary>
        /// <returns></returns>
        public int DeleteProduct(Product productToDel)
        {
            using (ChronocoursesEntities entities = new ChronocoursesEntities())
            {
                var del = (from product in entities.Product.Include("Brand").Include("TypeProduct").Include("Entity")
                           where product.ID.Equals(productToDel.ID)
                           select product).FirstOrDefault();

                entities.Product.DeleteObject(del);
                return entities.SaveChanges();
            }

        }

        /// <summary>
        /// Retourne un produit par son id
        /// </summary>
        /// <returns></returns>
        public int SaveProducts()
        {
            using (ChronocoursesEntities entities = new ChronocoursesEntities())
            {
                return entities.SaveChanges();
            }

        }


    }
}
