/*
  * - Name: BirdEatBreads.class
  * - Writer: Lee Ye-eun, Lee Byeong-kwon
  *
  * - Content:
  * Write a function that stops the bird after it eats (deletes) the bread (game object)
  * Write a narration output function
  * When a bird eats bread, it makes a sound
  *
  * - HISTORY
  * 1) 2021-08-05: Initial development
  * 2) 2021-08-06: Development fix
  * 3) 2021-08-09: Code uniformity and comment processing
  * 4) 2021-08-10: Comment modified
  * 5) 2021-08-24: Game skipping point designation (Kim Myung-hyun)
  * 6) 2021-08-26: Eating bread makes a sound (Byung-kwon Lee)
  *
  * - Variable
  * mgo_BigBread Big Bread GameObject
  * mgo_SmallBread Small bread game object
  * mv3_FinalPos Final 3D position variable to which the bird will move.
  * mvm_VoiceManager voice output variable
  * mb_CheckBread Logical variable to check if the bread has disappeared.
  * mb_PlayOnce Logical variable for outputting voice once
  * mb_TellOnce Logical variable to output the changeNextScene() function once
  *
  * <Function>
  * void Stop() Game object stop function
  * void DestroyBigBread() mgo_BigBread removal function
  * void DestroySmallBread() mgo_SmallBread removal function
  * void ChangeNextScene() Function to move to the next scene
  */

using System. Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

     // Game object destruction script from Epi6
public class EatBread : MonoBehaviour
{
     // Variables needed to remove breadcrumbs that fall on the floor
     public GameObject mgo_BigBread;
     public GameObject mgo_SmallBread;
     public GameObject mv3_FinalPos;
     private bool mb_CheckBread = true;
     public GameObject mgo_HAG;
     public GameObject mgo_TargetPos;

     bool mb_EatBread = false;

     bool mb_EatBread2 = false;
     // Variables needed for voice output
     private VoiceManager mvm_VoiceManager;

     GameObject mg_SoundManager;

     // Narration output
     void Start() {
         mvm_VoiceManager = FindObjectOfType<VoiceManager>();
         mvm_VoiceManager.playVoice(9);
         mg_SoundManager = GameObject.Find("SoundManager"); // Connect the sound manager game object
     }
    
     void Update() {
         // When the voice output ends, move to the next scene
          if(mvm_VoiceManager.isPlaying() == false) {
              Time.timeScale = 1;
             // Game Skip Junction
             if (PlayerPrefs.GetInt("SkipGame") == 1) {
                 SceneManager.LoadScene("1_08H&G");
             }
             else {
                 ChangeNextScene();
             }
         }

         mgo_HAG.transform.position = Vector3.MoveTowards(mgo_HAG.transform.position, mgo_TargetPos.transform.position, 0.5f*Time.deltaTime);

         if(Mathf.Abs(mgo_BigBread.transform.position.x - transform.position.x) < 1.0 && mb_CheckBread) {
             // If the big bread is similar to the game object
             // remove the large bread
             Invoke("DestroyBigBread", 1f);
             if(mb_EatBread == false){
                  mg_SoundManager.GetComponent<SoundManager>().playSound("EatBread"); // Play end game button sound effect
             }
             mb_EatBread = true;

             mb_CheckBread = false;
            
         } else if(Mathf.Abs(mgo_SmallBread.transform.position.x - transform.position.x) < 0.7 && !mb_CheckBread) {
             // If the small bread is similar to the game object
             // remove small bread
             // When the small bread disappears, the game object also stops
             Invoke("DestroySmallBread", 1f);

             if(mb_EatBread2 == false){
                 mg_SoundManager.GetComponent<SoundManager>().playSound("EatBread2"); // Play end game button sound effect
             }
             mb_EatBread2 = true;

             Invoke("Stop", 1.3f);
            
         } else {
             // Walk to the final position, mv_FinalPos
             transform.position = Vector3.MoveTowards(transform.position, mv3_FinalPos.transform.position, 0.5f * Time.deltaTime);
         }
     }
    
     // Function to stop the game object
     void Stop() {
         Time.timeScale = 0;
     }

     // Function to make the big bread disappear
     void DestroyBigBread() {
         //mg_SoundManager.GetComponent<SoundManager>().playSound("EatBread"); // Play the sound effect when eating bread
         mgo_BigBread.GetComponent<SpriteRenderer>().sprite = null;
 
     }
    
     // Function to make small bread disappear
     void DestroySmallBread() {
         //mg_SoundManager.GetComponent<SoundManager>().playSound("EatBread"); // Play the sound effect when eating bread
         mgo_SmallBread.GetComponent<SpriteRenderer>().sprite = null;
     }

     // Function to move to the next scene
     void ChangeNextScene() {
         SceneManager.LoadScene("1_07H&G");
     }
}
