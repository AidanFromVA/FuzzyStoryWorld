# Hansel and Gretel - Episode 7
***
  - Language: C#
***
  -Update Log
       1) 2021-08-09: Initial development
       2) 2021-08-10: Code uniformity and comment processing
       3) 2021-08-19: Added sound effect playback
       4) 2021-08-30: Initial writing of Read Me
***
  - Running screen and contents
<img src="https://user-images.githubusercontent.com/88296511/131270379-f260534f-6ea6-4684-b99b-f7631fd6f7b5.jpg" width="500" height="220">

<img src="https://user-images.githubusercontent.com/88296511/131270386-11688fd6-f1f2-4307-871b-6c87b38f4fa0.jpg" width="500" height="220">


     - This is the running screen of Episode 7’s new follow-up game.
     - When the scene starts, the bird flies to a specific location.
     - When you click on the screen, the player moves to a new location (clicked location).
     - The scene ends when you finally follow the bird that arrives at the snack shop. .
***
- H&G (Episode 5) composition information
   -Image
     - All image files required for implementation were referenced from FuzzStoryWorld/Assets/Image/.
   -Scene
     - In the case of scene files, it was also conducted at FuzzStoryWorld/Assets/Scenes/1_07H&G.unity.
   -Prefab
     - MovingBird.prefab: It is a moving bird prefab.
   -Script
     - ChangeNextScene.cs: When the player arrives at the snack shop, Epi7 moves to the next scene.
     - ClickAnim.cs: Defines the blinking motion of the finger indicating to click the bird.
     - EpisodeController.cs: Controls the main flow of the game played in Epi7.
     - FlyBird.cs: This is a script code that implements the behavior of a bird flying.
     - MoveHAG.cs: This is a class that defines the movement of the Hansel and Gretel object following the bird when the screen is touched.

***
