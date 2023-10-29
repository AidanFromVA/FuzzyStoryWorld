/*
  * - Name: DoorClickEvent.cs
  * - Writer: Yoo Hee-su, Byungkwon Lee
  * - Sounds: Byung-kwon Lee

  * - Content: Script progression through a tutorial where you click on the door
  * -1) When you click on the door, the sound of the character walking is heard.
  * -2) When you press the button to start the game, a sound is heard.
  *
  * - History
  * 1) 2021-08-03: Initial development
  * 2) 2021-08-12: Code uniformity and comment processing
  * 3) 2021-08-24: Game skip function implemented (Myeong-Hyun Kim)
  * 3) 2021-08-25: Game sound work (Byung-kwon Lee)
  *
  * - Variable
  *mg_Hansel
  *mg_Gretel
  * Button for clicking the mbtn_Door door
  * mg_DoorClickBlink Animation to indicate door click
  * mt_Text Text to output subtitles
  * mvm_VoiceManager Variable for narration
  * mb_playOne Flag for whether or not to run the first narration
  * mb_playTwo Flag for whether or not to run the second narration
  *
  * - Function
  * v_GotoDoor() A function that allows Hansel and Gretel to reach the door by clicking on it.
  * v_TutorialText() Function that activates tutorial text and animation to help direct statement click events
  * v_ChangeNextScene() Function to move to the next scene
  * v_ChangeNextSceneWhenSkipGame() Function to move to the next scene when the game is skipped
  */
using System. Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DoorClickEvent : MonoBehaviour{
     private ChangeCountry mn_PlayVoiceIndex;
     public GameObject mg_Hansel; // Variables for connection -> Hansel connection
     public GameObject mg_Gretel; // Variables for connection -> Gretel connection
     string temp;
     public Button mbtn_Door; // Button to click on the door
     public GameObject mg_DoorClickBlink; // Animation to indicate door click
     public Text mt_Text; // Text to output subtitles
     public VoiceManager mvm_VoiceManager; // Variables for narration
     public CaptionControl cc;
     private bool mb_PlayFirstVoice = false; // Flag for whether or not to run the first narration
     private bool mb_PlaySecondVoice = false; // Flag for whether or not the second narration is running
     private bool mb_doorclicksound = false;
     public GameObject mg_Popup;
     GameObject mg_SoundManager; // Variable for connecting pop-up window object
    
     void Start(){
         //object connection
         mg_Hansel = GameObject.Find("Hansel");
         mg_Gretel = GameObject.Find("Gretel");
         mt_Text = GameObject.Find("Text").GetComponent<Text>();
         mvm_VoiceManager = FindObjectOfType<VoiceManager>();
         cc = GameObject.Find("CaptionPanel").GetComponent<CaptionControl>();
         mbtn_Door = transform.GetComponent<Button>(); // door click button
                                                                                   // When the button is clicked, the function in parentheses is called.
         mg_DoorClickBlink.SetActive(false); // Initially disable the door click instruction animation
         mg_Popup.SetActive(false);
         mg_SoundManager = GameObject.Find("SoundManager"); // Connect the sound manager game object

         if (PlayerPrefs.GetInt("SkipGame") == 1)
         {
             mg_Gretel.transform.position = new Vector3(9.28f, mg_Gretel.transform.position.y, mg_Gretel.transform.position.z);
             mg_Hansel.transform.position = new Vector3(7.48f, mg_Hansel.transform.position.y, mg_Hansel.transform.position.z);
         }
     }void Update(){
        
         if (!mb_PlayFirstVoice){ // Check narration 1 execution conditions
             mvm_VoiceManager.playVoice(1); // Narration1 and playVoice(1) connected
             mb_PlayFirstVoice = true; // Narration 1 output completed
         }
         /*
         if (mvm_VoiceManager.isPlaying() == false && mb_PlayFirstVoice)
         {
             v_TutorialText();
         }
         */
         if (mvm_VoiceManager.isPlaying() == false && mb_PlaySecondVoice){ // When narration 2 is finished output, move to the next scene.
             Debug.Log("11111111111111111111111");
             if (PlayerPrefs.GetInt("SkipGame") == 1)
             {
                 Debug.Log("dssds");
                 Invoke("v_ChangeNextSceneWhenSkipGame", 1f);
             }
             else
             {
                 mg_Popup.SetActive(true); // Function to move to the next scene
             }
         }
         else if (mvm_VoiceManager.isPlaying() == false && mb_PlayFirstVoice)
         {
             v_TutorialText();
         }
     }

     // Function that allows Hansel and Gretel to reach the door by clicking on it
     public void v_GotoDoor(){
         if (mvm_VoiceManager.isPlaying() == false && mb_doorclicksound){ // If the current voice output has ended
                                                                                                       // Tutorial instructions to make the door click
             if (mg_Gretel.transform.position.x < 9){ // If Gretel's current position is in front of the door
                 mg_Gretel.transform.Translate(1, 0, 0); // Both Hansel and Gretel move toward the door
                 mg_Hansel.transform.Translate(1, 0, 0);
                 GetComponent<SoundofS2>().PlaySound("Walk");
             }else{ // If you reach the door
                 mg_DoorClickBlink.SetActive(false); // Disable door click instruction animation
                 mt_Text.text = "\nUnable to endure poverty, the parents planned to abandon Hansel and Gretel in the forest.\n"; // Print the next subtitle after the door click event ends
                 cc.mn_VoiceIndex = 3;
                 mvm_VoiceManager.playVoice(3);
                 temp = mvm_VoiceManager.mlva_LanguageVoices[cc.mn_LangIndex].mvifl_setVoiceInfoList[3].words;
                 cc.mt_CaptionText.GetComponent<Text>().text = temp;// Output narration 2 with subtitles
                 mb_PlaySecondVoice = true; // Narration 2 output completed
             }
         }
     }// Function to activate tutorial text and animation to help direct door click events
     void v_TutorialText(){
         if(PlayerPrefs.GetInt("SkipGame") == 1)
         {
             mt_Text.text = "\nUnable to endure poverty, the parents planned to abandon Hansel and Gretel in the forest.\n"; // Print the next subtitle after the door click event ends
             cc.mn_VoiceIndex = 3;
             temp = mvm_VoiceManager.mlva_LanguageVoices[cc.mn_LangIndex].mvifl_setVoiceInfoList[3].words;
             cc.mt_CaptionText.GetComponent<Text>().text = temp;
             mvm_VoiceManager.playVoice(3); // Output narration 2 with subtitles
             mb_PlaySecondVoice = true; // Narration 2 output completed
         }
         else
         {
             if (!mb_doorclicksound)
             {
                 mvm_VoiceManager.playVoice(2);
                 cc.mn_VoiceIndex = 2;
                 mt_Text.text = "\nPlease click the door\n"; // change text to make door clickable
                 temp = mvm_VoiceManager.mlva_LanguageVoices[cc.mn_LangIndex].mvifl_setVoiceInfoList[2].words;
                 cc.mt_CaptionText.GetComponent<Text>().text = temp;
                 mg_DoorClickBlink.SetActive(true); // Activate door click instruction animation
                 mg_DoorClickBlink.GetComponent<BlinkObject>().ChangBlinkFlagTrue();
                 mb_doorclicksound = true;
             }
         }
     }

     // Function to move to the next scene
     public void v_ChangeNextScene(){
         //mg_SoundManager.GetComponent<SoundManager>().playSound("PlayMiniGame1"); // Play sound effect when you press the start button
         Invoke("LoadScene", 1f);
         SceneManager.LoadScene("1_02H&G_Game");
     }

     public void v_ChangeNextSceneWhenSkipGame()
     {
         SceneManager.LoadScene("1_03H&G");
     }

}
