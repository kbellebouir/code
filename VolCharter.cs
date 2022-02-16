using System;
using System.Collections.Generic;
using System.Text;

namespace tp3
{
    [Serializable]
    public class VolCharter : Vol
    {

        private string repas;
        private string resSiege;
        private string servBar;
        private string systDiver;
        private string servPayant;
        private string priseAlim;
        private string wifi;
        public string message;

        public VolCharter(int numVol, string destination, Date dateDepart, int nombreRes, Avion avionChoisi, char categorieVol) : base(numVol, destination, dateDepart, nombreRes, avionChoisi, categorieVol)
        {
            repas = "oui";
            resSiege = "non";
            servBar = "non";
            systDiver = "oui";
            servPayant = "non";
            priseAlim = "oui";
            wifi = "oui";

            message = this.repas + ";" + this.resSiege + ";" + this.servBar + ";" + this.systDiver + ";" + this.servPayant + ";" + this.priseAlim + ";" + this.wifi;

        }

        public override string ToString()
        {

            return base.NumVol + ";" + base.Destination + ";" + base.dateDepart + ";" + base.NombreRes + ";" + avionChoisi + ";" + this.message;

        }

    }
}
