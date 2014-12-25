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
    public class BrandManager
    {
        private static BrandManager instance;
        private static object sInstanceLocker = new object();

        /// <summary>
        /// Singleton permettant l'accés unique
        /// @remarks Utilisation du Context Static DataContext
        /// </summary>
        public static BrandManager Instance
        {
            get
            {
                lock (sInstanceLocker)
                {
                    if (instance == null)
                    {
                        instance = new BrandManager();
                    }
                    return instance;
                }
            }
        }


        /// <summary>
        /// Constructeur privé avec choix sur l'instance static ou pas
        /// </summary>
        /// <param name="withStaticDataContextInstance"></param>
        private BrandManager()
        {

        }

        /// <summary>
        /// Retourne la liste des produits
        /// </summary>
        /// <returns></returns>
        public ObservableCollection<Brand> GetListBrands()
        {
            using (ChronocoursesEntities entities = new ChronocoursesEntities())
            {
                var requete = from marque in entities.Brand
                              select marque;
                return new ObservableCollection<Brand>(requete.ToList<Brand>());
            }
        }

        /// <summary>
        /// Retourne un produit par son id
        /// </summary>
        /// <returns></returns>
        public Brand GetBrand(int id)
        {
            using (ChronocoursesEntities entities = new ChronocoursesEntities())
            {
                Brand s = (from brand in entities.Brand
                          where brand.ID.Equals(id)
                          select brand).FirstOrDefault();

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
        public int SaveBrand(Brand brand)
        {
            using (ChronocoursesEntities entities = new ChronocoursesEntities())
            {
                entities.Brand.ApplyChanges(brand);
                return entities.SaveChanges();
            }

        }

        /// <summary>
        /// Retourne un produit par son id
        /// </summary>
        /// <returns></returns>
        public int AddBrand(Brand brand)
        {
            using (ChronocoursesEntities entities = new ChronocoursesEntities())
            {
                entities.Brand.AddObject(brand);
                return entities.SaveChanges();
            }

        }

        /// <summary>
        /// Retourne un produit par son id
        /// </summary>
        /// <returns></returns>
        public int DeleteBrand(Brand brandToDel)
        {
            using (ChronocoursesEntities entities = new ChronocoursesEntities())
            {
                var del = (from brand in entities.Brand
                           where brand.ID.Equals(brandToDel.ID)
                           select brand).FirstOrDefault();

                entities.Brand.DeleteObject(del);
                return entities.SaveChanges();
            }

        }

    }
}
