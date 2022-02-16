using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace tp3
{
    [Serializable]
    //classe vol
    public class Vol 
    {
        //attribut d'instance
        public static int nombreVols = 0;

        private int numVol;
        private string destination;
        //ca retourne le constructeur par default 
        public Date dateDepart;
        private int nombreRes;
        public Avion avionChoisi;
        public string ligne;

        //categorie de vol
        public char categorieVol;
        public VolPrive volPrive;
        public VolBasPrix volBasPrix;
        public VolCharter volCharter;
        public VolRegulier volRegulier;

        //constructeur d'initialisation

        //constructeur permettant d’initialiser les 4 attributs d’instances avec les valeurs reçues en paramètres
        public Vol(int numVol, string destination, Date dateDepart, int nombreRes, Avion avionChoisi, char categorieVol)
        {
            this.dateDepart = dateDepart;
            this.nombreRes = nombreRes;

            this.destination = destination;
            this.numVol = numVol;

            this.avionChoisi = avionChoisi;

            nombreVols++;

        }

        //declaration des methodes d'acces
        public static int getNbVol()
        {
            return nombreVols;
        }

        public string getDate()
        {

            return dateDepart.ToString();

        }

        public void setDate(Date datedepart)
        {

            this.dateDepart = datedepart;

        }


        public int NombreRes
        {
            get { return nombreRes; }
            set { nombreRes = value; }

        }

        public string Destination
        {
            get { return destination; }
            private set { destination = value; }

        }

        public int NumVol
        {
            get { return numVol; }
            private set { numVol = value; }

        }

        public void setAvionChoisi(Avion avionChoisi)
        {

            this.avionChoisi = avionChoisi;

        }

        public string getAvionChoisi()
        {

            return avionChoisi.ToString();

        }

        public override string ToString()
        {

             return numVol + ";" + destination + ";" + dateDepart + ";" + nombreRes + ";" + avionChoisi ;

        }


      

    }

}

