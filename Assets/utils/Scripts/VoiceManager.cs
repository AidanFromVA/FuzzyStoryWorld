/*
 * - Name: VoiceManager.cs
 * - Content: A class that outputs voices using AudioClip via Text to Speech Class. This class allows voice settings to be made in the Inspector for easy collaboration. By creating one VoiceManager prefab per scene and configuring the voice settings in the Inspector, you can simply call the playVoice function from the scene's script code to produce voices.
 * - Where the code is applied: for any scenes that need to make voice sounds...
 *
 * - How to Use -
 *
 * 1. Create an object named "VoiceManager" as a prefab. That's all you need to do.
 * 2. In the VoiceManager class, declare the TTS class, e.g., TTS mtts_testTTS;
 * 3. The TTS class is a singleton pattern, so check if there is an instance already in use and call a function that initializes and returns the instance if none exists, e.g., mtts_textTTS = TTS.getInstance();
 * 4. The VoiceManager receives voice settings from the Inspector and retrieves the voice as an AudioClip through the Google API via the TTS class.
 * 5. The VoiceManager class holds audio as AudioClip and outputs voices to the scene via the playVoice function.
 *
 * - History -
 * 1. 2021-07-19: Implementation.
 * 2. 2021-07-20: Commented.
 * 3. 2021-07-22: Delegated TTS communication processing to threads, added loading screens during TTS processing.
 * 4. 2021-07-23: Added isPlaying() function.
 * 5. 2021-07-27: Comment changes based on feedback.
 * 6. 2021-08-10: Additional features implemented based on feedback requirements.
 * 7. 2021-08-24: Modified to a real-time loading approach based on feedback requirements. Loading is done sequentially, starting from the first scene and loading languages in the order of Korean, English, Japanese, and Chinese for the second scene, and so on.

 *
 * - Variable 
 * public enum Country {
     KR,
     EN,
     JP,
     CN
 } An enum variable used to represent the currently selected language.
 * mlva_LanguageVoices: The script class for currently supported languages.
 * mn_LanguageLength: The number of currently supported languages.
 * mct_CheckCountry: Represents the currently selected language. Changing this language will naturally produce voices in the language of the country.
 * mas_playVoice: Component for voice output.
 *
 * - Function
 * Awake(): Ensures that the created VMController objects are not destroyed when the scene changes with DonDestroyOnLoad and displays a loading screen.
 * stopVoice(): Stops the output of the currently playing voice.
 * LoadLanguageByOrder(): Starts loading in the defined order.
 * TakeVoice(): As VoiceManager now does not have AudioClip but LoadVoice scripts do, this function retrieves it and outputs it through playVoice.
 */

using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

// This is the VoiceManager class applied to GameObjects in the scene to output voices.
/// <summary>
/// A class that helps to output voices in the scene based on voice settings defined in the VoiceManager's Inspector window.
/// </summary>
public class VoiceManager : MonoBehaviour {
    public enum Country {
        KR,
        EN,
        JP,
        CN
    }

    public int mn_LanguageLength = 4;
    public LoadVoice[] mlva_LanguageVoices;
    private AudioSource mas_playVoice;
    private Country mct_CheckCountry = Country.KR;
    public Country country {
        set {
            mct_CheckCountry = value;
        }
        get {
            return mct_CheckCountry;
        }
    }

    // VMController and KRVoiceManager, ENVoiceManager, JPVoiceManager, CNVoiceManager must be preserved even when the scene changes, so they are not destroyed using DonDestroyOnLoad. Additionally, a coroutine defines the loading order and starts loading as soon as objects are created.
    void Awake() {
        mn_LanguageLength = transform.childCount;
        mas_playVoice = gameObject.GetComponent<AudioSource>();
        DontDestroyOnLoad(gameObject);
        mlva_LanguageVoices = new LoadVoice[mn_LanguageLength];
        for (int i = 0; i < mn_LanguageLength; i++) {
            mlva_LanguageVoices[i] = transform.GetChild(i).GetComponent<LoadVoice>();
        }
        StartCoroutine(LoadLanguageByOrder());
    }

    IEnumerator LoadLanguageByOrder() {
        int n_CurrentLoadIndex = 0;
        while (n_CurrentLoadIndex < mlva_LanguageVoices[0].mvifl_setVoiceInfoList.Length) {
            for (int i = 0; i < mn_LanguageLength; i++) {
                mlva_LanguageVoices[i].CurrentIndex = n_CurrentLoadIndex;
                Debug.Log(n_CurrentLoadIndex.ToString() + ":" + (i).ToString() + "Start.");
                yield return new WaitUntil(() => mlva_LanguageVoices[i].CheckLoadComplete);
                mlva_LanguageVoices[i].CheckLoadComplete = false;
                Debug.Log(n_CurrentLoadIndex.ToString() + ":" + (i).ToString() + "End.");
            }
            n_CurrentLoadIndex++;
        }
        yield break;
    }

    // A struct to save voice settings input in the Inspector window.
    // When the GameObject containing this script is created, a thread is created to delegate the TTS communication task with the voice settings saved in the Inspector window.
   
    // This function produces the stored AudioClip and outputs it to the scene via the playVoice function.
    /// <summary>
    /// A function that outputs the configured voice to the scene.
    /// </summary>
    /// <param name="nPlayVoiceClipId">The index value of the voice set in the Inspector window.</param>
    public void playVoice(int nPlayVoiceClipId) {
        if (!mas_playVoice.isPlaying) {
            mas_playVoice.PlayOneShot(TakeVoice(nPlayVoiceClipId));
        }
    }

    // Check if voice is playing, returns true if it's playing, and false otherwise.
    /// <summary>
    /// A function that checks if the AudioSource component of the VoiceManager object in the scene is currently playing a voice.
    /// </summary>
    /// <returns> Returns true if a voice is playing, and false if not. </returns>
    public bool isPlaying() {
        return mas_playVoice.isPlaying;
    }

    public void stopVoice() {
        mas_playVoice.Stop();
    }

    private AudioClip TakeVoice(int nPlayVoiceClipId) {
        return mlva_LanguageVoices[(int)country].mvifl_setVoiceInfoList[nPlayVoiceClipId].audioClip;
    }
}
