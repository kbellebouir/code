using System;
using System.Collections.Generic;
using System.Text;

namespace tp3
{
    [Serializable]
    //classe Date (avec get et ToString)
    public class Date
    {
        //attribut
        public int Jour { get; private set; }
        public int Mois { get; private set; }
        public int An { get; private set; }


        //constructeur par default
        public Date()
        {
            Jour = 1;
            Mois = 1;
            An = 2021;
        }

        //constructeur d'initialisation
        public Date(int Jour, int Mois, int An)
        {
            this.Jour = Jour;
            this.Mois = Mois;
            this.An = An;
        }

        public override string ToString()
        {
            string message = this.Jour + ";" + this.Mois + ";" + this.An;
            return message;
        }
    }
}
