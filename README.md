

https://github.com/user-attachments/assets/049fa023-5bd7-49ff-a9b4-0566fa53584c

# Unity Modular Systems Demo (Zenject)
This project is a demonstration of modular Unity components built using Zenject for dependency injection and a signal-driven architecture. It features a flexible joystick system, a scriptable item database, and a decoupled inventory (backpack) system.

## Key Systems

### 1. Joystick Suite
A collection of mobile-friendly input controllers with custom editor support:
- Fixed Joystick: Stays in a static position.
- Floating Joystick: Appears at the point of contact on the screen.
- Variable/Dynamic Joystick: Can switch between modes and includes a "move threshold" to follow the user's touch.
- Custom Editors: Each joystick type includes a specialized inspector for easier configuration in the Unity Editor.

### 2. Inventory & Item System
A data-driven approach to managing items and player storage:
- Backpack Handler: Manages the logic for collecting items, filling slots, and syncing with the UI.
- Item Database: A ScriptableObject that acts as a central registry for all game items.
- Item Collector: Uses 2D triggers to detect CollectibleItem components and fires signals to the inventory.

## Architecture & Communication
### Dependency Injection (Zenject)
The project uses Zenject to keep components decoupled and easy to test:
- Constructors: Dependencies like SignalBus and configuration data are injected into classes using the [Inject] attribute.
- Installers: SceneInstaller and ConfigInstaller manage the binding of instances and global settings.

### Signal-Driven Events
Communication between independent systems is handled via a SignalBus:
- CollectItemSignal: Fired when a player picks up an item in the world.
- BackpackToggleSignal: Controls the visibility of the inventory UI.
- BackpackSlotClickedSignal: Handles interactions with specific inventory slots.
- 
### Configuration
Most gameplay values are stored in ScriptableObject configs to allow for quick balancing without code changes:
- PlayerConfig: Defines movement speed.
- BackpackConfig: Sets the number of available inventory slots.
- ItemData: Contains unique IDs, icons, and stack limits for items.

### Tech Stack
- Engine: Unity 2022.3.
- DI Framework: Zenject.
- UI: Unity UI (uGUI) with EventSystems.
- Logic: C# using LINQ and SignalBus.
