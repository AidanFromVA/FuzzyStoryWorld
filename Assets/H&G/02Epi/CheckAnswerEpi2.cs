/*
  * - Name: CheckAnswerEpi2.class
  * - Writer: Yoo Hee-su, Byungkwon Lee
  * - Content: Hansel and Gretel Epi2 minigame - A script that counts how many puzzle pieces have been matched and moves to the next scene when all are matched.
  *
  * - HISTORY
  * 2021-08-10: Initial development
  * 2021-08-12: Code standardization and comment processing
  *
  * <Variable>
  * mn_count variable to check how many puzzles have been solved
  * v_YouWinText Text indicating that the game is over
  *
  * <Function>
  * v_CountAnswer() A function that adds a count variable every time a puzzle is answered.
  * v_ChangeNextScene() Function to move to the next scene
  * v_WinText() Function that activates text
  */


using System. Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckAnswerEpi2 : MonoBehaviour{
     public int mn_count;
     public GameObject v_YouWinText;

     GameObject mg_SoundManager;
     void Start(){
         mn_count = 0; //Initialize puzzle number variable to 0
         v_YouWinText.SetActive(false); //disable text
         mg_SoundManager = GameObject.Find("SoundManager"); // Connect the sound manager game object
     }

     //Function that adds a count variable every time you solve a puzzle
     //Check whether all the puzzles fit together by counting them, and if so, move to the next scene
     public void v_CountAnswer(){
         mn_count++; //Add the numbers one by one
         Debug.Log(mn_count);
         if (mn_count == 4){ //If the number of puzzles solved is 9
             Invoke("v_WinText", 1f); //Activate text
             Invoke("v_ChangeNextScene", 3f); //Load the next scene
         }
     }

     //Function to move to the next scene
     public void v_ChangeNextScene(){
         SceneManager.LoadScene("1_03H&G");
     }

     //Function to activate text
     public void v_WinText(){
         v_YouWinText.SetActive(true);
         mg_SoundManager.GetComponent<SoundManager>().playSound("Win"); // Play end game button sound effect
     }
}
