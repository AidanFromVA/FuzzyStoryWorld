# Hansel and Gretel - Episode 8
***
  - Language: C#
***
  -Update Log
    1) 2021-08-10: Initial development
    2) 2021-08-11: Code uniformity and comment processing
    3) 2021-08-19: Added sound effect playback
    4) 2021-08-20: Initial writing of Read Me
***
  - Running screen and contents
<img src="https://user-images.githubusercontent.com/73592778/130159994-459ab3eb-840c-462c-a3a6-9d70038785e9.png" width="500" height="220">
<img src="https://user-images.githubusercontent.com/73592778/130160011-9c09c19f-96df-4cfd-ae51-1ba80ead210e.png" width="500" height="220">

     - This is the scene corresponding to Episode 8 and the operating screen of the mini game.
     - The contents of Episode 8 are read through tts.
     - When you start the minigame in Episode 8, the type of candy that Hansel and Gretel want to eat appears in a speech bubble.
     - Drag the type of candy that Hansel and Gretel want to eat from the candy store and feed it to Hansel and Gretel by dragging it into their mouths.
     - The game ends when all the candy in the candy shop is eaten.
     - When the game ends, it moves on to the next scene.
***
- H&G (Episode 8) composition information
   -Image
     - All image files required for implementation were referenced from FuzzStoryWorld/Assets/Image/.
   -Scene
     - In the case of scene files, it was also conducted at FuzzStoryWorld/Assets/Scenes/1_08H&G.unity.
   -Script
     - Start_Epi8_Game.cs: Start Epi8 minigame
     - CandyControl.cs: Management of remaining items in an array, function to randomly determine the correct answer through this array, and management of whether the item has changed with a flag
     - DragCandy.cs: Mouse event script, modify the object to move when the mouse is dragged.
     - RandomCandy.cs: Shows candies (items) randomly without duplication.
     - CheckAnswer.cs: Checks the correct answer in case of conflict and deletes the object if the correct answer is correct.

***
