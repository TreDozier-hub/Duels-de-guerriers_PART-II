using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using Duels_de_guerriers_PART_II.ClassFolder;

namespace Duels_de_guerriers_PART_II
{
    internal class Program
    {
        static List<Guerrier> guerriers = new List<Guerrier>();
        static List<Guerrier> gagnants = new List<Guerrier>();
        static List<Guerrier> perdants = new List<Guerrier>();

        static void Main(string[] args)
        {
            Console.Clear();
            TypeCombats();
        }

        
        static T VerifierSaisi<T>(string message, ConsoleColor couleurTexte, ConsoleColor couleurFondTexte)
        {
            T resultat = default(T);
            string vide = " ";
            bool saisieValide = false;

            do
            {
                Console.ResetColor();
                Console.Write(message);

                // Couleurs spécifiques pour la saisie
                Console.ForegroundColor = couleurTexte;
                Console.BackgroundColor = couleurFondTexte;
                string saisie = Console.ReadLine();
                Console.ResetColor();

                try
                {
                    // Convertir la saisie en fonction du type attendu
                    if (typeof(T) == typeof(int))
                    {
                        resultat = (T)(object)int.Parse(saisie); // Conversion en int
                    }
                    else if (typeof(T) == typeof(string))
                    {
                        resultat = (T)(object)saisie; // Conversion en string
                    }
                    else
                    {
                        throw new InvalidOperationException("Type non pris en charge.");
                    }

                    saisieValide = true; // Pas d'erreur de conversion
                }
                catch
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine("Veuillez entrer une valeur valide.");
                    Console.ResetColor();
                }
            } while (!saisieValide);

            return resultat;
        }

        // Méthode pour vérifier les saisi numérique
        static int ObtenirEntierValide(string message)
        {
            int resultat;
            while (true)
            {
                //Console.Write(message);
                string saisie = Console.ReadLine();
                if (int.TryParse(saisie, out resultat))
                {
                    return resultat;
                }
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write("Veuillez entrer un nombre valide.");
                Console.ResetColor();
            }
        }

        // Methode pour afficher le menu secondaire
        static void TypeCombats()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;

            //    // Autre Façon de centrer mon contenu
            //    int consoleWidth = Console.WindowWidth;            
            //    string[] lines = {
            //    "----------------------------------",
            //    "--------- CHOISIE TA SPECIALITE ---------",
            //    "----------------------------------",
            //    "",
            //    "(1) DUEL",
            //    "ou",
            //    "(2) BASTON GENERALE",
            //    "",
            //    "     _ O                    .__o   ",
            //    "    | /|_                       |)  ",
            //    "    /\\                        |   ",
            //    "    /  |                      < \\  ",
            //    "",
            //    "(3) Menu Principal"
            //};
            //    foreach (string line in lines)
            //    {
            //        // calcul espace 
            //        int padding = (consoleWidth - line.Length) / 2;
            //        Console.WriteLine(new string(' ', padding) + line);
            //    }

            CentreAccueuil("----------------------------------\n",
                            "--------- CHOISIE TA SPECIALITE ---------\n",
                            "----------------------------------\n",
                            "\n", "(1) DUEL", "\n", "ou",
                            "\n", "(2) BASTON GENERALE", @"         " + '\n',
                @"         " + '\n',
                @"    _O   " + '\n',
                @"   |/|_  " + '\n',
                @"   /\    " + '\n',
                @"  /  |   " + '\n', @"         " + '\n' +
                @"         " + '\n',
                @" .__o    " + '\n',
                @"    |)   " + '\n',
                @"    |    " + '\n',
                @"   < \   "
                                    , "\n", "\n", " (3) Menu Principal ");
            Console.ResetColor();

            // switch case pour le choix du menu
            int choixTypeCombat = int.Parse(Console.ReadLine());
            switch (choixTypeCombat)
            {
                case 1:
                    Console.Clear();
                    if (guerriers.Count == 0)
                    {
                        AjouterGuerrier();
                    }
                    DuelAutomatique();
                    break;

                case 2:
                    Console.Clear();
                    ListeGuerriers();
                    if (guerriers.Count == 2)
                    {
                        AjouterGuerrier();
                    }
                    TournoiAutomatique();
                    break;

                case 3:
                    Console.Clear();
                    MenuPrincipal();
                    LancerTournoi();
                    break;

                default:
                    Console.WriteLine("Choix invalide. Recommencez !");
                    TypeCombats();
                    break;
            }
        }

        // Methode pour afficher le menu principal
        static void MenuPrincipal()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.Black;
            CentreAccueuil("--------- MENU PRINCIPAL ---------\n", "\n"
                                    , "Choisir le type de combat (1)\n", "\n"
                                    , "List des bonus (2)", "\n"
                                    , "Liste des Guerriers (3)", "\n"
                                    , "Liste des Boss (4)", "\n"
                                    , "Liste des Loser (5)", "\n", "\n"
                                    , "Quitter (0)", "\n"
                                    , "\n",
                                        @"         " + '\n',
                                        @" .__o    " + '\n',
                                        @"    |)   " + '\n',
                                        @"    |    " + '\n',
                                        @"   < \   "
                                    , "\n"
                                    );
            Console.ResetColor();

            // Choix du menu envoie vers != methodes
            int choixMenu = int.Parse(Console.ReadLine());
            switch (choixMenu)
            {
                case 1:
                    TypeCombats();
                    break;
                case 2:
                    AfficherSorts();
                    break;
                case 3:
                    ListeGuerriersAccueuil();
                    break;

                case 4:
                    AfficherListeGagnants();
                    break;

                case 5:
                    AfficherListePerdants();
                    break;

                case 0:
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Choix invalide. Recommencez !");
                    System.Threading.Thread.Sleep(1000);
                    MenuPrincipal();
                    break;

            }
            //while (choixMenu = 0)
        }

        // Méthode pour afficher les barres de progression côte à côte
        public static void AfficherBarresDeProgression(Guerrier guerrier1, Guerrier guerrier2)
        {
            //Console.SetCursorPosition(0, 0); // Place le curseur en haut de la console
            Console.Write(new string(' ', Console.WindowWidth)); // Nettoie la ligne
            Console.SetCursorPosition(0, 0); // Remet le curseur en position de départ

            // Affichage des barres de progression côte à côte
            Console.Write($"{guerrier1.NomGuerrier} : ");
            DessinerBarre(guerrier1.PointsDeVie, 100);
            Console.Write("  VS  "); // Espacement entre les deux barres
            Console.Write($"{guerrier2.NomGuerrier} : ");
            DessinerBarre(guerrier2.PointsDeVie, 100);

            // Ligne de séparation
            //Console.SetCursorPosition(0, 2);
            //Console.Write(new string('-', Console.WindowWidth));
        }

        // Méthode pour dessiner une seule barre de progression
        private static void DessinerBarre(int pointsDeVieActuels, int pointsDeVieMax)
        {
            int largeurMaxBarre = 30; // Nombre de caractères pour la barre
            double ratio = (double)pointsDeVieActuels / pointsDeVieMax;
            int largeurBarre = (int)(ratio * largeurMaxBarre);

            //Console.Write("[");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(new string('/', largeurBarre)); // Partie pleine
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(new string('-', largeurMaxBarre - largeurBarre)); // Partie vide
            Console.ResetColor();
            Console.Write($"{pointsDeVieActuels}/{pointsDeVieMax} PV\n");

        }

        // Methode pour afficher la liste des sort (bonus ou pas)
        static void AfficherSorts()
        {
            Console.Clear();
            CentreAccueuil("---------------------------\n",
                                "LISTE DES BONUS",
                                "(attibués aléatoirement)\n",
                                "---------------------------\n\n", "\n",
                                "Bouclier\n", "Potion énergisante\n", "Coup de hâche"
                                , "\n", "\n"
                                , " Retour (r) ");

            // switch case pour revenir au menu principal (r)
            string sortirList = (Console.ReadLine());
            switch (sortirList)
            {
                case "r":
                    MenuPrincipal();
                    break;
            }
        }

        static void AjouterGuerrier()
        {
            //Console.Write("Combien de guerriers voulez-vous créer ? : ");
            int nbGuerriers = VerifierSaisi<int>("Combien de guerriers voulez-vous créer ? : ", ConsoleColor.Black, ConsoleColor.White);

            // Boucle For engristrer les new Guerriers
            for (int i = 0; i < nbGuerriers; i++)
            {
                string nom = VerifierSaisi<string>("Entrez le nom du guerrier : ", ConsoleColor.Yellow, ConsoleColor.DarkMagenta);
                int pointsDeVie = VerifierSaisi<int>("Entrez les points de vie du guerrier: ", ConsoleColor.Black, ConsoleColor.White);
                int nbDesAttaque = VerifierSaisi<int>("Entrez le nombre de dés d'attaque du guerrier : ", ConsoleColor.Black, ConsoleColor.White);
                
                // "choixMenu" pour récupérer le choix (1, 2, 3) via la Console.ReadLine 
                Console.WriteLine("Quel type de guerrier tu veux être");
                Console.Write("\t\nGuerrier --- Nain --- Elfe --- Nazgûl \n");
                Console.WriteLine("      (1)     (2)     (3)       (4)");
                int quelGuerrier = VerifierSaisi<int>(" ", ConsoleColor.Black, ConsoleColor.White);


                switch (quelGuerrier)
                {
                    case 1:
                        guerriers.Add(new Guerrier(nom, pointsDeVie, nbDesAttaque));
                        break;
                    case 2:
                        Console.Write("Le nain porte-t-il une armure ? (o/n) :");
                        Console.WriteLine($"Tu perdra 5 points de vie. Mais il taidera \n");
                        string choixArmure = Console.ReadLine()?.ToLower();
                        if (choixArmure == "o")
                        {
                            pointsDeVie -= 10; // Retire 10 points de vie si l'armure est prie                            
                            System.Threading.Thread.Sleep(300);
                        }
                        else if (choixArmure == "n")
                        {
                            Console.Write("Choix invalide...");
                        }
                        // Création du nain
                        Nain nain = new Nain(nom, pointsDeVie, nbDesAttaque, true);
                        guerriers.Add(nain);
                        break;
                    case 3:
                        guerriers.Add(new Elfe(nom, pointsDeVie, nbDesAttaque));
                        break;
                    case 4:
                        Console.WriteLine("Le Nazgûl donne des coups d'épée foudroyant\n", "Mais tu pars avec 10 PV de moins");
                        guerriers.Add(new Nazgul(nom, pointsDeVie, nbDesAttaque));
                        break;
                    default:
                        Console.WriteLine("Choix invalide. On reprend ce guerrier !");
                        i--; // Permet de répéter l'itération pour un choix valide.
                        break;
                }
            }
        }

        // Methode pour afficher la liste des guerriers 
        static void ListeGuerriers()
        {
            Console.Clear();
            //Console.BackgroundColor = ConsoleColor.Yellow;
            //Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("\nListe des guerriers créés :\n");
            for (int i = 0; i < guerriers.Count; i++)
            {
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.ForegroundColor = ConsoleColor.Black;
                //Console.WriteLine($"{i + 1}. {guerriers[i].NomGuerrier} -> PV: {guerriers[i].PointsDeVie} / NA: {guerriers[i].NbAttaque} / Sorts attribués : {string.Join(", ", guerriers[i].SortsAssignes)}");
                Console.WriteLine($"{i + 1}. {guerriers[i].NomGuerrier} est un {guerriers[i].TypeGuerrier} -> PV: {guerriers[i].PointsDeVie} / NA: {guerriers[i].NbAttaque} / Sorts attribués : {string.Join(", ", guerriers[i].SortsAssignes)}");
                Console.ResetColor();
                //AjouterGuerrier();
                //Console.ResetColor();
            }            
        }

        // Methode pour afficher la liste des guerriers via le menu principal
        static void ListeGuerriersAccueuil()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.Black;
            ListeGuerriers();
            Console.ResetColor();
            Console.WriteLine("");
            AjouterGuerrier();
            SupprimerGuerrier();
            Console.ResetColor();
            RetourMenu();
        }

        string[] CadreTitre(string titre)
        {
            titre = $"║ {titre} ║";
            string bordureHaut = "╔" + new string('═', titre.Length - 2) + "╗";
            string bordureBas = "╚" + new string('═', titre.Length - 2) + "╝";

            return new[] { bordureHaut, titre, bordureBas };
        }

        // Methode pour des duel automatisé. Sans choix des coups 
        static void DuelAutomatique()
        {
            // Condition si pas assez de guerriers
            if (guerriers.Count < 2)
            {
                Console.WriteLine("Pas assez de guerriers pour un duel !");
                AjouterGuerrier();
                return;
            }

            ListeGuerriers();
            Console.Write("\nTu veux ajouter d'autres guerriers : o/n ");
            string sortirList = Console.ReadLine();
            switch (sortirList)
            {
                case "o":
                    AjouterGuerrier();
                    ListeGuerriers();
                    break;
            }

            Console.Write("\nChoisissez le numéro du premier guerrier pour le duel : ");
            int choix1 = int.Parse(Console.ReadLine()) - 1;

            Console.Write("Choisissez le numéro du deuxième guerrier pour le duel : ");
            int choix2 = int.Parse(Console.ReadLine()) - 1;

            if (choix1 < 0 || choix1 >= guerriers.Count || choix2 < 0 || choix2 >= guerriers.Count || choix1 == choix2)
            {
                Console.WriteLine("Sélection invalide. Veuillez réessayer.");
                return;
            }

            Guerrier guerrier1 = guerriers[choix1];
            Guerrier guerrier2 = guerriers[choix2];

            // Remettre des PV si nécessaire
            RemettrePointsDeVie(guerrier1);
            RemettrePointsDeVie(guerrier2);

            Console.Clear();
            CentreAccueuil("----------------------------------\n",
                            "--------- MODE DE DUEL ---------\n",
                            "----------------------------------\n"
                            , "\n", "\n", "\n"
                            , "1. Automatique"
                            , "\n", "\n"
                            , "2. Coup par Coup","\n");


            //Console.WriteLine("Mode de duel : 1. Automatique | 2. CoupParCoup");
            int mode = ObtenirEntierValide("Choix : ");

            if (mode == 2)
            {
                DuelCoupParCoup(guerrier1, guerrier2);
            }


            //RetourMenu();

            Console.Clear();
            Console.WriteLine($"\nDébut du duel : {guerrier1.NomGuerrier} contre {guerrier2.NomGuerrier} !\n");

            // Barres de progression initiales
            AfficherBarresDeProgression(guerrier1, guerrier2);

            while (guerrier1.PointsDeVie > 0 && guerrier2.PointsDeVie > 0)
            {
                // Tour du guerrier 1
                string action1 = guerrier1.ChoisirActionAutomatique(guerrier2);
                int degats1 = guerrier1.ExecuterAction(action1, guerrier2);
                guerrier2.SubirDegats(degats1);
                Console.WriteLine($"{guerrier1.NomGuerrier} utilise {action1} et inflige {degats1} dégâts.\n");
                AfficherBarresDeProgression(guerrier1, guerrier2);

                if (guerrier2.PointsDeVie <= 0)
                {
                    Console.WriteLine($"{guerrier1.NomGuerrier} remporte le duel !");
                    SauvegarderGagnant(guerrier1, guerrier2);
                    break;
                }

                // Tour du guerrier 2
                string action2 = guerrier2.ChoisirActionAutomatique(guerrier1);
                int degats2 = guerrier2.ExecuterAction(action2, guerrier1);
                guerrier1.SubirDegats(degats2);
                Console.WriteLine($"{guerrier2.NomGuerrier} utilise {action2} et inflige {degats2} dégâts.\n");
                AfficherBarresDeProgression(guerrier1, guerrier2);

                if (guerrier1.PointsDeVie <= 0)
                {
                    Console.WriteLine($"{guerrier2.NomGuerrier} remporte le duel !");
                    SauvegarderGagnant(guerrier2, guerrier1);
                    break;
                }

                // Pause pour observer le combat
                System.Threading.Thread.Sleep(300);
            }

            // Retour au menu principal après le duel
            RetourMenu();
            //Console.WriteLine("\nRetour au menu principal...");
            System.Threading.Thread.Sleep(300);
        }

        static void DuelCoupParCoup(Guerrier guerrier1, Guerrier guerrier2)
        {
            Console.Clear();
            Console.WriteLine($"Duel CoupParCoup : {guerrier1.NomGuerrier} VS {guerrier2.NomGuerrier}");
            while (guerrier1.PointsDeVie > 0 && guerrier2.PointsDeVie > 0)
            {
                Console.WriteLine($"{guerrier1.NomGuerrier} tu : 1. Attaque | 2. Esquive | 3. Potion");
                int action1 = ObtenirEntierValide("Action : ");
                guerrier1.ExecuterAction(action1, guerrier2);

                if (guerrier2.PointsDeVie <= 0) break;

                Console.WriteLine($"{guerrier2.NomGuerrier} tu : 1. Attaque | 2. Esquive | 3. Potion");
                int action2 = ObtenirEntierValide("Action : ");
                guerrier2.ExecuterAction(action2, guerrier1);
            }
            Console.WriteLine(guerrier1.PointsDeVie > 0 ? $"{guerrier1.NomGuerrier} gagne !" : $"{guerrier2.NomGuerrier} gagne !");
            SauvegarderGagnant(guerrier2, guerrier1);

        }

        // Methode pour lancer une baston générale
        static void LancerTournoi()
        {


            // Tant qu'il reste plus d'un guerrier
            Console.WriteLine("Début de la baston !");
            while (guerriers.Count > 1) // Tant qu'il reste plus d'un guerrier
            {
                // Sélectionner les deux premiers guerriers
                Guerrier guerrier1 = guerriers[0];
                Guerrier guerrier2 = guerriers[1];

                Console.WriteLine($"Combat : {guerrier1.NomGuerrier} - VS - {guerrier2.NomGuerrier}");

                // Empêche les PV de tomber en dessous de 0
                guerrier1.PointsDeVie = Math.Max(guerrier1.PointsDeVie, 0);
                guerrier2.PointsDeVie = Math.Max(guerrier2.PointsDeVie, 0);

                // Affiche les barres de progression initiales
                Console.Clear();
                Console.WriteLine("\nTournoi en cours :");
                AfficherBarresDeProgression(guerrier1, guerrier2);

                while (guerrier1.PointsDeVie > 0 && guerrier2.PointsDeVie > 0)
                {
                    // Tour du guerrier 1
                    string action1 = guerrier1.ChoisirActionAutomatique(guerrier2);
                    int degats1 = guerrier1.ExecuterAction(action1, guerrier2);
                    guerrier2.SubirDegats(degats1);

                    // Affichage des résultats après l'action du guerrier 1
                    Console.WriteLine($"{guerrier1.NomGuerrier} utilise {action1} et inflige {degats1} dégâts.");
                    AfficherBarresDeProgression(guerrier1, guerrier2);

                    if (guerrier2.PointsDeVie <= 0) break;

                    // Tour du guerrier 2
                    string action2 = guerrier2.ChoisirActionAutomatique(guerrier1);
                    int degats2 = guerrier2.ExecuterAction(action2, guerrier1);
                    guerrier1.SubirDegats(degats2);

                    // Affichage des résultats après l'action du guerrier 2
                    Console.WriteLine($"{guerrier2.NomGuerrier} utilise {action2} et inflige {degats2} dégâts.");
                    AfficherBarresDeProgression(guerrier1, guerrier2);

                    // Pause pour observer les actions
                    System.Threading.Thread.Sleep(300);
                }

                // Mettre le perdant dans une liste "Perdants"
                if (guerrier1.PointsDeVie > 0)
                {
                    Console.WriteLine($"\n{guerrier1.NomGuerrier} remporte le combat !");
                    gagnants.Add(guerrier1);
                    perdants.Add(guerrier2);
                    //guerriers.Remove(guerrier2); // Le perdant est retiré
                }
                else
                {
                    Console.WriteLine($"\n{guerrier2.NomGuerrier} remporte le combat !");
                    gagnants.Add(guerrier2);
                    perdants.Add(guerrier1);
                    //guerriers.Remove(guerrier1); // Le perdant est retiré
                }

                // Pause avant le prochain combat
                System.Threading.Thread.Sleep(300);
            }

            // Afficher le vainqueur du tournoi
            if (guerriers.Count == 1)
            {
                Console.WriteLine($"Le vainqueur du tournoi est : {guerriers[0].NomGuerrier}");
                SauvegarderGagnant(guerriers[0], null); // Sauvegarde le gagnant
            }
            else
            {
                Console.WriteLine("Tous les guerriers sont morts !");
            }

            // Retour au menu principal
            RetourMenu();
            //Console.WriteLine("\nRetour au menu principal...");
            System.Threading.Thread.Sleep(300);
            //MenuPrincipal();
        }


        static void TournoiAutomatique()
        {
            //Console.WriteLine("Tournoi automatique lancé !");
            Console.Clear();
            // Vérifier s'il y a assez de guerriers
            if (guerriers.Count < 2)
            {
                //Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.DarkRed;
                CentreAccueuil("Pas assez de guerriers pour un tournoi !", "\n", "\n", @"         " + '\n' +
                                                                                          '\n',
                                                                                         @" .__o    " + '\n',
                                                                                         @"    |)   " + '\n',
                                                                                         @"    |    " + '\n',
                                                                                         @"   < \   ", "\n", "\n", "Tu veux des guerriers : o/n "
                                                                                         , "\n", "\n");
                string ajoutListe = Console.ReadLine();
                if (ajoutListe == "o")
                {
                    Console.Clear();
                    AjouterGuerrier();
                    ListeGuerriers();
                }
                else if (ajoutListe == "n")
                {
                    MenuPrincipal();
                }
                RetourMenu();
                return;
            }

            while (guerriers.Count > 1)
            {
                Console.Clear();
                Console.WriteLine("Tournoi en cours !");

                List<Guerrier> gagnants = new List<Guerrier>();

                while (guerriers.Count > 1)
                {
                    Guerrier guerrier1 = guerriers[0];
                    Guerrier guerrier2 = guerriers[1];

                    Console.WriteLine($"\nCombat : {guerrier1.NomGuerrier} VS {guerrier2.NomGuerrier}");

                    LancerCombat(guerrier1, guerrier2);

                    if (guerrier1.PointsDeVie > 0)
                    {
                        gagnants.Add(guerrier1);
                        perdants.Add(guerrier2); // Ajouter guerrier2 à la liste des perdants
                        guerriers.Remove(guerrier2); // Retirer le perdant
                    }
                    else
                    {
                        gagnants.Add(guerrier2);
                        perdants.Add(guerrier1); // Ajouter guerrier1 à la liste des perdants
                        guerriers.Remove(guerrier1); // Retirer le perdant
                    }
                }

                guerriers = new List<Guerrier>(gagnants); // Prépare les gagnants pour le prochain tour
            }

            if (guerriers.Count == 1)
            {
                Console.WriteLine($"\nLe vainqueur du tournoi est : {guerriers[0].NomGuerrier}");
                SauvegarderGagnant(guerriers[0], null);
            }
            else
            {
                Console.WriteLine("\nTous les guerriers sont morts !");
            }

            Console.WriteLine("\nTournoi terminé. Retour au menu principal...");
            System.Threading.Thread.Sleep(2000);
            MenuPrincipal();
        }

        static void LancerCombat(Guerrier guerrier1, Guerrier guerrier2)
        {
            // Empêche les PV de tomber en dessous de 0
            guerrier1.PointsDeVie = Math.Max(guerrier1.PointsDeVie, 0);
            guerrier2.PointsDeVie = Math.Max(guerrier2.PointsDeVie, 0);

            // Affiche les barres de progression initiales
            AfficherBarresDeProgression(guerrier1, guerrier2);

            while (guerrier1.PointsDeVie > 0 && guerrier2.PointsDeVie > 0)
            {
                // Tour du guerrier 1
                string action1 = guerrier1.ChoisirActionAutomatique(guerrier2);
                int degats1 = guerrier1.ExecuterAction(action1, guerrier2);
                guerrier2.SubirDegats(degats1);
                Console.Write($"{guerrier1.NomGuerrier} utilise {action1} et inflige {degats1} dégâts.");
                AfficherBarresDeProgression(guerrier1, guerrier2);

                if (guerrier2.PointsDeVie <= 0) break;

                // Tour du guerrier 2
                string action2 = guerrier2.ChoisirActionAutomatique(guerrier1);
                int degats2 = guerrier2.ExecuterAction(action2, guerrier1);
                guerrier1.SubirDegats(degats2);
                Console.Write($"{guerrier2.NomGuerrier} utilise {action2} et inflige {degats2} dégâts.");
                AfficherBarresDeProgression(guerrier1, guerrier2);

                // Pause pour observer chaque tour
                System.Threading.Thread.Sleep(300);
            }


            //Ou opérateur ternaire condition ? valeurSiVrai : valeurSiFaux
            Console.WriteLine(guerrier1.PointsDeVie > 0
                ? $"\n{guerrier1.NomGuerrier} remporte le combat !"
                : $"\n{guerrier2.NomGuerrier} remporte le combat !");
        }

        // Methode pour sauvegarder gagnant des combats dans une liste
        static void SauvegarderGagnant(Guerrier gagnant, Guerrier perdant)
        {

            Console.Write($"Souhaitez-vous sauvegarder {gagnant.NomGuerrier} comme gagnant ? (o/n) ");
            string reponse = Console.ReadLine()?.ToLower();

            if (reponse == "o")
            {
                gagnants.Add(gagnant);
                perdants.Add(perdant);
                Console.WriteLine($"{gagnant.NomGuerrier} a été sauvegardé dans la liste des gagnants !");
            }
            else
            {
                Console.WriteLine($"{gagnant.NomGuerrier} n'a pas été sauvegardé.");
            }
            MenuPrincipal();
        }

        static void RetourMenu()
        {
            Console.WriteLine("\nAppuyez sur une touche pour revenir au menu principal...");
            Console.ReadKey();
            MenuPrincipal();
        }

        //private static List<Guerrier> perdant = new List<Guerrier>();
        List<Guerrier> perdant = new List<Guerrier>();

        // Méthode pour ajouter un perdant à la liste
        public static void AjouterPerdant(Guerrier guerrier)
        {
            if (!perdants.Contains(guerrier))
            {
                perdants.Add(guerrier);
            }
        }

        // Méthode pour afficher les perdants
        public static void AfficherListePerdants()
        {
            Console.Clear();

            if (perdants.Count == 0)
            {
                Console.WriteLine("Aucun perdant pour l'instant.\n");
            }
            else
            {
                Console.WriteLine("Liste des perdants :\n");
                foreach (var perdant in perdants)
                {
                    Console.WriteLine($"- {perdant.NomGuerrier}");
                }

                Console.WriteLine("\nVoulez-vous réinitialiser la liste des perdants ? (o/n)");
                string choix = Console.ReadLine();

                if (choix?.ToLower() == "o")
                {
                    ReinitialiserPerdants(); // Réinitialise la liste des perdants
                    Console.WriteLine("\nLes perdants ont été réintégrés dans la liste des guerriers.");
                }
            }

            Console.Write("\n<-- Retournez à l'accueil (r) ");
            string sortirList = Console.ReadLine();
            switch (sortirList)
            {
                case "r":
                    MenuPrincipal();
                    break;
            }
        }



        public static void ReinitialiserPerdants()
        {
            if (perdants.Count == 0)
            {
                Console.WriteLine("Aucun perdant à réinitialiser.\n");
                return;
            }

            // Transférer les perdants dans la liste principale
            foreach (var perdant in perdants)
            {
                guerriers.Add(perdant);
            }

            // Vider la liste des perdants
            perdants.Clear();

            Console.WriteLine("Tous les perdants ont été réintégrés dans la liste des guerriers.\n");
        }

        // Méthode pour afficher les gagnants
        public static void AfficherListeGagnants()
        {
            Console.Clear();
            if (gagnants.Count == 0)
            {
                Console.WriteLine("Aucun gagnant pour l'instant.");
                Console.Write($"\n<-- Retournez à l'accueil (r) ");
                // switch case pour revenir au menu principal (r)
                string sortirList = (Console.ReadLine());
                switch (sortirList)
                {
                    case "r":
                        MenuPrincipal();
                        break;
                }
            }
            else
            {
                Console.WriteLine("Liste des gagnants :");
                foreach (var gagnant in gagnants)
                {
                    Console.WriteLine($"- {gagnant.NomGuerrier}");
                }
                Console.Write($"\n<-- Retournez à l'accueil (r) ");
                // revenir au menu principal (r)
                string sortirList = (Console.ReadLine());
                switch (sortirList)
                {
                    case "r":
                        MenuPrincipal();
                        break;
                }
            }
        }

        //Méthode pour remettre des points de vie à un guerrier si ses PV sont à 0
        public static void RemettrePointsDeVie(Guerrier guerrier)
        {
            if (guerrier.PointsDeVie == 0)
            {
                Console.Write($"PV de {guerrier.NomGuerrier} sont à 0. Entré une valeur : ");
                if (int.TryParse(Console.ReadLine(), out int nouveauxPV))
                {
                    guerrier.PointsDeVie = nouveauxPV;
                }
                else
                {
                    Console.WriteLine("Entrée invalide. Les points de vie n'ont pas été modifiés.");
                }
            }
        }

        public static void SupprimerGuerrier()
        {
            if (guerriers.Count == 0)
            {
                Console.WriteLine("Aucun guerrier à supprimer.\n");
                return;
            }
            Console.Write("\nTu veux supprimer 1 ou plusieurs gurriers ?");
            Console.Write("\nEntrez le numéro du guerrier (ou 0 pour annuler) : ");
            if (int.TryParse(Console.ReadLine(), out int choix) && choix > 0 && choix <= guerriers.Count)
            {
                Guerrier guerrierSupprime = guerriers[choix - 1];
                guerriers.RemoveAt(choix - 1);
                Console.WriteLine($"\nLe guerrier '{guerrierSupprime.NomGuerrier}' a été supprimé.\n");
            }
            else
            {
                Console.WriteLine("\nSuppression annulée ou choix invalide.\n");
            }
        }
        // Methode pour centrer contenu du menu "type de combats)
        static void CentreAccueuil(params string[] lines)
        {
            int verticalStart = (Console.WindowHeight - lines.Length) / 2;
            int verticalPosition = verticalStart;
            foreach (var line in lines)
            {
                int horizontalStart = (Console.WindowWidth - line.Length) / 2;
                Console.SetCursorPosition(horizontalStart, verticalPosition);
                Console.Write(line);
                ++verticalPosition;
            }
        }


    }
}