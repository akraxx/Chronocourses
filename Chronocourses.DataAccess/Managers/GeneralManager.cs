using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chronocourses.Model;

namespace Chronocourses.DataAccess.Managers
{
    public class GeneralManager
    {
        private static GeneralManager instance;
        private static object sInstanceLocker = new object();

        /// <summary>
        /// Singleton permettant l'accés unique
        /// @remarks Utilisation du Context Static DataContext
        /// </summary>
        public static GeneralManager Instance
        {
            get
            {
                lock (sInstanceLocker)
                {
                    if (instance == null)
                    {
                        instance = new GeneralManager();
                    }
                    return instance;
                }
            }
        }

        /// <summary>
        /// Constructeur privé avec choix sur l'instance static ou pas
        /// </summary>
        /// <param name="withStaticDataContextInstance"></param>
        private GeneralManager()
        {

        }

        /// <summary>
        /// Retourne la liste des produits
        /// </summary>
        /// <returns></returns>
        public void SaveChanges()
        {
            ChronocoursesEntities entities = DataContext.ChronocoursesEntities;

            entities.SaveChanges();
        }
    }
}
