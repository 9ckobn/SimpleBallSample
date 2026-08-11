# SimpleBallSample

A small 2D arcade dodger made in Unity. You steer a ball through a procedurally
generated field of obstacles; difficulty and level layout are configurable per
run, and the best score is persisted locally as JSON.

## Engine version

Unity 2021.3.11f1 (see `ProjectSettings/ProjectVersion.txt`).

## Tech notes

- Plain Unity + uGUI/TextMeshPro, no DI framework — services are wired manually
  in `Game` / `Boot` bootstrap classes.
- Scene flow: `Menu` (difficulty select) → `game` (gameplay).
- Newtonsoft.Json is used for save data.

## How to run

1. Open the project in Unity Hub with editor **2021.3.11f1** (or a newer
   2021.3.x LTS).
2. Open the scene `Assets/Scenes/Menu.unity`.
3. Press Play.

## How to build

1. `File → Build Settings…`
2. Add scenes `Menu` and `game` (both already listed in Build Settings).
3. Pick a platform (PC, Mac & Linux Standalone by default), press **Build**.
