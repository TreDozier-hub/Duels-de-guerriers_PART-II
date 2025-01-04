# Duels-de-guerriers_PART-II

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


## **DUELS DE GUERRIERS : PART II**

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

## **STRUCTURE FINALE DES FICHIERS**
- `Guerrier.cs` : Définit la classe de base `Guerrier`.
- `Nain.cs` : Définit la classe `Nain` qui hérite de `Guerrier`.
- `Elfe.cs` : Définit la classe `Elfe` qui hérite de `Guerrier`.
- `Program.cs` : Contient la méthode `Main` pour tester le programme.

---

