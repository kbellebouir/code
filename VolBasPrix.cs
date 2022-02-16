using System;
using System.Collections.Generic;
using System.Text;

namespace tp3
{
    [Serializable]
    public class VolBasPrix : Vol
    {
        private string repas;
        private string resSiege;
        private string servBar;
        private string systDiver;
        private string servPayant;
        private string priseAlim;
        private string wifi;
        public string message;

        public VolBasPrix(int numVol, string destination, Date dateDepart, int nombreRes, Avion avionChoisi, char categorieVol) : base(numVol, destination, dateDepart, nombreRes, avionChoisi, categorieVol)
        {
            repas = "non";
            resSiege = "non";
            servBar = "non";
            systDiver = "non";
            servPayant = "oui";
            priseAlim = "non";
            wifi = "non";
            message = this.repas + ";" + this.resSiege + ";" + this.servBar + ";" + this.systDiver + ";" + this.servPayant + ";" + this.priseAlim + ";" + this.wifi;

        }

        public override string ToString()
        {

            return base.NumVol + ";" + base.Destination + ";" + base.dateDepart + ";" + base.NombreRes + ";" + avionChoisi + ";" + this.message;

        }

    }
}
