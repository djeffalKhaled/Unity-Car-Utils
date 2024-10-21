# Description:
Foundamental scripts for any car based game intended to use in Unity.

# Features:
- CarAI: Simple car AI used for highway roads.
- CameraFollow: Camera follower with two options a fixed or dynamic follow.
- WorldSpawner: Linear infinite world generation that spawns your terrain prefabs in a fixed axis.
- SpawnCollider: Trigger collider that checks whether the player reached a certain distance in order to spawn new terrain.

# Details:
### CarAI:
Works for 4 based lanes. Each lane is entitled as positions, position[0] is the farthest left with position[3] is the farthest right. Positions are defined only in the x axis and cannot work in the z axis. Each position has to be defined but has default configs. Cars can turn either left or right randomally by one possion. They slowly change their lane with a set configurable speed.

### CameraFollow:
Basic camera follow script inteded for car games. It has two modes: a fixed one and a dynamic one. The fixed one is exact, it takes the position of an empty GameObject that sets the cam's position while being childed to the moving vehicle. The 2nd mode is dynamic, it uses Lerp to make the camera slowly reach the car for a dynamic moving effect. It also has the feature of rotating the camera around the car using the mouse. 

### WorldSpawner:
Used for linear infinite world generation. Spawn sets of terrain given as a prefab by getting the data of the current terrain. The system can only work IF the terrain is in 7*4 grid, in which it takes its position and adds a certain number in order to place the upcoming terrain prefab at the correct position. After the prefab is spawned, it calls the destroyIfFar() coroutine that checks if the player is closest to the newest prefab, in which it destroys the old one for optimisation. It functions only in the Z axis.

### SpawnCollider:
Used for linear infinite world generation. Trigger collider typically placed at the terrain prefab, checks whether the player reached it in which once they collided, it calls the WorldSpawner's spawn() command, spawning the new terrain at the correct location. 
