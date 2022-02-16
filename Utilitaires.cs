using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace tp3
{
    class Utilitaires
    {
        public const string FICHIER_OBJETS_VOL = "../../../CieAirRelax.obj";

        public static void EnregistrerObjets(string nomFichier, SortedDictionary<int, Vol> ListeDictionaryVols)
        {
            //serialize
            using (Stream fic = File.Open(nomFichier, FileMode.Create))
            {
                var bformat = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

                bformat.Serialize(fic, ListeDictionaryVols);
            }
        }

        public static SortedDictionary<int, Vol> LireObjets(string fichier)
        {
            SortedDictionary<int, Vol> ListeDictionaryVols;
            //deserialize
            using (Stream fic = File.Open(fichier, FileMode.Open))
            {
                var bformat = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

                ListeDictionaryVols = (SortedDictionary<int, Vol>)bformat.Deserialize(fic);
            }

            return ListeDictionaryVols;
        }

        public static SortedDictionary<int, Vol> ChargerFichierObjet(string fichier)
        {
            //deserialize
            using (Stream fic = File.Open(fichier, FileMode.Open))
            {
                var bformat = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

                return (SortedDictionary<int, Vol>)bformat.Deserialize(fic);

            }
        }

    }
}
