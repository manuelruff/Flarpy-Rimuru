# FLARPY-BLORB

This is a game is about a bird named rimuru built to learn the basics of Unity programming and test framework. The main goal of this project was to gain experience in creating edit and play tests.

## Demosntration:
https://github.com/manuelruff/flarpy-blorb/assets/109958228/a7339af8-03b3-4bba-a4af-046d010e01fc

## Features

* Rimuru dies when it goes out of the screen (above or below) or collides with a pipe.
* Pressing "space" makes rimuru jump, accompanied by a wing-flapping animation.
* Players earn points for successfully passing each pipe.
* The game ends when rimuru dies.

## Technology Stack
The game has been built using Unity.

### Pipes Generation and Movement

* **Pipe Spawning**: Pipes are generated at regular intervals to create gaps.
* **Pipe Movement**: Pipes move horizontally from right to left.
* **Collision Detection**: The game checks for collisions between rimuru and pipes, triggering game over when a collision occurs.
* **Out Of Screen**: The game checks if rimuru goes out of screen, triggering game over.

### Game Screen and Components

* **Bird Animation**: The player-controlled rimuru is animated using Unity's animation system, responding to user input for flying and gravity for falling.
* **Wing Animation**: When the player is making rimuru jump there is a wing animation that is activated.
* **Score Display**: A score counter keeps track of the player's progress and is displayed on the screen.

## Tests

### Edit test
* basic tests for "rimuru" that insures he was build and set succeffuly.
* basic tests for "logic script" that insures it was build and set succeffuly.

### Play test
**1. I used the main scene for rimuru play tests because hes the main object in the game so we want to check his collaboration with all the other objects.**</br>
**3 main tests are:**
1. rimuru_SimulatedJump_PositionChange
    - ensures rimuru moves up when a jump happens.
2. rimuru_WhenPassingPipes_AddsScore
    - ensures rimuru get score if he succefuly pass a pipe.
3. rimuru_StuckInPipe_die
    - ensures rimuru dies when he get stuck in a pipe.

**2. I created a new scene for the pipes play tests because i needed to test the pipes alone. In this scene i deleted the rigid body and the colliders from rimuru so i can test the pipe movement without the game ending, I left rimuru because the pipe scripts are using some of rimurus scripts.**
* 
**The tests are:**
1. Pipe_PassesDeadZone_Destroyed
    - ensures the pipes are being destroied when moving out of screen.
2. Pipe_Update_MoveLeft
    - ensures the pipes are moving left while the game is running.

