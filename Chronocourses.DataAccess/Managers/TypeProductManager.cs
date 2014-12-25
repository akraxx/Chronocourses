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
    public class TypeProductManager
    {
        private static TypeProductManager instance;
        private static object sInstanceLocker = new object();

        /// <summary>
        /// Singleton permettant l'accés unique
        /// @remarks Utilisation du Context Static DataContext
        /// </summary>
        public static TypeProductManager Instance
        {
            get
            {
                lock (sInstanceLocker)
                {
                    if (instance == null)
                    {
                        instance = new TypeProductManager();
                    }
                    return instance;
                }
            }
        }


        /// <summary>
        /// Constructeur privé avec choix sur l'instance static ou pas
        /// </summary>
        /// <param name="withStaticDataContextInstance"></param>
        private TypeProductManager()
        {

        }

        /// <summary>
        /// Retourne la liste des produits
        /// </summary>
        /// <returns></returns>
        public ObservableCollection<TypeProduct> GetTypeProducts()
        {
            using (ChronocoursesEntities entities = new ChronocoursesEntities())
            {
                var requete = from typeProduct in entities.TypeProduct.Include("Product")
                              select typeProduct;
                return new ObservableCollection<TypeProduct>(requete.ToList<TypeProduct>());
            }
        }

        /// <summary>
        /// Retourne la liste des produits
        /// </summary>
        /// <returns></returns>
        public ObservableCollection<Product> GetProductsByTypeProduct(int typeProductID)
        {
            using (ChronocoursesEntities entities = new ChronocoursesEntities())
            {
                var requete = (from typeProduct in entities.TypeProduct.Include("Product")
                               where typeProduct.ID.Equals(typeProductID)
                              select typeProduct.Product).FirstOrDefault();
                return new ObservableCollection<Product>(requete);
            }
        }

        /// <summary>
        /// Retourne un produit par son id
        /// </summary>
        /// <returns></returns>
        public TypeProduct GetTypeProduct(int id)
        {
            using (ChronocoursesEntities entities = new ChronocoursesEntities())
            {
                TypeProduct s = (from shop in entities.TypeProduct.Include("Product")
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
        public int SaveTypeProduct(TypeProduct typeProduct)
        {
            using (ChronocoursesEntities entities = new ChronocoursesEntities())
            {
                entities.TypeProduct.ApplyChanges(typeProduct);
                return entities.SaveChanges();
            }

        }

        /// <summary>
        /// Retourne un produit par son id
        /// </summary>
        /// <returns></returns>
        public int AddTypeProduct(TypeProduct typeProduct)
        {
            using (ChronocoursesEntities entities = new ChronocoursesEntities())
            {
                entities.TypeProduct.AddObject(typeProduct);
                return entities.SaveChanges();
            }

        }

        /// <summary>
        /// Retourne un produit par son id
        /// </summary>
        /// <returns></returns>
        public int DeleteTypeProduct(TypeProduct typeProductToDel)
        {
            using (ChronocoursesEntities entities = new ChronocoursesEntities())
            {
                var del = (from shop in entities.TypeProduct
                           where shop.ID.Equals(typeProductToDel.ID)
                           select shop).FirstOrDefault();

                entities.TypeProduct.DeleteObject(del);
                return entities.SaveChanges();
            }

        }

    }
}
