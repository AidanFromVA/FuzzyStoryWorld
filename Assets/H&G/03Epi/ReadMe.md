# Hansel and Gretel - Episode03 & Episode03 Game
***
  - Language: C#
***
  -Update Log
     1) 2021-08-12: Initial development
     2) 2021-08-17: Comment modified
     3) 2021-08-24: Game skip function added
     4) 2021-08-25: Modify the term to move to the next scene
     5) 2021-08-26: Sound modification
***
  - Running screen and contents
![Demonstration 1](https://user-images.githubusercontent.com/37494407/131274881-1efc5000-b581-482b-bb0e-104992fd5b15.PNG)

     - This is the operating screen corresponding to Episode 3.
     - This is the scene where Hansel and Gretel eavesdrop on their parents.

![Demonstration 3](https://user-images.githubusercontent.com/37494407/131275554-86eb3b6d-eccb-4961-92a6-c2bed6f159f1.PNG)


     - Episode 3_This is the operating screen corresponding to the game.
     - Once you solve all the puzzles, move to the next scene.
    
    
***
- H&G (intro) configuration information
   -Image
     - All image files required for implementation were referenced from FuzzStoryWorld/Assets/Image/.
   -Scene
     - In the case of scene files, it was also conducted at FuzzStoryWorld/Assets/Scenes/1_03H&G.unity.
   -Script
     - CheckAnswerEpi3.cs: A script that checks whether all puzzle pieces are in the right positions and connects them to the next scene.
     - MatchShape.cs: A script that checks whether the puzzle piece is in the correct position when placed and returns it to its original position if it is incorrect.
     - MoveHansel.cs: A script that supports voice and moves Hansel toward the door when the door button is clicked.
***
