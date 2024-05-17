# Unity-Tutorial + test summery 

started by following the flappy-bird tottorial (i very enjoyed it)
when finished i added some of his recomendations:
1. the game ends when "the bird is out of screen"
2. wings with animation
3. cant get points after you die

next step, writing tests

there are not a lot of unit tests that i can do because a lot of the objecrs are relaying on one another
most of the tests are play tests

in the beginning i thought on doing mocks and stubs but
i figured there is no need for that from the same reason i mentioned before about unit tests here

i created a few basic unit tests 

then i mooved to play tests 

i used the main scene for the bird play tests because hes the main object in the game so we want to check his collaboration with the other objects

then i created a new scene for the pipe play tests because i needed to test the pipes alone 
in this scene i just deleted the rigid body and the colliders from the bird so i can test the pipe movement
i left the bird because the pipe scripts are using some of the bird scripts

summing up the tests:
the play test cover the whole game
the unit tests cover the bird and the pipe scripts (just the basic because not much code that is seperated then the unity engine)

issues i had:
1. i thouth of working with stub and mock objects and started to learn how to do that in unity and c#
but at the end i didnt think its needed, there is not a lot of code in each script and the game is relaying on other objects too much
to mock and stub the whole game would be a lot of work and i cover the same code with the play tests

2. i needed to learn how to test the unity engine and how to test the game objects

3. i didnt know the difference between playmode and editmode tests
in the beginning i tried to write tests in editmode but i couldnt test the game objects properly, i was missing a lot of data each step
and got a lot of errors
finally i understood that i need to switch to playmode tests
from there it went better

4. i had some issues with the pipe tests because i needed to test the pipe movement and the pipe spawning without the bird and still have the bird scripts
so i created a new scene for the pipe tests and deleted the bird collider and rigid body

5. i had some issues with the pipe tests because i wanted to test if the pipes are destroyed when they are out of screen
but once they are off the screen and destroyed they are unexessible - i got some wierd erorrs when checking if its null after its destroyed
finally i found a way to check that 


coverage summery:
i checked in google how to do that and found code coverage package for unity, i installed it and ran the tests.

logicScript		70%
pipeMiddleScript	100%	
pipeMoveScript		100%	
pipeSpawnScript		100%	
rimuruScript		80%

there is more information on the coverage in "flarpy blorb\code coverage" folder.
