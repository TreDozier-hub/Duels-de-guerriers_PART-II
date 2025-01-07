# Duels-de-guerriers_PART-II

![Image Présentation](Capture%20d%E2%80%99%C3%A9cran%202025-01-04%20181850.jpg "Accueuil")

<picture>
 <source media="(prefers-color-scheme: dark)" srcset="YOUR-DARKMODE-IMAGE">
 <source media="(prefers-color-scheme: light)" srcset="YOUR-LIGHTMODE-IMAGE">
 <img alt="ACCUEUIL" src="[/Duels-de-guerriers_PART-II/refs/heads/main/Capture d’écran 2025-01-04 181850.jpg](https://raw.githubusercontent.com/TreDozier-hub/Duels-de-guerriers_PART-II/refs/heads/main/Capture%20d%E2%80%99%C3%A9cran%202025-01-04%20181850.jpg)">
</picture>


## **DUELS DE GUERRIERS : PART II**

### **Objectifs**
1. Créer des guerriers depuis un menu.
2. Afficher la liste des guerriers.
3. Lancer un tournoi entre les guerriers.

---

### **Fichier : Program.cs**

#### **Affichage dess différents menu et autres méthodes**
- Méthode : `MenuPrincipal()`
  . Objectif : Afficher un menu avec des options et exécuter l’action correspondante.
- Méthode : `TypeCombats()`
  . Objectif : Afficher un menu avec le choix entre "Duel" ou "Tournoi".
  --> Duel : Possibilite de choisir un nbr de guerriers à créer et sélection des 2 guerriers pour un duel
  --> Tournoi : Si liste guerriers vide possibilité de creer ds guerriers pout le tournoi
- Méthode : `AjouterGuerrier()`
  . Objectif : Création de guerriers avec choix de "Type de guerrier"
  --> Guerriers : La Class Guerriers avec les différentes methodes :
    _⦁	Attaquer()
    ⦁	 TirerSorts() --> Tirer un nombre aléatoire de sorts entre 1 et 3 par guerriers
    ⦁	Esquiver() --> Boll 1 fois sur 2
    ⦁	UtiliserPotion() --> avec 25% de chance que ça fonctionne. Restore 5 PV
    ⦁	CoupPuissant --> "Coup de hâche", 10 PV de moins - 25% de chance que ça fonctionne 
	     Il y  d'autres sorts (coups) en prépartion qui sont indiqués dans ma liste, mais pas encore mis en Methodes._
      ```List<string> sortsDisponibles = new List<string> { "Esquive", "Potion", "Coup Puissant", "Bouclier Magique", "Regain d'Énergie" };```
    _⦁	ChoisirActionAutomatique() --> pour pouvoir utiliser les sorts (coups) aléatoirement pour les tournois ou duels automatique_

  --> Nain : Qui hirite de la Class Guerriers avec quelques subtilité : Le port d'une armure (type bool) avec perte de points de vie si le Nain est    choisie
  --> Elfe : Qui hirite de la Class Guerriers. Celui-ci subit plus de dégats
  -- Nazgûle : Qui hirite de la Class Guerriers. Perte de point dès la création du guerrier en contre partie ces coup sont plus violent

- Méthode DuelCoupParCoup()
   . Permet des duels au coup par coup avec choix des sorts/coups
- Méthode LancerTournoi()
   . Permet des tournoi en automatique
- Méthode DuelAutomatique()
   . Permet des duel en automatique
_Il est important de signaler que à la séléction dde Duel dans "TypeCombats()"; après sélections des guerriers combattants il est demandé aux l'utilisateurs s'ils souhaite effecter e duel en automatique ou en coup pour coup via un 3 ème menu._

#### **Ensemble de listes**
- Ajout d'une liste globale pour stocker les guerriers créés
- Ajout d'une liste de gagnants avec la methode SauvegarderGagnant() ( au choix o/n)
- Ajout d'une liste de perdants avec la methode AjouterPerdant() pour y stocker les perdants avec possibilité d'affacer la liste et du coup  les réafecter dans la liste de guerriers principale

## **STRUCTURE FINALE DES FICHIERS**
- `Guerrier.cs` : Définit la classe de base `Guerrier`.
- `Nain.cs` : Définit la classe `Nain` qui hérite de `Guerrier`.
- `Elfe.cs` : Définit la classe `Elfe` qui hérite de `Guerrier`.
- `Nazgul.cs` : Définit la classe `Nazgûl` qui hérite de `Guerrier`.
- `Program.cs` : Contient la méthode `Main` pour tester le programme.

---
