/*
 * - Name: CaptionControl.cs
 * 
 * - Content: A script that controls subtitles to display them according to the audio.
 *
 * - History
 * 1) 2021-08-24: Initial development
 * 2) 2021-08-26: Code modifications
 * 3) 2021-08-30: Adding comments & standardizing variable names
 * 
 * - Variables 
 * mn_LangIndex: Index to distinguish the language of the currently displayed audio
 * mn_VoiceIndex: Index of the currently played audio
 * mg_CaptionPanel: Connects to the panel UI where subtitles are displayed
 * mt_CaptionText: Connects to the text used to change subtitles according to the language
 * mvm_VoiceManager: Variable for narration
 * mb_playOne: Flag for the execution status of the first narration
 * mb_playTwo: Flag for the execution status of the second narration
 * 
 * - Functions
 * v_GotoDoor(): Function to allow Hansel and Gretel to reach the door by clicking on it
 * v_TutorialText(): Function to activate tutorial text and animations to assist with door click events
 * v_ChangeNextScene(): Function to proceed to the next scene
 * v_ChangeNextSceneWhenSkipGame(): Function to proceed to the next scene when the game is skipped
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CaptionControl : MonoBehaviour
{
    private VoiceManager mvm_VoiceManager;
    public int mn_LangIndex = 9;
    private GameObject mg_CaptionPanel;
    public GameObject mt_CaptionText;
    public int mn_VoiceIndex = 99;
    private string ms_TextTemp;
    private GameObject OnButton;
    private GameObject OffButton;

    void Start(){
        OnButton = GameObject.Find("On");
        OffButton = GameObject.Find("Off");
        mt_CaptionText = GameObject.Find("Caption");
        mvm_VoiceManager = GameObject.FindObjectOfType<VoiceManager>();
        mg_CaptionPanel = GameObject.Find("CaptionPanel");
        mn_LangIndex = ((int)mvm_VoiceManager.country);
        ms_TextTemp = mvm_VoiceManager.mlva_LanguageVoices[mn_LangIndex].mvifl_setVoiceInfoList[mn_VoiceIndex].words;
        ShowCaption();
    }

    public void ShowCaption(){
        if (mn_LangIndex == 0){ // Select Korean -> Hide subtitles
            this.gameObject.SetActive(false);
            OnButton.SetActive(false);
            OffButton.SetActive(false);
        }
        else{
            mt_CaptionText.GetComponent<Text>().text = ms_TextTemp;
        }
    }
}
