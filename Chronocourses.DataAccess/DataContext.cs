using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chronocourses.Model;
using System.Configuration;


namespace Chronocourses.DataAccess
{
    /// <summary>
    /// Classe DataContext
    /// @remarks Gestion d'une instance static ou pas
    /// </summary>
    public class DataContext
    {
        private static ChronocoursesEntities chronocoursesEntities;
        internal static ChronocoursesEntities ChronocoursesEntities
        {
            get { return DataContext.chronocoursesEntities; }
            set { DataContext.chronocoursesEntities = value; }
        }

        static DataContext()
        {
            DataContext.ChronocoursesEntities = new ChronocoursesEntities(ConfigurationManager.ConnectionStrings["ChronocoursesEntities"].ConnectionString);
            DataContext.ChronocoursesEntities.ContextOptions.LazyLoadingEnabled = true;
            DataContext.ChronocoursesEntities.ContextOptions.ProxyCreationEnabled = true;
        }

        public static void Save()
        {
            DataContext.ChronocoursesEntities.SaveChanges();
        }

    }
}
