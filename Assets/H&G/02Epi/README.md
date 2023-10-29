# Hansel and Gretel - Episode2
***
  - Language: C#
***
  -Update Log
       1) 2021-08-3: Initial development
       2) 2021-08-12: Code uniformity and comment processing
       3) 2021-08-20: Initial writing of Read Me
***
  - Running screen and contents
<img src = "https://user-images.githubusercontent.com/76957700/130374352-308f13db-34a2-47bf-a2a6-3a161cd66043.png" width="450" height="220">
 
<img src = "https://user-images.githubusercontent.com/76957700/130374458-97547935-7eff-4042-bec2-e6bce9524142.png" width="450" height="220">
 
<img src = "https://user-images.githubusercontent.com/76957700/130374485-a65f09cf-55d0-4f51-a619-6a7314be03c0.png" width="450" height="220">
 
<img src = "https://user-images.githubusercontent.com/76957700/130374653-73d8065e-8368-4076-8132-9b4753a43b92.png" width="450" height="220">

<img src = "https://user-images.githubusercontent.com/76957700/130374689-16173ff8-ac6b-4a58-b7bf-7d6583163d3d.png" width="450" height="220">

<img src = "https://user-images.githubusercontent.com/76957700/130374711-55e5cf84-7f63-447a-a970-c244b6216a54.png" width="450" height="220">

<img src = "https://user-images.githubusercontent.com/76957700/130374738-d0483a2c-5e54-4492-8abf-bd71bb07ec1f.png" width="450" height="220">






     - This is the story progress screen for Episode 2.
     - After progressing through the story, clicking on the door moves the player to the door.
     - After proceeding with the tutorial to go to the door, proceed with the story.
     - After the story progresses, a button to play the puzzle game of Episode 2 appears.
     - The puzzle pieces are randomly mixed, and the game ends when all the puzzle pieces fit together.
     - When the game ends, the text “You Win” appears and moves to the next scene.
***
- H&G (Episode 5) composition information
   -Image
     - All image files required for implementation were referenced from FuzzStoryWorld/Assets/Image/.
   -Scene
     - In the case of scene files, it was also conducted at FuzzStoryWorld/Assets/Scenes/1_02H&G.unity.
   -Prefab
     - popup.prefab: This is the play button prefab on the screen to start the game.

   -Script
     - DoorClickEvent.cs: Proceeds with the main flow of the story and tutorial in Epi2.
     - RandomPuzzles.cs: This is a script that performs the function of randomly mixing puzzle pieces.
     - CheckAnswer.cs: Checks whether the correct puzzle piece is in each position. If the answer is wrong, the puzzle piece is returned to its place. If the answer is correct, the puzzle piece is placed in the correct position.
     - MatchPuzzle.cs: Checks whether all puzzle pieces are matched through the number of puzzles matched, and moves to the next scene when all puzzle pieces are matched.
***
