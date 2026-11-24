# Vice Coast — Unity 3D Starter Pack

A starter code pack for an original, compact, 800 m × 800 m Android open-world game.
It is **not** a complete game or a ready-to-install APK. It contains starter C# scripts
and a setup guide. You create the Unity project and add your own art, audio, and scenes.

## Recommended Unity setup
- Use a current Unity LTS release with the 3D (URP) template.
- Set the build platform to Android in Build Profiles / Build Settings.
- Set the project to landscape orientation.
- Start with a target of 30 FPS on lower-end Android devices.
- Use the Universal Render Pipeline, baked lighting for static buildings, and simple
  colliders for gameplay objects.

## Suggested project hierarchy
Create a scene named `City_Main` with:
- `World`
  - `Ground` (800 × 800 m)
  - `Roads`
  - `Downtown`
  - `Beachside`
  - `Residential`
  - `Commercial`
  - `Harbor`
  - `Park`
- `Player` (CharacterController + PlayerMotor)
- `Main Camera` (ThirdPersonCamera)
- `Canvas`
  - `MoveJoystick` (Image + VirtualJoystick)
  - `JumpButton` (Button; OnClick -> PlayerMotor.Jump)
- `GameSystems`
  - `MissionManager`

## Add the scripts
Copy the `.cs` files from `Assets/Scripts` into the matching folder in your Unity project.

### Player
1. Create a Capsule named `Player`.
2. Add a `CharacterController`.
3. Add `PlayerMotor`.
4. Assign the joystick component to `Move Joystick`.
5. Assign the Main Camera transform to `Camera Transform`.
6. Put the Player on the `Player` layer if you create one.

### Camera
1. Add `ThirdPersonCamera` to Main Camera.
2. Drag Player into `Target`.
3. Suggested values: distance 5, height 2.2, sensitivity 120.

### Mobile joystick
1. Create a UI Image named `MoveJoystick`.
2. Add `VirtualJoystick`.
3. Set its `Handle` to a child Image.
4. Use a visible circular background and smaller handle.
5. The joystick returns normalized X/Y movement values.

### Mission trigger
1. Create an empty object at a mission location.
2. Add a collider and enable `Is Trigger`.
3. Add `MissionTrigger`.
4. Set a short mission title and description.
5. The Player must have the tag `Player`.

## First playable milestone
- A player can move around a greybox city.
- The camera follows the player.
- A mobile joystick moves the player.
- A jump button works.
- Walking into a mission marker displays a mission message in the Console.

## 800 × 800 m greybox plan
Use a 10 × 10 grid of 80 m cells. Keep roads about 8–12 m wide.
Suggested zones:
- North: downtown
- East: beachside
- South: residential
- West: harbor
- Centre: commercial plaza and park

Keep distant buildings simple. Only add detailed interiors to a few buildings that the player can enter.

## Performance targets
- Begin with 1 directional light and baked lighting.
- Use LOD Groups on larger buildings and props.
- Use occlusion culling for dense streets.
- Use texture atlases and compressed textures.
- Pool repeated traffic and pedestrian objects.
- Keep physics colliders simple.
- Profile on a real Android phone early.

## Content size
A 1 GB total content target is a later packaging goal, not a requirement for the first prototype.
Do not add filler files just to reach 1 GB. Build quality content, then package optional
assets as downloadable content (for example, Addressables or Play Asset Delivery).
The initial APK/AAB can remain much smaller.

## Important scope note
This pack provides starter scripts only. It does not include a finished city, character
model, vehicles, missions, music, or a compiled APK.
