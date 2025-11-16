Cubescape

Petit jeu de parcours en first-person réalisé en 2023 avec Unity.
Le principe est simple : récupérer des cubes, les placer sur des réceptacles pour ouvrir des portes, progresser dans les niveaux et activer différents mécanismes.

Gameplay

  Prise et dépôt de cubes
  
  Réceptacles ouvrant des portes
  
  Activation de parcours / plateformes via des cubes spéciaux
  
  Système de portes, triggers et spawns
  
  Musique et ambiance simples
  
  Menu de pause et quelques éléments d’UI

Fonctionnalités développées (2023)

  Système complet de gestion de cube (pick up / drop)
  
  Système de portes activables
  
  Systèmes de spawns / parcours
  
  Gestion de la musique
  
  Modélisation 3D simple du réceptacle
  
  UI basique (pause menu)

Architecture & Code (état 2023)

  Ce projet représente mon niveau de l’époque.
  Certaines choses que je ne maîtrisais pas encore :
  
  Pas d’utilisation de design patterns (State, Strategy, Event Bus, etc.)
  
  Peu ou pas de coroutines
  
  Gestion des niveaux via prefabs plutôt que via plusieurs scènes (pas optimal)
  
  Scripts peu structurés et pas découpés logiquement
  
  Peu de séparation entre la logique, les données et l’UI
  
  Pas de dossier “playground” pour tester les prototypes
  
  Pas de vraie architecture scalable (pas de ScriptableObjects pour les data, pas de managers isolés, etc.)
  
  Pas de convention stricte sur les noms et l’organisation des scripts
  
  Ce dépôt reste volontairement dans son état d’origine, comme trace de mes débuts sur Unity et C#.

Ce que je fais aujourd’hui (2025)

  Depuis, ma manière de coder a complètement changé :
  
  Architecture propre
  
  Dossiers clairement structurés (Assets / Scripts / Data / ScriptableObjects / Prefabs / Scenes…)
  
  Un dossier 8_... pour les scripts essentiels afin qu’ils restent en haut
  
  Meilleure gestion des scènes
  
  Scène Playground pour prototyper
  
  Niveaux séparés en vraies scènes
  
  Code plus robuste
  
  Utilisation de design patterns (State, Singleton contrôlé, EventChannel, Factory…)
  
  Séparation propre des responsabilités (principes SOLID)
  
  Utilisation de coroutines et d’async quand nécessaire
  
  Découpage clair entre logique, données, UI
  
  Meilleure compréhension Unity
  
  Appels lifecycle
  
  ScriptableObjects pour les données
  
  Éviter les dépendances directes entre systèmes
  
  Meilleure optimisation

Projet plus récent (2025)

Un projet Unity plus récent, mieux structuré et reflétant mon niveau actuel, sera disponible bientôt.


Pourquoi ce dépôt existe encore ?

Parce que c’est un projet souvenir, mais aussi une preuve de progression.
L’objectif est de montrer :

mon évolution entre 2023 et 2025

ma capacité à analyser mon propre travail

l’amélioration de mon code et de ma méthode

mon honnêteté et ma transparence technique
