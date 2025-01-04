
## **DUELS DE GUERRIERS : PART I**

### **1. Création de la Classe Guerrier**
- **Objectif :** Créer une classe `Guerrier` qui servira de base pour notre duel.
- **Nom du fichier :** `Guerrier.cs`
- **Étapes détaillées :**
  1. **Définir les propriétés nécessaires :**
     - **Attributs :**
       - `private string nom` : Le nom du guerrier.
       - `private int pointsDeVie` : Les points de vie (PV) du guerrier.
       - `private int nbDesAttaque` : Le nombre de dés d’attaque.
  2. **Créer un constructeur :**
     - Nom : `Guerrier(string nom, int pointsDeVie, int nbDesAttaque)`
     - Fonction : Initialiser les attributs.
  3. **Ajouter des getters et setters :**
     - Méthodes publiques :
       - `public string GetNom()`
       - `public int GetPointsDeVie()`
       - `public void SetPointsDeVie(int pointsDeVie)`
       - `public int GetNbDesAttaque()`

---

### **2. Ajout des Méthodes Essentielles**
- **Objectif :** Ajouter les actions que le guerrier peut effectuer.
- **Nom des méthodes :**
  1. `public void AfficherInfos()` :
     - **But :** Afficher dans la console les informations du guerrier au format `Nom{PV=xx}`.
  2. `public int Attaquer()` :
     - **But :** Simuler une attaque en lançant des dés (valeurs aléatoires entre 1 et 6 pour chaque dé).
  3. `public void SubirDegats(int degats)` :
     - **But :** Réduire les points de vie du guerrier lorsque des dégâts sont reçus.
- **Sous-étapes :**
  1. Écrire chaque méthode dans `Guerrier.cs`.
  2. Tester chaque méthode indépendamment (par exemple, afficher les PV après avoir subi des dégâts).

---

### **3. Test de la Classe Guerrier**
- **Objectif :** Tester les fonctionnalités de la classe `Guerrier`.
- **Nom du fichier :** `Program.cs`
- **Sous-étapes :**
  1. Créer deux guerriers dans la méthode `Main` :
     - Exemple : `Guerrier lancelot = new Guerrier("Lancelot", 35, 3);`
     - Exemple : `Guerrier galahad = new Guerrier("Galahad", 30, 4);`
  2. Faire attaquer les guerriers à tour de rôle.
     - Appeler `Attaquer()` pour infliger des dégâts.
     - Appeler `SubirDegats(int degats)` pour appliquer les dégâts.
  3. Afficher l’état des guerriers après chaque attaque avec `AfficherInfos()`.

---

## **DUELS DE GUERRIERS : PART II**

### **1. Ajout de Classes Spécialisées**
- **Objectif :** Ajouter des variantes de guerriers avec des capacités uniques en utilisant la notion d'heritage.
- **Fichiers à créer :** 
  - `Nain.cs` pour la classe `Nain`
  - `Elfe.cs` pour la classe `Elfe`
- **Étapes détaillées :**
  1. **Créer la classe `Nain` :**
     - Hérite de : `Guerrier`
     - **Attribut spécifique :**
       - `private bool armureLourde` : Détermine si le Nain porte une armure lourde.
     - **Méthode spécifique :**
       - Redéfinir `SubirDegats(int degats)` :
         - Si `armureLourde` est activée, les dégâts sont divisés par 2.
  2. **Créer la classe `Elfe` :**
     - Hérite de : `Guerrier`
     - **Méthode spécifique :**
       - Redéfinir `Attaquer()` :
         - Toujours infliger au moins un minimum de dégâts (par exemple, le nombre de dés d'attaque).

---

### **2. Test des Classes Nain et Elfe**
- **Objectif :** Tester les spécificités des classes spécialisées.
- **Nom du fichier :** `Program.cs`
- **Sous-étapes :**
  1. Créer un Nain et un Elfe dans `Main` :
     - Exemple : `Nain gimli = new Nain("Gimli", 40, 2, true);`
     - Exemple : `Elfe legolas = new Elfe("Legolas", 25, 5);`
  2. Simuler un duel entre le Nain et l’Elfe.
     - Tester les règles spécifiques :
       - L’armure lourde du Nain réduit les dégâts.
       - L’Elfe inflige toujours des dégâts minimums.

---


## **DUELS DE GUERRIERS : PART III**

### **Objectifs**
1. Créer des guerriers depuis un menu.
2. Afficher la liste des guerriers.
3. Lancer un tournoi entre les guerriers.

---

### **Fichier : Program.cs**

#### **Étape 1 : Afficher le Menu Principal**
- Méthode : `AfficherMenuPrincipal()`
- Objectif : Afficher un menu avec des options et exécuter l’action correspondante.

---

#### **Étape 2 : Ajouter un Guerrier**
- Méthode : `AjouterGuerrier()`
- Objectif : Permettre la création de guerriers personnalisés.

---

#### **Étape 3 : Afficher la Liste des Guerriers**
- Méthode : `AfficherListeGuerriers()`
- Objectif : Afficher les informations de tous les guerriers créés.

---

#### **Étape 4 : Lancer un Tournoi**
- Méthode : `LancerTournoi()`
- Objectif : Faire combattre les guerriers jusqu’à ce qu’il en reste un.

---

### **Nouvel Attribut : Liste Globale**
- Ajouter cette liste globale pour stocker les guerriers créés :


Avec ces méthodes courtes et précises, le programme devient interactif et intuitif pour l’utilisateur, tout en restant simple à implémenter.

## **STRUCTURE FINALE DES FICHIERS**
- `Guerrier.cs` : Définit la classe de base `Guerrier`.
- `Nain.cs` : Définit la classe `Nain` qui hérite de `Guerrier`.
- `Elfe.cs` : Définit la classe `Elfe` qui hérite de `Guerrier`.
- `Program.cs` : Contient la méthode `Main` pour tester le programme.

---
