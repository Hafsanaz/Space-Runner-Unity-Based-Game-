# Immunity Runner (DM-Game-Project)

A 2D endless side-scrolling runner built in Unity, with a **vaccine-vs-virus** theme: you play as a syringe dodging angry virus obstacles, grabbing immunity-booster pills to fight back.

## 🎮 Gameplay

- The player moves **up and down** (vertical movement only) to dodge virus obstacles that spawn from the right edge of the screen and scroll left.
- Colliding with a virus ends the run — unless the player has picked up an **Immunity Booster** pill, which grants **temporary immunity** (7 seconds by default) during which viruses are destroyed on contact instead of killing the player.
- An on-screen immunity timer counts down and flashes red as it's about to run out.
- **Score** increases automatically the longer the player survives.
- Viruses spawn faster and boosters appear at a set chance as the run goes on — the game gets progressively harder over time.
- On death, a **Game Over panel** appears with a restart option that reloads the scene.
- Looping background, scrolling camera, and background music/SFX for game start, gameplay, and game over.

## 🖼️ Assets Preview

> These images live in `Assets/Sprites/` in this repo, so they'll render automatically once this README sits alongside them on GitHub.
>
> Note: `Assets/TextMesh Pro/Sprites/EmojiOne.png` is a stock emoji sprite sheet bundled with Unity's TextMesh Pro package (used for rendering emoji in UI text) — it's a third-party library asset, not custom art made for this game, so it isn't featured above.

## 🛠️ Tech Stack

- **Engine:** Unity **6000.0.46f1** (Unity 6)
- **Render Pipeline:** Universal Render Pipeline (URP), 2D
- **Language:** C#
- **Packages:** Unity Input System, TextMeshPro, 2D feature set, Unity UGUI

## 📁 Project Structure

```
Assets/
├── Scenes/
│   └── RunnerX.unity          # Main game scene
├── Scripts/
│   ├── Player.cs              # Player movement, booster/immunity, collision handling
│   ├── Obstacle.cs            # Obstacle (virus) movement and collision behavior
│   ├── SpawnObstacle.cs       # Obstacle/booster spawning and difficulty scaling
│   ├── ScoreManager.cs        # Score tracking and display
│   ├── GameOver.cs            # Game over panel and restart logic
│   ├── LoopingBackground.cs   # Scrolling background effect
│   ├── Camera Movement.cs     # Auto-scrolling camera
│   └── BackgroungMusic.cs     # Persistent background music across scenes
├── Prefabs/
│   ├── Obstacle.prefab
│   └── ImmunityBooster.prefab
├── Sprites/                   # Player, obstacle, background, booster, and UI art
├── Settings/                  # URP render pipeline settings
└── TextMesh Pro/               # TMP font/shader assets (incl. stock EmojiOne library)

ProjectSettings/                # Unity project configuration
Packages/                       # Unity package manifest and lockfile
```

## 🚀 Getting Started

### Prerequisites
- [Unity Hub](https://unity.com/download)
- Unity Editor version **6000.0.46f1** (Unity 6) — install this exact version (or close to it) via Unity Hub for best compatibility

### Setup
1. Clone the repository:
   ```bash
   git clone https://github.com/Hafsanaz/DM-Game-Project-.git
   cd DM-Game-Project-
   ```
2. Open **Unity Hub** → **Add project from disk** → select the project folder.
3. Let Unity install/import the packages listed in `Packages/manifest.json`.
4. Open the scene at `Assets/Scenes/RunnerX.unity`.
5. Press **Play** in the Unity Editor to run the game.

### Controls
- **Up Arrow / Down Arrow (or configured vertical input)** — move the player up/down

## 👤 Author

**Hafsa Naz**
[GitHub Profile](https://github.com/Hafsanaz)

## 📄 License

This project is intended for educational/academic purposes.
