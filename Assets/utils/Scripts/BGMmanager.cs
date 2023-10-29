/*
 * - Name: BGMmanager.cs
 * - Content: The BGMmanager class is designed to play the necessary BGM sounds in the scene.
 * - Where the code is applied: for any scenes that need to have BGM sound...
 * - History -
 * 2021-07-23: Production completed
 * 2021-07-23: Commenting
 * 2021-07-27: Comment changes based on feedback.
 *
 * - BGMmanager Member Variable 
 * 
 * null
 *
 * - BGMmanager Member Function
 *
 * Awake(): A function that is called before Start() and immediately after prefab instantiation. To prevent overlapping BGM, it checks if another BGMmanager object exists. If it exists, the current object is destroyed. If it doesn't exist, the object is wrapped with the DontDestroyOnLoad function to prevent it from being automatically destroyed when the scene changes.
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This class is intended for playing background music (BGM) in scenes.
public class BGMmanager : MonoBehaviour {
    // This function is called even before the Start function, and it is called immediately after the instantiation of a prefab. To prevent overlapping BGM, this function checks whether another BGMmanager object exists in the scene. If it exists, the current object is destroyed. If it doesn't exist, the object is marked with DontDestroyOnLoad to ensure it is not automatically destroyed when transitioning between scenes.
    void Awake() {
        var obj = FindObjectsOfType<BGMmanager>();
        if (obj != null) {
            if (obj.Length == 1) {
                DontDestroyOnLoad(gameObject);
            } else {
                Destroy(gameObject);
            }
        }
    }
}
