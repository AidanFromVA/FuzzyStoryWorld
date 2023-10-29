/*
  * - Name: MatchPuzzles.class
  * - Writer: Yoo Hee-su
  * : Lee Byung-kwon
  * - Content: Hansel and Gretel Epi2 Minigame - A script that checks whether each puzzle piece is in the correct position and returns it to its original place if it is incorrect.
  * 1) When you pick up the puzzle, it makes a sound.
  * 2) A sound is made when the puzzle is answered correctly.
  * 3) A sound is heard when the puzzle is incorrect.
  * - HISTORY
  * 2021-08-11: Initial development
  * 2021-08-12: Code standardization and comment processing
  *
  * <Variable>
  * mgo_GameControl "AnswerCheckEpi2" Variable for script connection
  * mv3_initPos; Variable for storing current location
  *
  * <Function>
  *
  */

using System. Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MatchPuzzles: MonoBehaviour{
     private GameObject mgo_GameControl; //Variable for AnswerCheckEpi2 script connection
     Vector3 mv3_initPos; //Variable for storing current location
     GameObject mg_SoundManager;
     void Start(){
         mv3_initPos = this.transform.position; //Save current location
         mg_SoundManager = GameObject.Find("SoundManager"); // Connect the sound manager game object
         mgo_GameControl = GameObject.Find("GameControl"); //object connection
     }

     void Update(){
         this.transform.position = Vector3.MoveTowards(this.transform.position, mv3_initPos, 8f * Time.deltaTime); //Function where the current object moves to the mv3_initPos position at a speed of 8f
     }

     //A function that shows a sketch of the location when the puzzle piece goes to the correct location and makes the puzzle piece disappear
     //Inspect with object tags
     private void OnTriggerStay2D(Collider2D col)
     {
         if (Input.GetMouseButtonUp(0))
         { //When you release the mouse click on the screen
             if (col.tag == this.tag)
             {
                 mg_SoundManager.GetComponent<SoundManager>().playSound("Put"); //If the tag of the colliding object and the tag of the current object (puzzle piece) are the same
                 col.gameObject.SetActive(false); //Disable collider
                 Destroy(this.gameObject); //Delete current object
                 mgo_GameControl.GetComponent<CheckAnswerEpi2>().v_CountAnswer(); //Run function to increase the number of correct answers
             }
         }
     }
 
 
}
