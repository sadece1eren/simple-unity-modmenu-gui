# Simple Unity Mod Menu GUI

A lightweight, customizable mod menu framework for Unity games.

Designed for modders who want something clean, expandable, and easy to work with — without bloated UI systems or unnecessary complexity.

---

## ✨ Features

- 🗂 **Tabbed Interface** — Organize features across multiple tabs  
- 🖱 **Draggable Window** — Move the menu anywhere on screen  
- 🔁 **Loop System** — Checkbox-based continuous features  
- ⌨ **Keyboard Controls** — Toggle + unload shortcuts  
- 🔄 **Persistent Across Scenes** — Survives scene changes  
- 🎨 **Custom Styling** — Easily modify colors and layout  

---

# 🚀 Quick Start

## 1️) Installation

Drop both files into your Unity project or mod loader:

```
Loader.cs   → Initializes the menu
Mod.cs      → Contains UI and feature logic
```

---

## 2️) Change the Namespace

Update the namespace in **both files** to match your mod:

```csharp
namespace YourMenuName  // Change this in both files
```

---

## 3️) initialize the Menu

Call this somewhere in your mod initialization:

```csharp
Loader.Init();
```

That’s it. The menu is now loaded.

---

# Controls

| Key      | Action |
|----------|--------|
| Page Up  | Toggle menu visibility |
| End      | Unload menu completely |

You can modify these inside the `KeyBoardStuff()` method in `Mod.cs`.

---

# Adding Features

---

## Buttons (One-Time Actions)

Buttons execute code once when clicked.

Add inside `menu()` or `menu2()`:

```csharp
if (GUILayout.Button("Your Button", GUILayout.Width(145), GUILayout.Height(52)))
{
    Debug.Log("Button clicked!");
}
```

**Use buttons for:**
- Teleporting
- Spawning items
- Giving currency
- Triggering events
- Any one-time execution

---

## Continuous Features (Loops)

For features like:
- God Mode
- ESP
- Speed modifications
- Infinite ammo

### 1️) Add a Boolean Variable

```csharp
private bool myFeature = false;
```

---

### 2️) Add a Toggle in the Menu

```csharp
myFeature = GUILayout.Toggle(myFeature, "My Feature", GUILayout.Width(145), GUILayout.Height(22));
```

---

### 3️) Add Logic Inside `Update()`

```csharp
void Update()
{
    if (myFeature)
    {
        // Runs every frame while enabled
    }
}
```

---

# Adding More Tabs

---

### 1️) Create a New Menu Method

```csharp
private void menu3(int id)
{
    // Copy structure from menu() or menu2()
    // Add your content here
}
```

---

### 2️) Add It to the `OnGUI()` Switch Statement

```csharp
case 2:
    windowRect = GUI.Window(0, windowRect, menu3, "YAPYAP Menu V 1.0");
    break;
```

---

### 3️) Add a Tab Button

```csharp
if (GUILayout.Button("Menu 3", GUILayout.Width(200f)))
    selectedTab = 2;
```

---

# Customization

---

## Change Menu Colors

Default theme is dark blue. Modify inside your menu methods:

```csharp
Color hoverColor = new Color(0f, 51f / 255f, 102f / 255f); // RGB (0-1 range)
```

---

## Change Window Size

```csharp
windowRect.width = 480f;
windowRect.height = 430f;
```

---

## Change Window Title

```csharp
windowRect = GUI.Window(0, windowRect, menu, "Your Menu Name V 1.0");
```

---

## Change Button Size

```csharp
GUILayout.Button("Button", GUILayout.Width(145), GUILayout.Height(52));
```

---

# File Structure

```
YourMod/
├── Loader.cs   // Menu initialization & persistence
└── Mod.cs      // Menu UI and feature logic
```

---

# Code Architecture

## Loader.cs

- Creates a persistent `GameObject`
- Attaches the `Mod` component
- Prevents destruction between scenes
- Handles unload functionality

---

## Mod.cs

- Stores menu state (visibility, selected tab, toggles)
- `KeyBoardStuff()` → Handles keyboard input
- `Update()` → Runs continuous features
- `OnGUI()` → Draws the UI
- `menu()` / `menu2()` → Tab content
- `HandleDragging()` → Window drag behavior

---

# Example: Speed Boost Feature

### Step 1 — Add Variable

```csharp
private bool speedBoost = false;
```

---

### Step 2 — Add Toggle in Menu

```csharp
speedBoost = GUILayout.Toggle(speedBoost, "Speed Boost", GUILayout.Width(145), GUILayout.Height(22));
```

---

### Step 3 — Add Logic in `Update()`

```csharp
void Update()
{
    if (speedBoost)
    {
        GameObject.FindObjectOfType<PlayerController>().speed = 20f;
    }
}
```

---

# Tips

- One-time actions → Use buttons  
- Continuous effects → Use toggles + `Update()`  
- Keep features organized → Use tabs  
- Test incrementally  
- The menu is draggable by default — click and drag the window  

---

# Requirements

- Unity Engine  
- Basic understanding of C#  
- Basic Unity scripting knowledge  

---

# 🛠 Troubleshooting

---

## ❌ Menu Doesn’t Appear

- Make sure `Loader.Init();` was called  
- Ensure namespace matches in both files  
- Press **Page Up** to toggle visibility  

---

## ❌ Features Not Working

- Confirm logic is inside the correct `Update()` method  
- Ensure toggle variable matches the `if` statement  
- Use `Debug.Log()` to verify execution  

---

## ❌ Can’t Drag the Menu

- Ensure `HandleDragging()` is called in `OnGUI()`  
- Verify `isDragging1` is properly initialized  

---

# License

Free to use and modify.

No restrictions.

---
