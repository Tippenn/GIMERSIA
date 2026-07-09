<h1 align="center">Out Of Taste</h1>

<p align="center">
   <img src="https://github.com/user-attachments/assets/69cf385f-4413-4d13-a3e2-c6ae41210011" width="100%" alt="Description of the GIF">
</p>

<p align="center">
 A real-time kitchen automation game where players control robots by drag-and-dropping instruction commands to complete cooking tasks efficiently.
</p>

<p align="center">
  <img src="https://img.shields.io/badge/Engine-Unity-black?logo=unity"/>
  <img src="https://img.shields.io/badge/Language-C%23-239120?logo=c-sharp"/>
  <img src="https://img.shields.io/badge/Render_Pipeline-URP-blue"/>
  <img src="https://img.shields.io/badge/Shader-Graph-green"/>
  <img src="https://img.shields.io/badge/Gemastik-2025-orange"/>
</p>

---

## Screenshots

<p align="center">
<img width="1920" height="1080" alt="OOT0" src="https://github.com/user-attachments/assets/0080ca79-4c24-46c7-8193-1b687b297ddf" />
<img width="347" height="195" alt="OOT1" src="https://github.com/user-attachments/assets/463e3c84-72f7-4265-b150-09dfb6038913" />
<img width="347" height="194" alt="OOT2" src="https://github.com/user-attachments/assets/2120a0d0-03dd-4764-9721-4e292ce82d88" />
<img width="347" height="195" alt="OOT3" src="https://github.com/user-attachments/assets/312ec188-8291-4e4d-bf4f-851dc763ff51" />
<img width="347" height="194" alt="OOT4" src="https://github.com/user-attachments/assets/ac3d34b7-e89c-47e9-9b8e-a6300467a934" />
</p>

---

## Features

- Grid-based building placement system
- Resource management gameplay
- Building interaction system
- Dialogue system
- Save system
- Progressive puzzle-based levels
- Terraforming mechanics

---

## Project Architecture

```text
Asset
|
├── Art (Holds all the arts 2D and 3D)
├── Prefab (Holds all the prefab)
├── Resources (Holds all the data in the form of scriptable object such as the level information, dialog information, and the level select information
├── Scenes (Holds all the neccessary unity scenes)
└── Script (Holds all the scripts in the game)
    ├── Class, Enum, Interface & etc
    |   ├── Classes (Holds all the classes)
    |   ├── Enum (Holds all the enum)
    |   ├── Interface (Holds all the interface)
    |   ├── Scriptable Object (Holds all the SO)
    |   └── Util (Holds all the script needed for utility purposes such as singleton base class and save system)
    ├── Level (Holds all the script needed for the level)
    |   ├──In Game (Holds all gameplay-related scripts responsible for game logic and world interactions, including building systems, resource management, dialogue, saving, and other in-scene mechanics)
    |   └──UI (Holds scripts responsible for the user interface, including menus, HUD elements, buttons, and player interaction with interface components)
    ├── Level Select (Holds all of the script needed in level select's scene)
    ├── Main Menu (Holds all of the script needed in Main Menu's scene)
    ├── Manager (Holds all the singleton needed in a scene such as Game Manager, Level Manager, Sound Manager and etc)
    └── Testing (for development purposes only)
```
---

## Gameplay

Players control a service robot by issuing commands through a drag-and-drop interface. The robot can interact with various kitchen stations, such as ingredient stations and cutting stations, to prepare customer orders.

The objective is to complete as many orders as possible before the timer expires. At the end of each level, players are awarded a star rating based on their score, with at least **one star** required to successfully complete the stage.

---

## Controls

| Action | Input |
|---------|-------|
| Issue Commands | Mouse (Drag & Drop) |
| Interact with Stations | Mouse |
| Queue Robot Actions | Mouse |

---

## Technologies

- Unity
- C#
- Universal Render Pipeline (URP)
- Shader Graph
- Cinemachine

---

## My Contributions

As the **sole programmer**, I was responsible for the complete gameplay implementation and technical integration of the project.

### Gameplay Systems

- Developed the core gameplay systems
- Implemented the customer order queue system
- Created the robot command queue system using a drag-and-drop interface
- Developed the interaction logic for every kitchen station

### Designer Tools

- Created ScriptableObject workflows that allowed designers to configure gameplay content without modifying code

### Technical Integration

- Integrated game assets into the project
- Configured gameplay systems with audio, visual, and scene components
- Connected designer-created content with gameplay logic

### Collaboration

Worked closely with the game designer and artist to rapidly iterate on gameplay mechanics while maintaining a clean and scalable project architecture.

---

## Development

- **Duration:** 2 weeks
- **Team Size:** 3
    - Programmer (Me)
    - Game Designer
    - Artist

---

## What I Learned

This project reinforced the importance of building scalable systems from the beginning of development. By maintaining a clean architecture and modular gameplay systems, new features could be added without requiring major refactoring.

Additionally, I gained valuable experience in:

- Designing maintainable gameplay systems
- Creating reusable tools for designers through ScriptableObjects
- Structuring projects for long-term scalability
- Collaborating effectively within a multidisciplinary team
- Developing gameplay features while keeping the codebase organized and sustainable

---

## Play the Game

You can play the game on itch.io:

https://vuint.itch.io/gimersia

---

## Credits

| Role | Member |
|------|--------|
| Programmer | Steven Adicandra |
| Game Designer | Vincent Tanjaya |
| Artist | Yohanes DUns Scotus |
---
