/*
 * - Name: FixedStartScene.cs
 * - Content: Regardless of which scene you're playing in, this script will move you to the scene defined in this script. The intent here is to fix the starting scene, ensuring that the game always starts from the "intro" scene.
 * - History -
 * 2021-07-26: Commented
 * 2021-07-27: Comment updates based on feedback.
 *
 * - FixedStartScene Member Variable
 * 
 * null
 * 
 * - FixedStartScene Member Function
 * 
 * FirstLoad(): A function annotated with [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)], meaning that it is the first function to be loaded and called. This function is used to navigate to the "intro" scene.
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// This script ensures that the specified scene is the first scene displayed, regardless of the scene you were in.
public class FixedStartScene : MonoBehaviour {
    
     [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
     // Fix the "intro" scene as the first scene.
     static void FirstLoad()
     {
        if (SceneManager.GetActiveScene().name.CompareTo("intro") != 0){
           SceneManager.LoadScene("0_02Intro");
        }
     }
    
}
