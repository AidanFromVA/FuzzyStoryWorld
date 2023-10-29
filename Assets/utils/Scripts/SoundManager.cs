/*
 * - Name: SoundManager.cs
 * - Content: SoundManager is an object class created to manage sound effects. It receives AudioClip and name as parameters in the inspector window, and when the playSound function of this class is called from other objects, it plays the sound effect.
 * - Where the code is applied: for any scenes that need to create sound effects...
 * - History:
 *   2021-07-19: Production completed
 *   2021-07-20: Commented
 *   2021-07-23: SoundManager added
 *   2021-07-27: Comment changes based on feedback.
 *
 * - SoundManager Member Variables:
 *
 * msm_soundManager: A class that manages sound effects.
 * Sound[] mssl_saveSounds: A struct set by the user in the inspector window, where:
 *   - public string name: a variable that represents the name of the clip.
 *   - public AudioClip sound: a variable that holds the sound effect file.
 * mas_outputSounds: A variable that actually outputs sound effects in the scene.
 * 
 * - SoundManager Member Functions:
 *
 * Start(): Contains initialization code for obtaining the SoundManager object.
 * playSound(): This function takes an id or name as a parameter (this function is overloaded). It calls the PlayOneShot function from mas_outputSounds to play sound effects in the scene.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// To make the struct format appear in the inspector window, [System.Serializable] annotation is required as follows:
[System.Serializable]
public struct Sound {
    public string name;
    public AudioClip sound;
}   

// This class is responsible for sound effects.
public class SoundManager : MonoBehaviour {
    public Sound[] mssl_saveSounds;
    private AudioSource mas_outputSounds;

    // Get the AudioSource component.
    void Start() {
        mas_outputSounds = this.GetComponent<AudioSource>();
    }

    // Play a sound effect in the scene based on the id or name of the saved clip in the inspector window.
    public void playSound(int id) {
        mas_outputSounds.PlayOneShot(mssl_saveSounds[id].sound);
    }

    public void playSound(string soundName) {
        for (int i = 0; i < mssl_saveSounds.Length; i++) {
            if (mssl_saveSounds[i].name == soundName)
                mas_outputSounds.PlayOneShot(mssl_saveSounds[i].sound);
        }
    }
}
