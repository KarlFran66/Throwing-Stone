# Attempt for the throwing stone & water stream

Now the attempt can simulate the player taken by the water stream to somewhere. This is in done the Water Stream scene. The stream is simulated by Area Effector 2D component.

The attempt only builds a simple scene without our own sprites for testing.

Gameobject Rock has the component of Rigidbody 2D so that it can be picked up and thrown away. It has a Rock Instruction component with the script realizing the function that when the player walks nearby the rock, there will be a pop-up instruction saying "Press E to pick up the rock".

Gameobject Player has a Player Controller component with the script such that when the player walks nearby the rock, the player can press E to pick up the stone.
Here is a tutorial that might be useful for this function: https://www.youtube.com/watch?v=-V1O5FGQVY8
In PlayerController.cs, there are now two different versions with different functions. There are comments showing detailed functions in the code.

Besides picking up function, another aim of Player Controller is when the player walk nearby the river and press a button so that the stone can be thrown automatically to a place in the river to build a bridge for the player to cross the river. 
