# FLARPY-BLORB

This is a game about a bird named Rimuru, built to learn the basics of Unity programming and test framework. The main goal of this project was to gain experience in creating and conducting edit and play tests.

## Demonstration
https://github.com/manuelruff/flarpy-blorb/assets/109958228/a7339af8-03b3-4bba-a4af-046d010e01fc

## Features

* Rimuru dies when it goes out of the screen (above or below) or collides with a pipe.
* Pressing "space" makes Rimuru jump, accompanied by a wing-flapping animation.
* Players earn points for successfully passing each pipe.
* The game ends when Rimuru dies.

## Technology Stack
The game has been built using Unity.

### Pipes Generation and Movement

* **Pipe Spawning**: Pipes are generated at regular intervals to create gaps.
* **Pipe Movement**: Pipes move horizontally from right to left.
* **Collision Detection**: The game checks for collisions between Rimuru and pipes, triggering game over when a collision occurs.
* **Out Of Screen**: The game checks if Rimuru goes out of the screen, triggering game over.

### Game Screen and Components

* **Bird Animation**: The player-controlled Rimuru is animated using Unity's animation system, responding to user input for flying and gravity for falling.
* **Wing Animation**: When the player makes Rimuru jump, a wing animation is activated.
* **Score Display**: A score counter keeps track of the player's progress and is displayed on the screen.

## Tests

### Edit test
* Basic tests for "Rimuru" that ensure he was built and set successfully.
* Basic tests for "logic script" that ensure it was built and set successfully.

### Play test
**1. I used the main scene for Rimuru play tests because he's the main object in the game, so we want to check his interaction with all the other objects.**
**Three main tests are:**
1. rimuru_SimulatedJump_PositionChange
    - Ensures Rimuru moves up when a jump happens.
2. rimuru_WhenPassingPipes_AddsScore
    - Ensures Rimuru gets a score if he successfully passes a pipe.
3. rimuru_StuckInPipe_dies
    - Ensures Rimuru dies when he gets stuck in a pipe.

**2. I created a new scene for the pipes play tests because I needed to test the pipes alone. In this scene, I deleted the rigid body and the colliders from Rimuru so I can test the pipe movement without the game ending. I left Rimuru because the pipe scripts are using some of Rimuru's scripts.**
* 
**The tests are:**
1. Pipe_PassesDeadZone_Destroyed
    - Ensures the pipes are being destroyed when moving out of the screen.
2. Pipe_Update_MoveLeft
    - Ensures the pipes are moving left while the game is running.
