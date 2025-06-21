# 🧙‍♂️ RPG Game — The Epic Quest of the Hero

Welcome to **RPG_Game**, a terminal-based role-playing adventure where you battle devils, level up, and unlock powerful game modes. Your mission? Survive. Fight. Protect your people. And prove you're the strongest hero in the land.

---

## 🎮 Game Overview

This is a classic turn-based **RPG** game that runs directly in your terminal or command prompt. You start as a simple hero, fighting devils one by one. As you progress through levels, you earn coins, heal yourself, and become stronger.

Once you've proven your strength by reaching **Level 4**, you unlock **Arcade Mode** — an endless wave survival mode where enemies keep coming until you die.

---

## 🕹️ Features

- ⚔️ **Turn-based battles**: Choose to attack or heal each turn.
- 😈 **Devil Enemies**: Each enemy grows stronger as you progress.
- 💰 **Coin System**: Earn coins after each win.
- 🔓 **Arcade Mode**: Unlocked after level 3 — survive as long as possible in a never-ending fight.
- 💾 **Progress Saving**: Your level and arcade progress are saved in a file (`StateOfHero.txt`).
- 📊 **Colorful Terminal UI**: Enhanced console experience with colors and animations.

---

## 🚀 How to Play

1. **Start the game** from your terminal by running the executable or the main entry point.
2. You'll enter battles where you choose to:
   - `1` → Attack the enemy.
   - `2` → Heal yourself.
3. Defeat devils to level up.
4. After **Level 3**, unlock **Arcade Mode** for endless battles.
5. When you die, the game saves your progress and ends the current session.

---

## 🛠️ How to Run

1. Clone or download the project:
   ```bash
   git clone https://github.com/yourusername/rpg-game.git
   cd rpg-game
   ```

2. Open the solution in **Visual Studio** or build using CLI:
   ```bash
   dotnet build
   ```

3. Run the game:
   ```bash
   dotnet run
   ```

---

## 📁 Files of Interest

- `Program.cs` — Game entry point
- `Hero.cs` — The player character logic
- `Devil.cs` — Enemy AI logic
- `Arcade.cs` — Handles Arcade Mode logic
- `Save.cs` — Save/load player progress
- `Info.cs` — Game introduction and details
- `StateOfHero.txt` — Save file (generated automatically)

---

## 🧠 Credits & Notes

- Developed by **[Me]**
- Inspired by classic RPG mechanics
- Built using **.NET Console Application**

---

### 🔥 Get ready to begin your journey, hero. The world needs saving!
