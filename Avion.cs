using System;
using System.Collections.Generic;
using System.Text;

namespace tp3
{
    [Serializable]
    public class Avion
    {
        public int avionID ;
        public string type { get; private set; }
        public int nbPlace { get; private set; }
        public string rayonAction { get; private set; }
        public string typeAvion { get; private set; }
        public string classe { get; private set; }

        public Avion(int avionID)
        {
            switch (avionID)
            {
                case 1:
                    type = "Boeing 747";
                    nbPlace = 340 ;
                    rayonAction = "court-courrier";
                    typeAvion = "Avions ultra légers";
                    classe = "classe affaires";
                    break;
                case 2:
                    type = "Gulfstream V";
                    nbPlace = 125;
                    rayonAction = "long-courrier";
                    typeAvion = "Avions légers";
                    classe = "première classe";
                    break;
                case 3:
                    type = "Airbus A220";
                    nbPlace = 180;
                    rayonAction = "moyen-courrier";
                    typeAvion = "Avions ultra légers";
                    classe = "classe économique";
                    break;
                case 4:
                    type = "Bombardier CRJ100";
                    nbPlace = 25;
                    rayonAction = "court-courrier";
                    typeAvion = "Avions d'affaire";
                    classe = "classe économique";
                    break;
                case 5:
                    type = "Airbus A320";
                    nbPlace = 250;
                    rayonAction = "long-courrier";
                    typeAvion = "Avions légers";
                    classe = "classe affaires";
                    break;

            }


        }

        public override string ToString()
        {
            return this.type + ";" + this.nbPlace + ";" + this.rayonAction + ";" + this.typeAvion + ";" + this.classe;
        }

    }
}
