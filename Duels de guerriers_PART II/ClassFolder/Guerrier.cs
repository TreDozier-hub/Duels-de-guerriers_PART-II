﻿using System;
using System.Collections.Generic;

namespace Duels_de_guerriers_PART_II.ClassFolder
{
    internal class Guerrier
    {
        private const int PvMin = 0; // Initialisation des PV minimum

        private string _nomGuerrier;
        private int _pointsDeVie;
        private int _nbAttaque;

        private Random lancerDe = new Random();

        // Propriétés avec getters et setters publics
        public string NomGuerrier { get { return _nomGuerrier; } set { _nomGuerrier = value; } }

        public int PointsDeVie{ get => _pointsDeVie;
            set
            {
                // Faire en sorte que les PV ne descendent pas en dessous du minimum initialisé au dessus
                _pointsDeVie = value < PvMin ? PvMin : value;              
            }
        }

        public int NbAttaque { get => _nbAttaque; set { _nbAttaque = value; } }

        // Liste des sorts assignés au guerrier
        public List<string> SortsAssignes { get; private set; } = new List<string>();

        // Liste des utilisations restantes pour chaque sort assigné
        public List<int> SortsUtilises { get; private set; } = new List<int>();

        public int MaxPointsDeVie { get; set; }

        // Constructeur pour initialiser le guerrier
        public Guerrier(string nom, int pointsDeVie, int nbDesAttaque)
        {
            NomGuerrier = nom;
            PointsDeVie = pointsDeVie;
            NbAttaque = nbDesAttaque;
            TirerSorts(); // Attribuer des sorts aléatoires à la création
            MaxPointsDeVie = pointsDeVie; // Initialisation des PV max
        }

        // Méthode pour afficher les infos d'un guerrier
        public void AfficherInfos()
        {
            Console.WriteLine($"{NomGuerrier} --> PV = {PointsDeVie}");
        }

        // Méthode pour lancer une attaque et affliger des dégats
        public int Attaquer()
        {
            int degat = lancerDe.Next(1, 7);
            _nbAttaque++;
            Console.WriteLine($"{NomGuerrier} attaque et inflige {degat} dégâts.");
            return degat;
        }

        // Méthode pour attribuer un sorts
        private void TirerSorts()
        {
            // Liste des sorts possibles
            List<string> sortsDisponibles = new List<string> { "Esquive", "Potion", "Coup Puissant", "Bouclier Magique", "Regain d'Énergie" };

            // Tirer un nombre aléatoire de sorts entre 1 et 3
            int nbSorts = lancerDe.Next(1, 4);

            while (SortsAssignes.Count < nbSorts)
            {
                string sort = sortsDisponibles[lancerDe.Next(sortsDisponibles.Count)];
                if (!SortsAssignes.Contains(sort))
                {
                    SortsAssignes.Add(sort); // Ajouter le sort à la liste des sorts assignés
                    SortsUtilises.Add(3); // Initialiser les utilisations restantes à 3
                }
            }

            // Debugging pour vérifier les sorts tirés
            //Console.WriteLine($"Sorts attribués à {NomGuerrier} : {string.Join(", ", SortsAssignes)} avec {string.Join(", ", SortsUtilises)} utilisations chacune.");
        }

        // Méthode subir dégats
        public void SubirDegats(int degats)
        {
            PointsDeVie -= degats;
            Console.WriteLine($"{NomGuerrier} subit {degats} dégâts et a maintenant {PointsDeVie} PV.");
        }

        // Méthode esquive (réduit les dégâts reçus de moitié)
        public void Esquiver()
        {
            int index = SortsAssignes.IndexOf("Esquive");
            if (index != -1 && SortsUtilises[index] > 0)
            {
                Console.WriteLine($"{NomGuerrier} tente d'esquiver !");
                if (lancerDe.Next(0, 2) == 0) // 50% probability to dodge
                {
                    Console.WriteLine("Esquive réussie ! Les dégâts seront réduits de moitié.");
                }
                else
                {
                    Console.WriteLine("Esquive ratée !");
                }
                SortsUtilises[index]--;
            }
            else
            {
                Console.WriteLine("Esquive non disponible ou plus d'utilisations restantes !");
            }
        }

        // HMethode potion magique (restore 10 PV)
        public void UtiliserPotion()
        {
            int index = SortsAssignes.IndexOf("Potion");
            if (index != -1 && SortsUtilises[index] > 0)
            {
                int pointsSoignes = 5;
                if (lancerDe.Next(0, 4) == 0) // 25% probability to heal
                {
                    PointsDeVie += pointsSoignes;
                    Console.WriteLine($"{NomGuerrier}, Guérison réussie ! Tu as gagné {pointsSoignes} PV. PV actuels : {PointsDeVie}");
                }
                else
                {
                    Console.WriteLine("Oups...La potion est périmée !");
                }
                SortsUtilises[index]--;
            }
            else
            {
                Console.WriteLine("Potion non disponible ou plus d'utilisations restantes !");
            }
        }

        // Methode pour coup puissant
        public void CoupPuissant()
        {
            int index = SortsAssignes.IndexOf("Coup Puissant");
            if (index != -1 && SortsUtilises[index] > 0)
            {
                int coupHache = 10;
                if (lancerDe.Next(0, 5) == 0) // 10% 
                {
                    PointsDeVie += coupHache;
                    Console.WriteLine($"{NomGuerrier} subit un coup de hache et a maintenant {PointsDeVie} PV.");
                }
                else
                {
                    Console.WriteLine("Coup de hâche raté !");
                }
                SortsUtilises[index]--;
            }
            else
            {
                Console.WriteLine("Coup Puissant non disponible ou plus d'utilisations restantes !");
            }
        }

        // Méthode pour vérifier les saisi numérique
        public static int ObtenirEntierValide()
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

        public string ChoisirActionAutomatique(Guerrier adversaire)
        {
            // Utiliser une potion si les PV sont faibles (par exemple, < 30% du maximum)
            if (SortsAssignes.Contains("Potion") && SortsUtilises[SortsAssignes.IndexOf("Potion")] > 0 && PointsDeVie <= MaxPointsDeVie * 0.3)
            {
                return "Potion";
            }

            // Esquiver si l'adversaire a un sort puissant disponible
            if (SortsAssignes.Contains("Esquive") && SortsUtilises[SortsAssignes.IndexOf("Esquive")] > 0 && adversaire.APeutLancerCoupPuissant())
            {
                return "Esquive";
            }

            // Utiliser un coup puissant si disponible et si les PV de l'adversaire sont faibles
            if (SortsAssignes.Contains("Coup Puissant") && SortsUtilises[SortsAssignes.IndexOf("Coup Puissant")] > 0 && adversaire.PointsDeVie <= MaxPointsDeVie * 0.4)
            {
                return "Coup Puissant";
            }

            // Par défaut, attaquer
            return "Attaquer";
        }

        public bool APeutLancerCoupPuissant()
        {
            return SortsAssignes.Contains("Coup Puissant") && SortsUtilises[SortsAssignes.IndexOf("Coup Puissant")] > 0;
        }

        public int ExecuterAction(string action, Guerrier adversaire)
        {
            switch (action)
            {
                case "Attaquer":
                    return Attaquer();

                case "Esquive":
                    if (SortsAssignes.Contains("Esquive") && SortsUtilises[SortsAssignes.IndexOf("Esquive")] > 0)
                    {
                        Esquiver();
                        return 0; // Esquive ne fait pas de dégâts
                    }
                    break;

                case "Potion":
                    if (SortsAssignes.Contains("Potion") && SortsUtilises[SortsAssignes.IndexOf("Potion")] > 0)
                    {
                        UtiliserPotion();
                        return 0; // Potion ne fait pas de dégâts
                    }
                    break;

                //case "Coup Puissant":
                //    if (SortsAssignes.Contains("Coup Puissant") && SortsUtilises[SortsAssignes.IndexOf("Coup Puissant")] > 0)
                //    {
                //        return CoupPuissant();
                //    }
                //    break;
            }

            return 0; // Si l'action n'a pas été exécutée, aucun dégât
        }
    }
}