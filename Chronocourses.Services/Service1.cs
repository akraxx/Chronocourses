using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Chronocourses.DataAccess.Managers;

namespace Chronocourses.Services
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "Service1" à la fois dans le code et le fichier de configuration.
    public class Service1 : IService1
    {
        public string GetData(Chronocourses.Model.Marque value)
        {
            return string.Format("You entered: {0}", value.Nom);
        }

        public string Test()
        {
            return "loled";
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        public int[] GetShortestPath(List<Model.Product> lp)
        {
            //List<Path> lPath = new List<Path>();
            //Coordinates startPos;
            foreach (Model.Product p in lp){
                /*Coordinates coord = magasin.getCoordinates(p);
                 * Path minPath = grid.getShortestPath(startPos,coord);
                 * int nb_nghb = p.getNeighboursNumber();
                 * for( int i = 1; i < nb_nghb;i++){
                 *      Path path = grid.getShortestPath(startPos,p);
                 *      if(path.length <= minPath.length){ //Condition qui gère quel chemin on prend parmi les voisins -> Pas trés Dijkstra
                 *          minPath = path;
                 *      }
                 * }
                 * lPath.add(minPath);
                 * startPos = coord; //Le nouveau point de départ est le produit que l'on vient d'étudier.
                 * */
            }
            
            int[] r = { 0 , 2};
            return r;
        }

        public List<Model.Product> GetProducts()
        {
            return ProductManager.Instance.GetListProducts();
        }
    }
}
