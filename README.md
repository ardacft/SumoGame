## Sumo Game
A **(unfinished)** prototype aims to produce the following game mechanics:
>Characters move around the **platform** constantly, with constant speed. 
>All individual characters try to push other opponent players outside the platform.
>Player character's movement is directed towards the mouse cursor.
>Game is over when the player is outside the platform.

#### Note on the current development and the biggest and yet unsolved problem:
I want the player character to move with constant speed at the direction of the mouse. And also, I want the characters to fall off the platform when they move outside. Using a navigation mesh I could easily move the player character on the ring but I could not figure out how I can make the player walk outside the platform and fall down. So I have proceed without the navigation mesh agent. I came up with the following somewhat problematic solution: The velocity vector of the rigidbody component is assigned in the FixedUpdate by first rotating the body towards the **raycasted** mouse position point (with transform.LookAt) and then using **transform.forward** method on the rigidbody velocity. This process repeats itself when the player is inside the boundaries of the ring wall and this is controlled by a boolean variable changed only in the OnTriggerEnter. Walls are located approprietly outside the ring area so that the player can still move about the ring boundaries. When the collision with a wall triggered, the process described above is terminated so that the player can fall free. Problem with that process is that it prevents falling down outside the platform because the transform coordinates of the gameobject are forced to change in x-z plane only. In other words, changing the rigidbody velocity in the fixedupdate causes the routine physics calculations like free-fall to cut short. This also arises some difficulties when working on the collision between characters. At this point, I am still working on it.

YouTube link for gameplay: https://youtu.be/Ywjt1clOBms
