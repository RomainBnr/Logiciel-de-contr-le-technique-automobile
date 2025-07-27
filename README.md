# Logiciel de Contrôle Technique Automobile

## 📋 Description

Application Windows Forms développée en C# pour la gestion des contrôles techniques automobiles. Ce logiciel permet aux clients d'enregistrer leurs véhicules et aux techniciens de réaliser et documenter les contrôles techniques.

## 🚀 Fonctionnalités

### Module Client
- **Inscription et connexion** des clients
- **Enregistrement de véhicules** avec toutes les informations techniques
- **Consultation des résultats** de contrôles techniques
- **Historique des défaillances** détectées
- **Déconnexion sécurisée**

### Module Technicien
- **Connexion dédiée** aux techniciens
- **Chargement de tous les véhicules** à contrôler
- **Sélection de véhicules** avec affichage des informations client/véhicule
- **Enregistrement des défaillances** avec :
  - Points de contrôle (freinage, éclairage, etc.)
  - Niveaux de gravité (RAS, défaillance majeure, etc.)
  - Descriptions détaillées
- **Calcul automatique du statut final** :
  - "Favorable" si toutes les défaillances sont RAS
  - "Contre-visite" si au moins une défaillance n'est pas RAS
- **Déconnexion sécurisée**

### Système d'authentification
- **Inscription sécurisée** avec validation email
- **Mots de passe hachés** (SHA256)
- **Connexion différenciée** client/technicien
- **Gestion des sessions utilisateur**

## 🛠️ Technologies utilisées

- **Langage** : C# 12.0
- **Framework** : .NET 8
- **Interface** : Windows Forms
- **Base de données** : SQL Server
- **Chiffrement** : SHA256 pour les mots de passe

## 🗄️ Structure de la base de données

### Tables principales :
- **Client** : Informations des clients (nom, prénom, email, mot de passe)
- **Technicien** : Informations des techniciens
- **Vehicule** : Données techniques des véhicules
- **ControleTechnique** : Sessions de contrôle avec statut final
- **PointControle** : Points de vérification (freins, éclairage, etc.)
- **Gravite** : Niveaux de gravité des défaillances
- **Defaillance** : Défaillances détectées lors des contrôles
- **Controle_Defaillance** : Table de liaison contrôle/défaillance

## 📁 Structure du projet

Logiciel de contrôle technique automobile/ 

├── loginForm.cs              
# Formulaire de connexion 
├── registerForm.cs           
# Formulaire d'inscription 
├── moduleClientForm.cs       
# Interface client 
├── moduleTechnicien.cs       
# Interface technicien 
├── *.Designer.cs            
# Fichiers de conception UI 
└── *.resx 
# Ressources des formulaires

## ⚙️ Configuration

### Base de données
Modifiez la chaîne de connexion dans chaque formulaire :
```c#
private string connectionString = "Server=VOTRE_SERVEUR;Database=BDDControleTechnique;User ID=VOTRE_USER;Password=VOTRE_PASSWORD;TrustServerCertificate=True;";
```

## 🔧 Installation

1. **Cloner le projet**
2. **Configurer SQL Server** avec la base de données
3. **Modifier les chaînes de connexion**
4. **Compiler et exécuter** l'application

## 👥 Types d'utilisateurs

- **Clients** : Propriétaires de véhicules
- **Techniciens** : Professionnels réalisant les contrôles

## 📝 Notes techniques

- **Gestion asynchrone** des opérations base de données
- **Transactions SQL** pour la cohérence des données
- **Validation côté client** et serveur
- **Interface responsive** avec feedback utilisateur
- **Gestion d'erreurs** complète avec messages explicites

---

## Auteurs 

* **Hugo** - [Hugoxplr](https://github.com/hugoxplr)
* **Romain** - [RomainBnr](https://github.com/RomainBnr)
