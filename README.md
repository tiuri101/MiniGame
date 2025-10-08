# MiniGame (Unity 2D Platformer)
**MiniGame** is a Unity 2D sample that demonstrates the fundamentals of a platformer: a player character with horizontal movement, flipping, and jumping; solid and one-way platforms; collectible coins with trigger detection; and a UI counter plus background audio. The project contains two bitmaps and a sound file.

## Instructions

### 1) Project Setup
1. Unity Hub → **New Project** → **2D (URP/Universal 2D)** → Name: **MiniGame** → **Create**.  
2. In **Game** view, set **Aspect** to **16:9**.

### 2) Folder Structure (Project window)
1. Create folders: `Materials/`, `Prefabs/`, `Scripts/`, `Sounds/`, `Sprites/`.
2. Download images and sound file and add to the project

### 3) Sprites & Import Settings
1. Select each sprite in **Inspector**:
   - **Texture Type**: *Sprite (2D and UI)*
   - **Sprite Mode**: *Polygon*
   - **Pixels Per Unit (PPU)**: **4**
   - Open **Sprite Editor** → for the diamond sprite, set **4 sides** → **Apply**.

### 4) Player Prefab
1. **Create Player**
   - Create a new Prefab in the Project and open it.
   - **Add Component**: **Sprite Renderer** (assign the square sprite and change its color to black).
   - **Add Component**: **Rigidbody2D**.
   - **Add Component**: **BoxCollider2D**.
2. **Physics Material**
   - Project: **Create > 2D > Physics Material 2D** → name **PlayerMat**.
   - Set **Friction** = `0`, **Bounciness** = `0`.
   - Assign **PlayerMat** to the **Player’s BoxCollider2D → Material**.
3. **Eyes (child sprites)**
   - Player Prefab **Create Empty** → rename **Eye Left**.
   - **Add Component**: **Sprite Renderer**. Choose the square sprite.
   - **Transform Scale**: `(0.1, 0.1, 1)`, **Order in Layer**: `1`.
   - Duplicate as **Eye Right**.
   - Position both in the right half of the face.
4. **Place in the scene**

### 5) Platforms & Boundaries
1. **Platform Prefab**
   - Create a new Prefab in the Project and open it.
   - **Add Component**: **BoxCollider2D**.
   - **Add Component**: **Sprite Renderer** (assign the square sprite and change its color to dark grey).
2. **Place Platforms**
   - Add several **Platform** instances to build your level.
3. **One-Way Platform**
   - Duplicate a platform in the scene.
   - **Add Component**: **PlatformEffector2D**.
   - On the platform’s **BoxCollider2D**, tick **Used By Effector**.
   - To visually indicate, set the Sprite Renderer **Color alpha** ≈ `0.4`.
4. **Level Boundaries**
   - **GameObject > Create Empty** → rename **Bounds**.
   - Add four children: **Left**, **Right**, **Top**, **Bottom** with **BoxCollider2D** sized to frame the camera area.

### 6) Coin Prefab
1. **Create Coin**
   - Create a new Prefab in the Project and open it.
   - **Add Component**: **CircleCollider2D** → tick **Is Trigger**.
   - **Add Component**: **Sprite Renderer** (assign the diamond sprite and change its color to gold).
2. **Tag**
   - Create a new **Tag** named **Coin** and assign it to the Coin prefab.
3. **Place Coins**
   - Place several coins in the scene.

### 7) UI: Coin Counter
1. **Create Text (Legacy)**
   - **GameObject > UI > Text** (Legacy). Unity creates a **Canvas** and **EventSystem**.
   - Select the text → rename **CountText**.
   - Set **Text**: `Count: 0`, **Font Size**: `50`, **Color**: white, adjust size to fit text.
   - Move to the top left corner.

### 8) Layers & Ground Check
1. **Ground Layer**
   - **Edit > Project Settings > Tags and Layers** → add layer **Ground**.
   - Assign **Ground** to the Platform prefab.
2. **GroundCheck Object**
   - Right-click **Player** → **Create Empty** → rename **GroundCheck**.
   - Position slightly below the player.

### 9) Gameplay Script (High-Level Checklist)
- Create **PlayerScript** in `Scripts/` and attach it to **Player**.
- Implement:
  - **Sideways movement**.
  - **Flip** the sprite based on movement direction.
  - **Jumping**.
  - **Ground check**.
  - **Remaining jumps**.
  - **Coin collecting**: on trigger with objects tagged **Coin**, **increment count** and **update UI text**.
- Set attributes
  - **speed = 7**
  - **jumpForce = 7**
  - **remaining jumps = 1**
  - **GroundCheck** with the transform of the **GroundCheck** game object, **radius = 1**, and **Ground** layer
  - **countText** with the UI element

### 10) Audio
1. **Background Music**
   - **Add**: **Audio Source**.
   - Assign a music **Audio Clip**, tick **Loop**.
