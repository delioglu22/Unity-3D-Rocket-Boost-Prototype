# Obstacle Dodge

A 3D physics-based prototype in Unity where the player pilots a rocket through obstacle courses, avoiding hazards and reaching goal zones while managing thruster dynamics and rotational physics.

## 🎮 Key Features

### 1. Physics-Based Movement (Movement.cs)
* **Input System:** Real-time keyboard input with action maps for thrust and rotation control
* **Rigidbody Physics:** `AddRelativeForce()` applies thrust relative to rocket orientation with frame-rate independent calculations
* **Smooth Rotation:** Transform-based Z-axis rotation with freeze flags to prevent unwanted spin

### 2. Collision & State Management (CollisionHandler.cs)
* **Tag-Based Detection:** `OnCollisionEnter()` differentiates between "Hazard" and "Finish" collisions
* **State Flags:** Boolean management (`isControllable`, `isCollidable`) for crash and success sequences
* **Audio & Particles:** Plays SFX and triggers particle effects on collision events

### 3. Scene Management
* **Dynamic Level Loading:** `SceneManager.LoadScene()` with auto-loop to first scene on completion
* **Delayed Transitions:** `Invoke()` for time-delayed scene changes after crash/success
* **Debug Tools:** L key skips level, C key toggles collision, ESC quits

### 4. Environmental Hazards (Oscillator.cs)
* **Moving Obstacles:** `Mathf.PingPong()` creates smooth oscillating hazard movement
* **Configurable Paths:** Adjustable vectors and speeds for obstacle patterns

## 🕹️ Controls

* **Space:** Apply Thrust
* **Left Arrow:** Rotate Left
* **Right Arrow:** Rotate Right
* **L (Debug):** Skip to next level
* **C (Debug):** Toggle collision
* **ESC:** Quit

## 🎯 Gameplay

- **Thrust System:** Physics-based acceleration with configurable power
- **Rotation Control:** Independent axis control for precise navigation
- **Static & Moving Hazards:** Obstacles with oscillating patterns for varied challenge
- **Level Progression:** Scene-based levels with auto-loop on completion
- **Crash/Success:** Immediate feedback with audio, particles, and state transitions

## 🛠️ Installation & How to Run

1. Clone this repository:
   ```bash
   git clone <https://github.com/delioglu22/Unity-3D-Rocket-Boost-Prototype.git>
2. Open with Unity 2021.3 LTS or later
3. Navigate to `Assets/Scenes/` and open `Under.unity` or `Over.unity`
4. Press **Play** to start

## 📁 Project Structure

```
Assets/
├── Scripts/
│   ├── Movement.cs                    # Thrust and rotation
│   ├── CollisionHandler.cs            # Collision detection
│   ├── Oscillator.cs                  # Hazard movement
│   └── QuitApplication.cs             # Exit handling
├── Prefabs/
│   ├── Player Rocket.prefab           # Player
│   ├── Environment/                   # Hazards and finish
│   ├── Particles/                     # Effects (engine, explosion, success)
│   ├── Main Camera.prefab
│   └── Directional Light.prefab
├── Scenes/
│   ├── Under.unity                    # Level 1
│   └── Over.unity                     # Level 2
├── Materials/                         # Colors and effects
├── Audio/                             # SFX clips
└── Settings/                          # Input and rendering config
```

## 🔧 Technical Stack

- **Engine:** Unity 2021.3 LTS+
- **Input:** UnityEngine.InputSystem
- **Physics:** Rigidbody force-based movement
- **Audio:** AudioSource with SFX clips
- **Particles:** Built-in Particle System
- **Rendering:** Universal Render Pipeline (3D)
- **Camera:** Cinemachine follow system

## 📝 Notes

- **FixedUpdate():** Ensures consistent physics calculations
- **AddRelativeForce():** Keeps thrust aligned with rocket orientation
- **OnCollisionEnter():** Single-frame collision detection
- **PlayOneShot():** Allows overlapping sound effects
- **Tag-Based Classification:** String comparison for hazard/finish detection
- **Invoke():** Time-delayed execution for scene transitions
