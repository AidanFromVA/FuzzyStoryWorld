/*
 * - Name: PlayVoice.cs
 * 
 * - Content: A class that assists in simple voice output. To use it, you need to set the dialogue index in the Inspector window of the VMLoader - VMController - KR or EN or JP or CNVoiceManager in the 0_01LanguageSelect scene and then run the script.
 * 
 * - History
 * 1) 2021-08-05: Code implementation.
 * 2) 2021-08-09: Commented.
 * 3) 2021-08-24: Added the setting for skipping the game (by 김명현).
 *  
 * - Variable
 * mn_PlayVoiceIndex: Declared as public for settings in the Inspector window, it represents the index of the dialogue to be voiced.
 * mvm_VoiceManager: Holds the AudioSource component responsible for voice output.
 * mb_PlayOnce: Voice output occurs through the Update function, so if left unchecked, it would execute every frame. This flag prevents multiple executions.
 *
 * - Function
 * Start(): Initializes the VoiceManager component in the scene.
 * Update(): If an object with the associated component is created in the scene, the voice corresponding to the index is voiced immediately. Voice output occurs only once.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// A simple script class that assists in voice output.
public class PlayVoice : MonoBehaviour {

    public int mn_PlayVoiceIndex = 0;
    public string ms_ChangeNextSceneName;
    public string ms_ChangeNextSceneName_NoGame;
    private VoiceManager mvm_VoiceManager;
    
    // Initializes the VoiceManager component in the scene.
    void Start() {
        mvm_VoiceManager = FindObjectOfType<VoiceManager>();
        mvm_VoiceManager.playVoice(mn_PlayVoiceIndex);
    }

    // If the object containing this component is created, the voice is immediately voiced. Voice output occurs only once.
    void Update() {
        // Branching point for skipping the game
        if (!mvm_VoiceManager.isPlaying()) {
            if (PlayerPrefs.GetInt("SkipGame") == 1)
            {
                SceneManager.LoadScene(ms_ChangeNextSceneName_NoGame);
            }
            else
            {
                SceneManager.LoadScene(ms_ChangeNextSceneName);
            }
        }
    }
}
