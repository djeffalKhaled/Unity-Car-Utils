# Description:
Foundamental scripts for any car based game intended to use in Unity.

# Details:
## CarAI:
Works for 4 based lanes. Each lane is entited positions, position[0] is the farthest left with position[3] is the farthest right. It uses the x axis to define the left or right position, cannot work for z axis unless the object is rotated. The farthest left x axis is set to 62.5, changeable based on the actual left x axis, it uses said number to define the upcoming positions by adding a +5 each position. position[1], right of position[0], would be x = 67.5.
Cars can turn either left or right randomally by one position, possible to be set to random posititions. They slowly change their lanes in which its possible to change the speed of either diving or wanting to dive by changing the new waitforseconds() function within the coroutines.

## CameraFollow:
Basic camera follow script inteded for car games. It has two modes: a fixed one and a dynamic one. The fixed one is exact, it takes the position of an empty GameObject that sets the cam's position while being childed to the moving vehicle. The 2nd mode is dynamic, it uses Lerp to make the camera slowly reach the car for a dynamic moving effect. It also has the feature of rotating the camera around the car using the mouse. 

## WorldSpawner:
Used for linear infinite world generation. Spawn sets of terrain given as a prefab by getting the data of the current terrain. The system can only work IF the terrain is in 7*4 grid, in which it takes its position and adds a certain number in order to place the upcoming terrain prefab at the correct position. After the prefab is spawned, it calls the destroyIfFar() coroutine that checks if the player is closest to the newest prefab, in which it destroys the old one for optimisation. It functions only in the Z axis.

## SpawnCollider:
Used for linear infinite world generation. Trigger collider typically placed at the terrain prefab, checks whether the player reached it in which once they collided, it calls the WorldSpawner's spawn() command, spawning the new terrain at the correct location. 
