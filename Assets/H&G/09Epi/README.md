# Hansel and Gretel - Episode 9
***
  - Language: C#

***
  -Update Log
       1) 2021-08-17: Initial development
       2) 2021-08-23: Code uniformity and comment processing
       3) 2021-08-30: Initial writing of Read Me
***
  - Running screen and contents
<img src = "https://user-images.githubusercontent.com/76957700/131277581-0e135ba7-491a-4459-8fcd-81b63da0043b.png" width="500" height="250">
 
<img src = "https://user-images.githubusercontent.com/76957700/131277934-ec31a0b7-931b-4b50-be6f-aadc7d9144e7.png" width="500" height="250">

<img src = "https://user-images.githubusercontent.com/76957700/131278319-84ad3c38-7b5c-44d3-b7a6-d462ce78a5b0.png" width="500" height="250">

<img src = "https://user-images.githubusercontent.com/76957700/131278354-9a58504f-218d-43be-983e-355e9c0b259e.png" width="500" height="250">


     - This is the story progress screen for Episode 9.
     - After the story progresses, the background becomes dark.
     - When the background becomes dark, a voice tells you to click on 6 objects.
     - When you click on an object, Hansel and Gretel hide behind the object, and the witch immediately follows.
     -If you click on all 6 objects, Hansel and Gretel will be captured by the witch and taken to her witch's house.
     - If you take it home, it moves to the next scene.
    
***
- H&G (Episode 5) composition information
   -Image
     - All image files required for implementation were referenced from FuzzStoryWorld/Assets/Image/.
   -Scene
     - In the case of scene files, it was also conducted at FuzzStoryWorld/Assets/Scenes/1_09H&G.unity.
   -Prefab
     -vibrate.prefab

   -Script
     - SceneControl.cs: Contains the main flow of the story and tutorial in Epi9.
     - ObjectClick.cs: When the SceneControl class is finished, click on the object so that Hansel and Gretel hide behind the object and the witch finds the hidden children.
***
