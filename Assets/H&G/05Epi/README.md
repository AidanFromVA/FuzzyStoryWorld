# Hansel and Gretel - Episode 5
***
  - Language: C#
***
  -Update Log
       1) 2021-08-13: Initial development
       2) 2021-08-18: Code uniformity and comment processing
       3) 2021-08-19: Added sound effect playback
       4) 2021-08-19: Initial writing of Read Me
***
  - Running screen and contents
<img src="https://user-images.githubusercontent.com/73592778/130014820-38b09cb8-684c-4817-8022-e1c0a163c441.png" width="500" height="220">

<img src="https://user-images.githubusercontent.com/73592778/130014795-f271d0ca-a856-4415-849b-b46765ce9a7c.png" width="500" height="220">

<img src="https://user-images.githubusercontent.com/73592778/130014693-799f33c2-a16c-414b-b1ec-0700e5aab678.png" width="500" height="220">

     - This is the running screen of Episode 5 Run Game.
     - To start the minigame, press the Start button.
     - Clicking on the screen causes the player to jump.
     - When a pebble approaches, make it jump at the right timing to eat the pebble.
     - The game ends when all the given pebbles are eaten.
     - When the game is over, the Finish button appears and pressing this button moves on to the next scene.
***
- H&G (Episode 5) composition information
   -Image
     - All image files required for implementation were referenced from FuzzStoryWorld/Assets/Image/.
   -Scene
     - In the case of scene files, it was also conducted at FuzzStoryWorld/Assets/Scenes/1_05H&G.unity.
   -Prefab
     - Gratel_Run.prefab: This is a Gretel prefab with a running appearance.
     - GoldCoin.prefab: It is a gold-colored pebble prefab.
     - SliverCoin.prefab: It is a silver cobblestone prefab.
     - BronzeCoin.prefab: It is a bronze-colored pebble prefab.
   -Script
     - GameManager.cs: Controls the main flow of the game played in Epi5.
     - BackgroundScroller.cs: To increase the running effect, disable the background when it starts from the right side of the screen and moves to the left side of the screen.
     - GroundScroller.cs: To increase the running effect, disable when the floor starts from the right side of the screen and moves to the left side of the screen.
     - PlayerController.cs: Manages the role of the running player.
     - RespawnManager.cs: When starting the game, create several pebbles in advance, activate them when needed, and deactivate them when no longer needed.
     - RockBase.cs: Deactivates when an object (pebble) starts from the right side of the screen and moves to the left side of the screen.
***
