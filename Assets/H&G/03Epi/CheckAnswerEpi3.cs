/*
 * - Name: CheckAnswerEpi3.cs
 * - Content: Hansel and Gretel Episode 3 Mini-Game - A script to check if all 3 objects are in their correct positions and proceed to the next scene.
 *  
 * - HISTORY
 * 2021-08-10: Initial development
 * 2021-08-12: Code standardization and commenting
 *
 * <Variable>
 * mn_count: Variable to keep track of how many puzzles are correctly placed.
 * v_YouWinText: Text to indicate that the game has ended.
 * 
 * <Function>
 * v_CountAnswer(): Function to increment the count variable each time a puzzle is correctly placed.
 * v_ChangeNextScene(): Function to transition to the next scene.
 * v_WinText(): Function to activate text display.
 */
 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckAnswerEpi3 : MonoBehaviour{
    public VoiceManager mvm_VoiceManager;
    public int mn_count;
    public GameObject v_YouWinText;
    GameObject mg_SoundManager;

    void Start(){
        mvm_VoiceManager = FindObjectOfType<VoiceManager>();
        mn_count = 0; // Initialize the puzzle count variable to 0
        v_YouWinText.SetActive(false); // Deactivate the text
        mvm_VoiceManager.playVoice(6);
        mg_SoundManager = GameObject.Find("SoundManager"); // Connect to the Sound Manager game object
    }

    // Increment the count variable each time a shape is matched
    // Check if all shapes are matched by comparing the count, and if they are, proceed to the next scene
    public void v_CountAnswer(){
        mn_count++; // Increment the count
        Debug.Log("1");
        if (mn_count == 3){ // If the number of matched puzzles is 3
            Invoke("v_WinText", 1f); // Activate the text
            Invoke("v_ChangeNextScene", 3f); // Load the next scene
        }
    }

    // Function to transition to the next scene
    public void v_ChangeNextScene(){
        SceneManager.LoadScene("1_04H&G");
    }

    // Function to activate the text display
    public void v_WinText(){
        v_YouWinText.SetActive(true);
        mg_SoundManager.GetComponent<SoundManager>().playSound("Win2"); // Play the game end button sound effect
    }
}
