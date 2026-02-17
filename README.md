## Adventure Game

A simple text-based adventure game built with C# in VS Code using object-oriented programming principles

Project Structure

This project follows a clean architecture:

- `AdventureGame.Core`  
  Contains all game logic, world state, characters, items, and battle system.

- `AdventureGame.Console`  
  Handles user input and renders the maze to the screen.

All game rules live in the Core project as required.

---

## Controls

Use the following keys to move:

- `W` → Move Up  
- `S` → Move Down  
- `A` → Move Left  
- `D` → Move Right  

---

## 🗺️ Maze Symbols

- `#` = Wall  
- `.` = Empty space  
- `@` = Player  
- `M` = Monster  
- `W` = Weapon  
- `P` = Potion  
- `E` = Exit  

---

## ⚔️ Battle Rules

- Player starts with 100 HP (max 150).
- Base damage is 10.
- Weapons increase attack damage.
- Potions restore 20 HP immediately.
- Player attacks first in battle.
- Monster attacks if still alive.
- Battle continues until one reaches 0 HP.
- No fleeing from battle.

---

## Win and Lose Conditions

- Reach the `E` tile to win.
- If player HP reaches 0, the game ends.

---

## OOP Design

The game demonstrates:

- **Interface:** `ICharacter`
- **Inheritance:** `Weapon` and `Potion` inherit from `Item`
- **Polymorphism:** `Player` and `Monster` both implement `ICharacter`
- **Encapsulation:** Health and inventory are controlled through methods
- **Separation of Concerns:** Core logic is separate from Console UI

---

## UML Diagram

The UML diagram includes:

- ICharacter (interface)
- Player
- Monster
- Item (abstract)
- Weapon
- Potion
- Maze

The diagram shows inheritance, composition, and aggregation relationships.

---

## How to Build and Run
Open the solution file, build, and run AdventureGame.Console

