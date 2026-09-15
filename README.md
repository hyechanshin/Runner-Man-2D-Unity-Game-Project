# PaliPali 🏃💨

**빨리빨리** — Korean for *"hurry, hurry."*

A 2D endless runner built in Unity where a food-delivery runner sprints through a dusk-lit Korean street, dodging enemies and grabbing ingredients to survive as long as possible.

> 🎥 Trailer: `https://youtu.be/MnwQKv1vyFM`

> GamePlay:  `https://play.unity.com/en/games/a0448229-50a7-46d4-8f90-7574e6229f9e/palipali`
---

## Gameplay

- **One-button control** — jump with `Space`, mouse click, or a tap. Works identically on keyboard and touch.
- **Survive and score** — score is built from how long you last plus every ingredient you grab. The run keeps getting faster the longer you survive.
- **Hearts** — get hit by an enemy and lose a heart; eat a food item to heal one back. Lose your last heart and the run ends.
- **Invincibility** — grab the golden cabbage (`goldbaechu`) for a few seconds of invincibility.
- **Per-difficulty high scores** — your best run on each difficulty is saved locally.

### Runners

| Runner | Hearts | Jump Force | Notes |
|---|---|---|---|
| Runner | 3 | 15 | Forgiving, easier to control |
| Runner F | 2 | 20 | Higher, more precise jumps — one less hit to give |

### Difficulty

| Tier | Start Speed | Max Speed | Score Multiplier |
|---|---|---|---|
| Easy | 5 | 40 | x1.0 |
| Normal | 8 | 70 | x1.2 |
| Hard | 12 | 100 | x1.5 |

### Controls

| Screen | Input | Action |
|---|---|---|
| Intro | `←` / `→` | Choose difficulty |
| Intro | `↑` / `↓` | Choose runner |
| Intro | `Space` / Tap | Start (from the Tap-to-Start prompt) |
| Playing | `Space` / Tap | Jump |
| Dead | `Space` / Tap | Restart |

---

## Tech Stack

- **Engine:** Unity 6000.5 (Universal Render Pipeline, 2D)
- **Language:** C#
- **Input:** Unity Input System — unified `TapInput` layer for keyboard, mouse, and touch
- **Physics:** Unity 2D physics (`Rigidbody2D` / `Collider2D`)
- **Persistence:** `PlayerPrefs` for per-difficulty high scores

### Core Scripts

- `Player.cs` — jump logic, hit/heal/invincibility via `OnTriggerEnter2D`
- `Spawner.cs` — spawns buildings, enemies, food, and gold on a randomized timer
- `Mover.cs` / `Destroyer.cs` — moves spawned objects across the screen and cleans them up once off-screen
- `BackgroundScroll.cs` — scrolls the sky/building/platform layers independently for parallax
- `GameManager.cs` — singleton driving `GameState` (`Intro` / `Playing` / `Dead`), spawner activation, and restart
- `Heart.cs` — swaps each heart icon's on/off sprite based on current lives

---

## Getting Started

1. Install [Unity Hub](https://unity.com/download) and Unity **6000.5.9f1** (or later 6000.5.x).
2. Clone the repo:
   ```bash
   git clone https://github.com/hyechanshin/Runner-Man-2D-Unity-Game-Project.git
   ```
3. Open the project folder through Unity Hub.
4. Open `Assets/Scenes/Main.unity` and press Play.

---

## Credits & Assets

- **Base template:** free runner project by [Nomad Coder](https://on.unitysquare.co.kr/3ZMF3O7)
- **Character art:** generated with Google Gemini, background removed with [remove.bg](https://www.remove.bg/)
- **Music:** DanAndPhil — *All Beats* (copyright-free)
  - [You Won't Believe What Happened](https://youtu.be/u6xy-vXIGIY) (background track)
  - [Ready Player Two](https://youtu.be/OTeHBM7h7Hw) (run start)
- **SFX:** 5 effects (jump, hit, eat, power-up, game over) made with [sfxr.me](https://sfxr.me/)

---

## Known Limitations

- No dedicated mobile build target yet, though touch input already works.
- Player defeat currently plays a knockback impulse and relies on `GameManager` to fully end the run.

---

## Author

**Hyechan Shin**
