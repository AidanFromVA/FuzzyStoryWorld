/*
 * - Name: MoveHansel.cs
 * - Content: Hansel and Gretel Episode 3 - A script to initiate a mini-game after the story progression, including walking sounds.
 * - HISTORY
 * 1) 2021-08-10: Initial development
 * 2) 2021-08-17: Code standardization and commenting
 * 3) 2021-08-24: Added game skipping (by Kim Myeong-hyeon)
 * 4) 2021-08-26: Added walking sound when moving (by Lee Byeong-gwon)
 *
 * <Variable>
 * mg_Hansel: Variable for connecting the Hansel object.
 * mv3_TargetPoint: The target point to move Hansel.
 * mg_PopUp: Popup window to start the mini-game.
 *  
 * <Function>
 * v_NextScene: Transition to the next scene.
 * v_NextSceneWhenSkipGame: Scene transition when the game is skipped.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MoveHansel : MonoBehaviour{
    private GameObject mg_Hansel;
    public Vector3 mv3_TargetPoint;
    public GameObject mg_PopUp;
    public VoiceManager mvm_VoiceManager;

    GameObject mg_SoundManager;
    private bool mb_PlayFirstVoice = false;

    void Start(){
        mvm_VoiceManager = FindObjectOfType<VoiceManager>();

        mg_SoundManager = GameObject.Find("SoundManager"); // Connect to the Sound Manager game object

        mv3_TargetPoint = new Vector3(-2.7f, -0.8f, -2.5f); // Set the target point to move Hansel
        mg_Hansel = GameObject.Find("Hansel"); // Connect the object to the variable
        mg_PopUp.SetActive(false); // Deactivate the popup window
    }
    
    void Update(){
        mg_Hansel.transform.position = Vector3.MoveTowards(mg_Hansel.transform.position, mv3_TargetPoint, 0.07f); // Function to move the object towards the target point with a speed of 0.07f
        if (!mb_PlayFirstVoice)
        {
            mg_SoundManager.GetComponent<SoundManager>().playSound("Walk2"); // Play the walking sound when Hansel is walking
            mvm_VoiceManager.playVoice(5);
            mb_PlayFirstVoice = true;
        }
        
        if (mb_PlayFirstVoice && mvm_VoiceManager.isPlaying() == false)
        {
            // Check if game skipping is enabled
            if(PlayerPrefs.GetInt("SkipGame") == 1)
            {
                Invoke("v_NextSceneWhenSkipGame", 1f);
            }
            else
            {
                popup();
            }
        }
    }

    void popup()
    {
        mg_PopUp.SetActive(true);
    }
    public void v_NextScene(){
        mg_SoundManager.GetComponent<SoundManager>().playSound("PlayMinGame2"); // Play the game start button sound effect
        SceneManager.LoadScene("1_03H&G_Game");
    }

    public void v_NextSceneWhenSkipGame()
    {
        SceneManager.LoadScene("1_04H&G");
    }
}
