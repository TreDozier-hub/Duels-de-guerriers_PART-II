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

        public string TypeGuerrier { get; set; }

        // Liste des utilisations restantes pour chaque sort assigné
        public List<int> SortsUtilises { get; private set; } = new List<int>();

        public int MaxPointsDeVie { get; set; }

        // Constructeur pour initialiser le guerrier
        public Guerrier(string nom, int pointsDeVie, int nbDesAttaque)
        {
            NomGuerrier = nom;
            PointsDeVie = pointsDeVie;
            NbAttaque = nbDesAttaque;
            TirerSorts(); // Attribuer des sorts aléatoires
            MaxPointsDeVie = pointsDeVie; // Initialisation des PV max
            TypeGuerrier = "Guerrier";
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
                    SortsAssignes.Add(sort); // Ajouter le sort a la liste des sorts assignés
                    SortsUtilises.Add(lancerDe.Next(1, 4)); // Nombre d'utilisations avec nombre aléatoire entre 1 et 3
                }
            }

            // Afficher les sorts assignés avec leurs utilisations restantes
            Console.WriteLine($"Sorts attribués à {NomGuerrier} :");
            for (int i = 0; i < SortsAssignes.Count; i++)
            {
                Console.WriteLine($"- {SortsAssignes[i]} : {SortsUtilises[i]} utilisation(s) possible");
            }
        }


        // Méthode subir dégats
        public virtual void SubirDegats(int degats)
        {
            PointsDeVie -= degats;
            Console.WriteLine($"{NomGuerrier} subit {degats} dégâts --> {PointsDeVie} PV.");
        }

        // Méthode esquive evite coups (fonctionne 1 fois sur 2)
        public void Esquiver()
        {
            int index = SortsAssignes.IndexOf("Esquive");
            if (index != -1 && SortsUtilises[index] > 0)
            {
                Console.WriteLine($"{NomGuerrier} tente d'esquiver !");
                if (lancerDe.Next(0, 2) == 0) // 1 fois sur 2
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

        // Methode potion magique (restore 5 PV)
        // avec 25% de chance que ça fonctionne (lancerDe.Next(0, 4))
        public void UtiliserPotion()
        {
            int index = SortsAssignes.IndexOf("Potion");
            if (index != -1 && SortsUtilises[index] > 0)
            {
                int pointsSoignes = 5;
                if (lancerDe.Next(0, 4) == 0)
                {
                    PointsDeVie += pointsSoignes;
                    Console.WriteLine($"{NomGuerrier}, Guérison réussie ! PV actuels : {PointsDeVie}");
                }
                else
                {
                    Console.WriteLine("Oups...La potion est périmée !");
                }
                SortsUtilises[index]--;
            }
            else
            {
                Console.WriteLine("Potion plus disponible !");
            }
        }

        // Methode coup puissant (coup de hâche)
        public void CoupPuissant()
        {
            int index = SortsAssignes.IndexOf("Coup Puissant");
            if (index != -1 && SortsUtilises[index] > 0)
            {
                int coupHache = 10;
                if (lancerDe.Next(0, 4) == 0) // 25%
                {
                    PointsDeVie += coupHache;
                    Console.WriteLine($"{NomGuerrier}, un coup de hache dans ta face. - {PointsDeVie} PV.");
                }
                else
                {
                    Console.WriteLine("Coup de hâche raté !");
                }
                SortsUtilises[index]--;
            }
            else
            {
                Console.WriteLine("Coup Puissant plus disponible !");
            }
        }

        

        public void ExecuterAction(int choix, Guerrier adversaire)
        {
            switch (choix)
            {
                case 1:
                    adversaire.SubirDegats(Attaquer());
                    break;
                case 2:
                    Esquiver();
                    break;
                case 3:
                    UtiliserPotion();
                    break;
                case 4:
                    CoupPuissant();
                    break;
                default:
                    Console.WriteLine("Action invalide, aucun effet.");
                    break;
            }
        }        

        public string ChoisirActionAutomatique(Guerrier adversaire)
        {
            // Liste des actions possibles
            List<string> actionsDisponibles = new List<string>();

            // Ajouter les sorts encore utilisables
            for (int i = 0; i < SortsAssignes.Count; i++)
            {
                if (SortsUtilises[i] > 0)
                {
                    actionsDisponibles.Add(SortsAssignes[i]);
                }
            }

            // Ajouter l'attaque comme option par défaut
            actionsDisponibles.Add("Attaquer");

            // Choisir une action aléatoire
            string actionChoisie = actionsDisponibles[lancerDe.Next(actionsDisponibles.Count)];

            // Exécuter l'action choisie
            Console.WriteLine($"{NomGuerrier} choisit l'action: {actionChoisie}");
            return actionChoisie;
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

                case "Coup Puissant":
                    if (SortsAssignes.Contains("Coup Puissant") && SortsUtilises[SortsAssignes.IndexOf("Coup Puissant")] > 0)
                    {
                        CoupPuissant();

                    }
                    break;
            }

            return 0; // Si l'action n'a pas été exécutée, aucun dégât. J'espère
        }
    }
}