# Hansel and Gretel - Episode 12
***
  - Language: C#
***
  -Update Log
       1) 2021-08-12: Initial development
       2) 2021-08-13: Development fix
       3) 2021-08-19: Added sound effect playback
       4) 2021-08-30: Code uniformity and comment processing
       5) 2021-08-30: Initial writing of Read Me
***
  - Running screen and contents
<img src="https://user-images.githubusercontent.com/88296511/131273316-ca95c098-d6e4-469b-a6ea-7bdf7d494b41.jpg" width="500" height="220">
<img src="https://user-images.githubusercontent.com/88296511/131273332-e1f6ea6a-03f9-40f6-bbd6-f8961a3adf36.jpg" width="500" height="220">
<img src="https://user-images.githubusercontent.com/88296511/131273407-6cb08a4b-e5b3-4646-b3fe-e63e03e1d483.jpg" width="500" height="220">
<img src="https://user-images.githubusercontent.com/88296511/131273375-c97ed370-fa45-4a04-9889-93932134fbda.jpg" width="500" height="220">
<img src="https://user-images.githubusercontent.com/88296511/131273435-17ba6ef9-003f-4270-8b2f-25194256d8e8.jpg" width="500" height="220">
<img src="https://user-images.githubusercontent.com/88296511/131273487-d10a127c-3c4d-468f-ab93-72ff156247dc.jpg" width="500" height="220">

     - This is a screen shot of Episode 12: Defeat the Witch.
     - When the scene starts, click on the witch to attack her.
     - You must avoid the witch's lightning attack.
     - When the witch's health becomes 0, Hansel and Gretel walk to Treasure Island.
     - When you arrive at Treasure Island, the next minigame start button will appear, and if you press this button, you will move on to the next game.
***
- H&G (Episode 5) composition information
   -Image
     - All image files required for implementation were referenced from FuzzStoryWorld/Assets/Image/.
   -Scene
     - In the case of scene files, it was also conducted at FuzzStoryWorld/Assets/Scenes/1_12H&G.unity.
   -Prefab
     - BonePrefeb.prefab: This is a bone prefab that attacks witches.
     - CFX3_Fire.prefab: This is the effect prefab that appears when the witch attacks Hansel and Gretel.
     - CFX4 Fire.prefab: This is the lightning prefab that appears when the witch attacks Hansel and Gretel.
     - mark.prefab: This is a prefab that marks where Hansel and Gretel will move.
   -Script
     - ChangeNextScean.cs: When the player arrives at Treasure Island and presses the next scene game start button, the game moves on to the next scene.
     - HAGAttack.cs: This is a script code that when you press a witch, a bone flies to the witch and attacks the witch.
     - HAGMove.cs: This is a script class that expresses Hansel and Gretel’s movements according to mouse clicks.
     - HPbar.cs: This is a script that expresses the HP bar representing the health of game objects.
     -MoveWitch.cs: When the witch chases Hansel and Gretel and hits her bone, her bone disappears.
     -NotifyPlayerDanger.cs: When Hansel and Gretel are hit by a witch's attack, her health decreases.
     - ReplayScene12.cs: When Hansel and Gretel lose, the Replay button is activated and pressing it restarts the game.
     - Scene12Controller.cs: Controls the main flow of the game played in Epi12.
     - Status.cs: Controls the status of the witch, Hansel and Gretel’s HP bar.
     - WitchAttack.cs: This is a script class that expresses the witch’s attack on Hansel and Gretel.
***
