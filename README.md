# Duels-de-guerriers_PART-II

![Image Présentation](https://raw.githubusercontent.com/TreDozier-hub/Duels-de-guerriers_PART-II/refs/heads/main/Capture%20d%E2%80%99%C3%A9cran%202025-01-04%20181850.jpg "Accueil")

<picture>
 <source media="(prefers-color-scheme: dark)" srcset="YOUR-DARKMODE-IMAGE">
 <source media="(prefers-color-scheme: light)" srcset="YOUR-LIGHTMODE-IMAGE">
 <img alt="ACCUEIL" src="https://raw.githubusercontent.com/TreDozier-hub/Duels-de-guerriers_PART-II/refs/heads/main/Capture%20d%E2%80%99%C3%A9cran%202025-01-04%20181850.jpg">
</picture>

## **DUELS DE GUERRIERS : PART II**

### **Objectifs**
1. Créer des guerriers depuis un menu.
2. Afficher la liste des guerriers.
3. Lancer un tournoi entre les guerriers.
4. Lancer un duel entre 2 guerriers.
5. Afficher la liste des gagnants et des perdants.

---

### **Affichage des différents menus et autres méthodes**
- **Méthode : `MenuPrincipal()`**
  - Objectif : Afficher un menu avec des options et exécuter l’action correspondante.

- **Méthode : `TypeCombats()`**
  - Objectif : Afficher un menu avec le choix entre "Duel" ou "Tournoi".
    - **Duel** :
      - Possibilité de choisir un nombre de guerriers à créer.
      - Sélection des 2 guerriers pour un duel.
    - **Tournoi** :
      - Si la liste des guerriers est vide, possibilité de créer des guerriers pour le tournoi.

- **Méthode : `AjouterGuerrier()`**
  - Objectif : Création de guerriers avec choix de "Type de guerrier".
  - Les guerriers sont définis par la classe `Guerrier` avec les méthodes suivantes :
    - `Attaquer()`
    - `TirerSorts()` : Tirer un nombre aléatoire de sorts (entre 1 et 3) par guerrier.
    - `Esquiver()` : 50% de chances de réussir.
    - `UtiliserPotion()` : 25% de chances de succès, restaure 5 PV.
    - `CoupPuissant()` : Réduit 10 PV, 25% de chances de succès.
      - D'autres sorts (coups) sont en préparation et indiqués dans une liste, mais pas encore implémentés :
        ```csharp
        List<string> sortsDisponibles = new List<string> { "Esquive", "Potion", "Coup Puissant", "Bouclier Magique", "Regain d'Énergie" };
        ```
    - `ChoisirActionAutomatique()` : Utilisation aléatoire des sorts pour les tournois ou duels automatiques.

  - **Types de guerriers héritant de `Guerrier`** :
    - **Nain** :
      - Hérite de la classe `Guerrier`.
      - Porte une armure (type bool).
      - Subit une perte de points de vie dès qu'il est choisi.
    - **Elfe** :
      - Hérite de la classe `Guerrier`.
      - Subit plus de dégâts que les autres types.
    - **Nazgûl** :
      - Hérite de la classe `Guerrier`.
      - Perd des points de vie dès sa création, mais inflige des coups plus violents.

    ![Duel](https://raw.githubusercontent.com/TreDozier-hub/Duels-de-guerriers_PART-II/refs/heads/main/CreationGuerriers.jpg) "Accueuil")

- **Méthode : `DuelCoupParCoup()`**
  - Permet des duels au coup par coup avec choix des sorts/coups.

- **Méthode : `LancerTournoi()`**
  - Permet de lancer des tournois en mode automatique.

- **Méthode : `DuelAutomatique()`**
  - Permet de lancer des duels en mode automatique.

> **Note** : Lors de la sélection de "Duel" dans `TypeCombats()`, après avoir choisi les guerriers combattants, il est demandé à l'utilisateur s'il souhaite effectuer le duel en mode automatique ou en mode coup par coup via un troisième menu.

![Duel](https://raw.githubusercontent.com/TreDozier-hub/Duels-de-guerriers_PART-II/refs/heads/main/CombatEnCours.jpg) "Accueuil")

---

### **Ensemble de listes**
- **Liste globale** : Pour stocker les guerriers créés.
- **Liste des gagnants** : Gérée par la méthode `SauvegarderGagnant()` (option oui/non pour sauvegarder).
- **Liste des perdants** : Gérée par la méthode `AjouterPerdant()` avec possibilité de :
  - Effacer la liste des perdants.
  - Réaffecter les perdants dans la liste principale des guerriers.

---

## **STRUCTURE FINALE DES FICHIERS**
- `Guerrier.cs` : Définit la classe de base `Guerrier`.
- `Nain.cs` : Définit la classe `Nain` qui hérite de `Guerrier`.
- `Elfe.cs` : Définit la classe `Elfe` qui hérite de `Guerrier`.
- `Nazgul.cs` : Définit la classe `Nazgûl` qui hérite de `Guerrier`.
- `Program.cs` : Contient la méthode `Main` pour tester le programme.

---
