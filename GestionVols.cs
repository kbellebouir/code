using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace tp3
{
    public class GestionVols
    {
        static string nomFichier = "../../../Fichier Cie_Air_Relax.txt";
        static StreamWriter ficOut;
        static StreamReader ficIn;

        //variable
        static int numVol;
        static string destination;
        static int jour, mois, an;
        static int nombreRes;
        static char categorieVol;
        static int avionID;

        //conteneur de données
        static SortedDictionary<int, Vol> ListeDictionaryVols = new SortedDictionary<int, Vol>();

        //constante de classe publique
        public const int MAX_PLACES = 340;

        //charger vols pour faire l’ouverture et la lecture du fichier CieAirRelax.txt
        public static void chargerVols()
        {

            string[] tab;
            string ligne;

            if (!File.Exists(Utilitaires.FICHIER_OBJETS_VOL))
            {
                ListeDictionaryVols = Utilitaires.ChargerFichierObjet(Utilitaires.FICHIER_OBJETS_VOL);
            } else
            {
                //ouvrir fichier Cie_Air_Relax
                ficIn = new StreamReader(nomFichier);
            ligne = ficIn.ReadLine();//lire une ligne du fichier
            while (ligne != null)//Tester si pas la fin du fichier
            {
                tab = ligne.Split(';');//décomposer la ligne

                //Prendre chaque élément de la ligne et le mettre dans les variables
                numVol = int.Parse(tab[0]); destination = tab[1];
                jour = int.Parse(tab[2]); mois = int.Parse(tab[3]); an = int.Parse(tab[4]);
                nombreRes = int.Parse(tab[5]);
                categorieVol = char.Parse(tab[6]);
                avionID = int.Parse(tab[7]);

                Date dateDepart = new Date(jour, mois, an);

                Avion avionChoisi = new Avion(avionID);

                    switch (categorieVol)
                    {
                        case 'R':
                            ListeDictionaryVols.Add(numVol, new VolRegulier(numVol, destination, dateDepart, nombreRes, avionChoisi, categorieVol));
                            break;
                        case 'B':
                            ListeDictionaryVols.Add(numVol, new VolBasPrix(numVol, destination, dateDepart, nombreRes, avionChoisi, categorieVol));
                            break;
                        case 'P':
                            ListeDictionaryVols.Add(numVol, new VolPrive(numVol, destination, dateDepart, nombreRes, avionChoisi, categorieVol));
                            break;
                        case 'C':
                            ListeDictionaryVols.Add(numVol, new VolCharter(numVol, destination, dateDepart, nombreRes, avionChoisi, categorieVol));
                            break;
                    }

                    ligne = ficIn.ReadLine();

            }
            ficIn.Close();
            }
        }

        //méthode d’instance insererVol doit s’assurer qu’il reste de la place dans le tableau des vols
        public static void insererVol()
        {
            ficOut = new StreamWriter(nomFichier, true);
            Date dateDepart;

            Console.WriteLine("SAISIE D’UN NOUVEAU VOL");
            Console.WriteLine("******************");
            Console.Write("Numéro du vol : ");
            numVol = int.Parse(Console.ReadLine());

            {
                Console.Write("Destination : ");
                destination = Console.ReadLine();

                Console.WriteLine("Date de depart : ");
                Console.Write("Entrer le jour : ");
                jour = int.Parse(Console.ReadLine());
                Console.Write("Entrer le mois : ");
                mois = int.Parse(Console.ReadLine());
                Console.Write("Entrer l'année : ");
                an = int.Parse(Console.ReadLine());

                dateDepart = new Date(jour, mois, an);

                Console.WriteLine("Nombre de réservation : ");
                nombreRes = int.Parse(Console.ReadLine());

                Console.WriteLine("Catégorie de vols : ");
                Console.WriteLine("Régulier : R ");
                Console.WriteLine("Bas Prix : B ");
                Console.WriteLine("Charter : C ");
                Console.WriteLine("Privé : P ");
                categorieVol = char.Parse(Console.ReadLine());

                Console.WriteLine("Type d'avion : ");
                Console.WriteLine("Numéro de 1 à 5 ");
                avionID = int.Parse(Console.ReadLine());

                Avion avionChoisi = new Avion(avionID);

                switch (categorieVol)
                {
                    case 'R':
                        ListeDictionaryVols.Add(numVol, new VolRegulier(numVol, destination, dateDepart, nombreRes, avionChoisi, categorieVol));
                        break;
                    case 'B':
                        ListeDictionaryVols.Add(numVol, new VolBasPrix(numVol, destination, dateDepart, nombreRes, avionChoisi, categorieVol));
                        break;
                    case 'P':
                        ListeDictionaryVols.Add(numVol, new VolPrive(numVol, destination, dateDepart, nombreRes, avionChoisi, categorieVol));
                        break;
                    case 'C':
                        ListeDictionaryVols.Add(numVol, new VolCharter(numVol, destination, dateDepart, nombreRes, avionChoisi, categorieVol));
                        break;
                }

            }

            ficOut.Close();


        }

        //utiliser dans insererVol et dans retirerVol
        public static bool rechercherVol(Vol VolTrouver)
        {
            foreach (KeyValuePair<int, Vol> kvp in ListeDictionaryVols)
            {
                if (kvp.Value.Equals(VolTrouver))
                {
                    return true;
                }
            }
            return false;
        }

        //permet de saisir le numéro du vol avant afficher RETIRER VOL
        public static void retirerVol()
        {
            char choix;

            Console.WriteLine("RETIRER UN VOL");
            Console.WriteLine("******************");
            Console.Write("Numéro du vol : ");
            numVol = int.Parse(Console.ReadLine());

                //afficher destination, date et le total des réservations
                foreach (KeyValuePair<int, Vol> kvp in ListeDictionaryVols)
                {
                    Vol unVol = kvp.Value;  

                    if (numVol == kvp.Key)
                    {
                        Console.Write("Désirez-vous vraiment retirer ce vol (O/N) ? ");
                        choix = Console.ReadLine().ToUpper()[0];

                        if (choix == 'O')
                        {
                            //retirer repopuler sans la ligne
                            ListeDictionaryVols.Remove(numVol);

                        }

                        break;
                    }

                } 

        }

        //permet de saisir le numéro du vol dont on veut modifier la date
        public static void modifierDate()
        {

            Vol dateVol = null;
            Date newDate = null;

            Console.WriteLine("MODIFICATION DE LA DATE DE DÉPART");
            Console.WriteLine("******************");
            Console.Write("Numéro du vol : ");
            numVol = int.Parse(Console.ReadLine());

                //afficher destination, date actuel
                foreach (KeyValuePair<int, Vol> kvp in ListeDictionaryVols)
                {
                    Vol unVol = kvp.Value;

                    if (numVol == kvp.Key)
                    {
                        //Appel de get de la classe Vol
                        Console.WriteLine(unVol.Destination);
                        Console.WriteLine(unVol.getDate());

                        Console.WriteLine("Entrer la nouvelle date :");
                        Console.Write("Entrer le jour : ");
                        jour = int.Parse(Console.ReadLine());
                        Console.Write("Entrer le mois : ");
                        mois = int.Parse(Console.ReadLine());
                        Console.Write("Entrer l'année : ");
                        an = int.Parse(Console.ReadLine());

                        //use Set and class Date to modifier
                        dateVol = kvp.Value;
                        newDate = new Date(jour, mois, an);

                        break;
                    }
                }

            dateVol.setDate(newDate);


        }

        //permet de saisir le numéro du vol que le client désire réserver
        public static void reserverVol()
        {
            int numVol;
            int nombreRes;

            Console.WriteLine("RÉSERVATION D'UN VOL");
            Console.WriteLine("******************");
            Console.Write("Numéro du vol : ");
            numVol = int.Parse(Console.ReadLine());

                //afficher destination, date et le total des réservations
                foreach (KeyValuePair<int, Vol> kvp in ListeDictionaryVols)
                {
                    if (numVol == kvp.Key)
                    {
                        Vol unVol = kvp.Value;

                        if (unVol.NombreRes <= MAX_PLACES)
                        {//Appel de get de la classe Vol
                            Console.WriteLine(unVol.Destination);
                            Console.WriteLine(unVol.getDate());
                            Console.WriteLine(unVol.NombreRes);

                            Console.Write("Entrer le nombre de places à réserver : ");
                            nombreRes = int.Parse(Console.ReadLine());

                            //ajouter le nombre a ceux existante si ca depasse MAX message erreur 
                            unVol.NombreRes += nombreRes;

                            if (nombreRes > MAX_PLACES)
                            {
                                Console.WriteLine("Erreur nombre de places maximum atteint dans ce vol ");
                                Console.ReadKey();
                            }

                            break;
                        }
                    }

                }

        }

        //afficher la liste des vols existants 
        public static void listerVols()
        {
            Console.WriteLine("LISTE DES VOLS");
            Console.WriteLine("******************");
            Console.WriteLine("Numéro; Destination; Date départ; Réservations; Type; Nombre de place; Rayon d'action; Type d'action; Classe; Repas; Reservation siege; Service bar; Systeme Divertissement; Service Payant; Prise; WiFi");

            foreach (KeyValuePair<int, Vol> kvp in ListeDictionaryVols)
            {
                Console.WriteLine(kvp);//Fait appel à la méthode ToString dans la classe Vol

            }

            Console.ReadKey();
        }

        //create a menu Gestion des vols
        public static int menu()
        {
            int choix;
            Console.WriteLine("    GESTION DES VOLS\n");
            Console.WriteLine("1.Listes des vols");
            Console.WriteLine("2.Ajout d'un vol");
            Console.WriteLine("3.Retrait d'un vol");
            Console.WriteLine("4.Modification de la date de départ");
            Console.WriteLine("5.Réservation d'un vol");
            Console.WriteLine("0.Terminer");
            Console.WriteLine("    Faites votre choix : ");
            choix = int.Parse(Console.ReadLine());//choix de l'option par l'utilisateur

            // message erreur si numero pas entre 0 et 5
            if (choix >= 0 && choix <= 5)
            {
                return choix;

            }
            else
            {
                Console.WriteLine("Erreur : Le choix n'est pas entre 0 et 5 ");
                Console.Clear();
            }

            return choix;

        }


        static void Main(string[] args)
        {
            Date maDate = new Date(jour, mois, an);
            Avion monAvion = new Avion(avionID);
            Vol monVol = new Vol(numVol, destination, maDate, nombreRes, monAvion, categorieVol);

            chargerVols();

            int choix;
            do
            {
                choix = menu();//Afficher le menu
                switch (choix)
                {
                    case 1:
                        listerVols();
                        break;
                    case 2:
                        insererVol();
                        break;
                    case 3:
                        retirerVol();
                        break;
                    case 4:
                        modifierDate();
                        break;
                    case 5:
                        reserverVol();
                        break;
                }
                Console.Clear();
            } while (choix != 0);

            Utilitaires.EnregistrerObjets(Utilitaires.FICHIER_OBJETS_VOL, ListeDictionaryVols);
            ListeDictionaryVols.Clear();
            ListeDictionaryVols = Utilitaires.LireObjets(Utilitaires.FICHIER_OBJETS_VOL);

        }
    }
}

