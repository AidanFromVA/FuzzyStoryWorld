/*
  * - Name: RandomPuzzles.cs
  * - Writer: Yoo Hee-su, Byungkwon Lee
  * - Content: Script that randomly generates puzzle pieces
  *
  * - History
  * 2021-08-10: Initial development
  * 2021-08-12: Code standardization and comment processing
  *
  * - Variable
  * mspa_PuzzlePieces[] Array for connecting objects -> Connecting 9 puzzle piece images
  * mga_Slot[] Array for connecting slots for each puzzle piece
  * mna_RandNumArray[] Array for randomly shuffling puzzle pieces
  *
  *
  * - Function
  * v_RandomNum() A function that randomly selects numbers and places images without duplication.
  *
  */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomPuzzles : MonoBehaviour{

    public VoiceManager mvm_VoiceManager;
    // private bool mb_PlayFirstVoice = false;
     public Sprite[] mspa_PuzzlePieces = new Sprite[4]; //Array for connecting objects -> Connecting 9 puzzle piece images
     private GameObject[] mga_Slot = new GameObject[4]; //Arrangement for connecting slots for each puzzle piece
     int[] mna_RandNumArray = new int[4]; //Arrangement to randomly mix puzzle pieces
    /// <summary>
    /// //
    /// </summary>
    void Start(){
        mvm_VoiceManager = FindObjectOfType<VoiceManager>();
        //mvm_VoiceManager.playVoice(4);
        //mvm_VoiceManager.playVoice(15);
        //오브젝트 연결
        mga_Slot[0] = GameObject.Find("Slot1");
        mga_Slot[1] = GameObject.Find("Slot2");
        mga_Slot[2] = GameObject.Find("Slot3");
        mga_Slot[3] = GameObject.Find("Slot4");
        v_RandomNum();
    }
//Function to randomly select numbers and place images without duplication
     //Save randomly selected numbers in order in an array, and place images using the array index and object tag.
     void v_RandomNum(){
         //Random number placement
         for (int i = 0; i < 4; i++){ //0 to 9
             mna_RandNumArray[i] = Random.Range(0, 4); //Insert random numbers from 0 to 9 into 9 array indices
             for (int j = 0; j < i; j++){ //Check the current random value and the value in the existing array
                 if (mna_RandNumArray[i] == mna_RandNumArray[j]){ //If there is the same random value
                     i--; //draw random values again
                     break;
                 }
             }
         }
         //Random image placement
         for (int i = 0; i < 4; i++){
             mga_Slot[i].GetComponent<SpriteRenderer>().sprite = mspa_PuzzlePieces[mna_RandNumArray[i]]; //Place the image corresponding to the random value on the puzzle piece.
             mga_Slot[i].tag = mna_RandNumArray[i].ToString(); //Change the tag to check the correct answer
         }
     }
}
            
