# CUBE BURST: Unity, Practical Works 4 and 5

A university Unity project (Unity 6, URP) that combines two practical works:

- **PW4**: 3D, GameObjects and creating materials (scene `GameScene`).
- **PW5**: the game's main menu (scenes `MainMenuScene` and `OptionsMenu`).

The game is called **CUBE BURST**: a cube flies around the scene and randomly "spits out" different shapes.

---

## 1. Practical Work 4. 3D, GameObject and Materials

### Assignment

Create a 3D project and make different materials (color, Metallic/Smoothness, transparency, texture, physics material). Apply them to a Plane, Cube and Sphere. Create an animation of the cube flying around the scene and add one or more light sources to the cube. Finish the `SpawnBallFromCube()` method so that it randomly decides whether to create a new object and, if so, randomly picks which one. The spawned objects must differ in material and shape.

### What was done

- Scene `GameScene` with a cube and spheres. The original Plane from the assignment was replaced with a custom "room": the floor, back, side walls and ceiling are built from cube-shaped blocks, and the front wall is a transparent one. This keeps the spawned objects inside the scene so they can't fly out, and lets the camera look into the room through the transparent front.
- Materials in `Assets/Materials/GameMaterials`: Black, Glass, Green, Red, Transperent, and a textured material (rocky trail) for the floor.
- Four shapes that differ in both form and material: a white-transparent **cube** (the flying one), a red **sphere**, a black **pill** and a green **capsule**. The spawned shapes are prefabs with a bouncy physics material.
- A flight animation for the cube, with a light source and a spawn point as child objects.
- An Animation Event calls `SpawnBallFromCube()` in the `SpawnBall` script, which randomly decides whether to spawn and randomly picks a prefab.

---

## 2. Practical Work 5. Main Menu

### Assignment

Create a scene and build the game's main menu, with navigation to an additional menu and to another scene. Add animation to the main menu buttons.

### Done as required

- Scene `MainMenuScene`: Canvas (Scale With Screen Size), a `MainMenu` panel and three buttons: **Start**, **Options**, **Exit**.
- Button animation (Transition = Animation): the button scales up and brightens on hover (Highlighted) and "presses in" on click (Pressed).
- **Start** loads `GameScene`.
- **Options** opens the additional menu (scene `OptionsMenu`) with the message "Sorry, there are no settings options!" and a **Back** button that returns to the main menu.
- **Exit** quits the application (in the editor it stops Play mode).

### Added beyond the assignment

- **Custom UI and background:** all menu visuals are original: a dark blue gradient background, a custom colour palette (`#000D3B` and `#337C7E`), pixel-art style buttons and panel, the Orbitron font (TextMeshPro) and the CUBE BURST title.
- **3D decoration in the menus:** the main menu has a rotating ice cube with a texture and normal map. The Options scene has copies of the game prefabs (sphere, capsule, pill) with textures, added purely for aesthetics. The sphere uses a football texture so its rotation is clearly visible.
- **Pause button in `GameScene`:** one button toggles Pause/Resume using `Time.timeScale`. The button text changes, and the game continues from the same moment without restarting.
- **Frame rate limit** (`PerformanceSettings`) to reduce laptop load during testing.

---

## Scripts (`Assets/Scripts`)

| Script | Purpose |
|---|---|
| `SpawnBall` | PW4: random spawning of shapes from the cube |
| `Spin` | Rotates an object (menu decoration) |
| `UIStartButton` | Main menu: Start, Options, Exit (buttons wired in code) |
| `UIBackButton` | Options scene: Back button |
| `PauseMenu` | Pause/Resume with a single button |
| `PerformanceSettings` | Frame rate cap |

## Scenes (must be added to Build Settings)

1. `MainMenuScene` (index 0)
2. `GameScene`
3. `OptionsMenu`

## How to Run

1. Open the project in Unity 6.
2. Open `Assets/Scenes/MainMenuScene` and press Play.
3. Start launches the game, Options opens the additional menu, Exit quits.

## Notes

- `Application.Quit()` only works in a built game, so the editor uses `EditorApplication.isPlaying = false` instead.
- Buttons are connected in code rather than through the On Click() list in the Inspector.
