# Hansel and Gretel - Episode 11

***
  - Language: C#
***

   -Update Log
     1) 2021-08-04: Initial development
     2) 2021-08-10: Code modification and comment processing
     3) 2021-08-22: Initial writing of Read Me
***
  - Running screen and contents
1) ![MainPic](https://user-images.githubusercontent.com/88296556/130382747-edd5e12d-fd47-4fff-a934-33cda5f95248.jpg)
2) ![MainGamePic](https://user-images.githubusercontent.com/88296556/130382749-32a9856d-2291-4b80-b488-a6938ea49cf9.jpg)
3) ![IfDragBoneStickPic](https://user-images.githubusercontent.com/88296556/130382769-21fc17a2-676f-4816-892c-6dc41b101fcb.jpg)

     - This is the operating screen corresponding to Episode 11.
     -Hansel and Gretel are captured by the witch and locked in her basement, and to avoid being eaten by the witch, she holds out a bone in place of her hand.
     - Before starting the Episode 11 minigame, read the text first.
     - Afterwards, a mini game is played.
     -The minigame involves dragging a bone to get it to the witch instead of holding out her hand.
     - The bone consists of two pieces, with Hansel and Gretel each holding one.
     - If you give the bone to a witch, it will crash and disappear.
     - In order for the game to end, all buckeyes must be given.
***
- H&G (Episode 4) composition information
   -Image
     - All image files required for implementation were referenced from FuzzStoryWorld/Assets/Image/.
   -Scene
     - In the case of scene files, it was also conducted at FuzzStoryWorld/Assets/Scenes/1_11H&G.unity.
   -Scripts
     - CollideWitch.cs: Makes the bones that Hansel and Gretel have disappear when the witch meets them.
     - DragBoneStick.cs: You can move the bone with the mouse and place it where you want. If you place it in the wrong place, it will return to Hansel and Gretel's hand.
     - TurnPage.cs: If you give all the buckwheat to the witch, it automatically moves on to the next page.
     - SoundEffectes.cs: When a bone is given to a witch, it disappears and then a sound is made.
***
