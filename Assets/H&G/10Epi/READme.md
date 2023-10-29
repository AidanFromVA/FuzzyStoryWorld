# Hansel and Gretel - Episode 10

***
  - Language: C#
***

   -Update Log
     1) 2021-08-03: Initial development
     2) 2021-08-10: Code modification and comment processing
     3) 2021-08-22: Initial writing of Read Me
***
  - Running screen and contents
1) ![MainPic](https://user-images.githubusercontent.com/88296556/130381014-93ccc9f1-2621-4f32-9a85-e99ef6e55bfd.jpg)
2) ![MainGamePic](https://user-images.githubusercontent.com/88296556/130381016-6bf892dc-cd4c-4bd7-9b80-6ca133a8c0fb.jpg)
3)![IfMonsterDiePic](https://user-images.githubusercontent.com/88296556/130381166-c5cf0b45-2d4a-4c5d-a752-2c03976c8273.jpg)



     - This is the operating screen corresponding to Episode 10.
     - This is a scene where Hansel and Gretel are captured by a witch and locked in the basement, where they clean up.
     - Before starting Episode 10, read the text first.
     - Afterwards, a mini game is played.
     - The mini game involves cleaning by inserting monsters (trash-shaped) and removing them one by one in order to attract children's interest in the cleaning scene.
     - To clean, you must click on the monsters (garbage shapes) twice. (The maximum stamina of monsters (trash-shaped ones) is limited to 2.)
     - To end the game, you must eliminate all 6 monsters (trash-shaped).
***
- H&G (Episode 4) composition information
   -Image
     - All image files required for implementation were referenced from FuzzStoryWorld/Assets/Image/.
   -Scene
     - In the case of scene files, it was also conducted at FuzzStoryWorld/Assets/Scenes/1_10H&G.unity.
   -Prefab
     - GMonster1.prefab: Corresponds to the green plastic bottle monster that appears first on the screen.
     - GMonster2.prefab: Corresponds to the second yellow can monster seen on the screen.
     - GMonster3.prefab: Corresponds to the third red can monster seen on the screen.
     - GMonster4.prefab: Corresponds to the bright yellow cabbage monster that appears fourth on the screen.
     - GMonster5.prefab: Corresponds to the blue briefcase monster that appears fifth on the screen.
     - GMonster6.prefab: Corresponds to the bright green plastic bag monster visible at the back of the screen.
   -Scripts
     - ActiveTrashMonster.cs: Automatically causes trash monsters to move left and right.
     - ControlMonster.cs: Limits the number of monsters to 6 and automatically moves to the next page if all monsters are deleted.
     - KillTheMonster.cs: Controls the monsters' health, how many times you have to click to make them disappear, and sounds when the above situation occurs.
     - SoundEffectes.cs: Stores sounds so that sounds are made when monsters disappear and health decreases.
***
