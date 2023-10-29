/*
 * - Name: ScriptManager.cs
 * 
 * - Content:
 *   Script for managing scripts (dialogues).
 * 
 * - History -
 *   1. 2021-07-27: Initial draft
 * 
 * - Usage
 *   1. Populate the `ms_Script` array with your scripts (dialogues).
 *   2. Connect the object where you want to display the text to `mg_ScriptObject`.
 *   3. Use functions to display scripts or clear the content.
 * 
 * - Variables
 *   ms_Script: An array for storing scripts (dialogues).
 *   mg_ScriptObject: Objects where the scripts will be displayed.
 *   mn_ScriptSequence: Variable to store the sequence of scripts (dialogues) to be displayed.
 * 
 * - Functions
 *   v_NoneScript(int nGameObjectNum): Function to set the text to blank for the specified object.
 *   v_NextScript(int nGameObjectNum): Function to display the next string stored at the specified index of the object's text.
 *   v_NextScript(int nGameObjectNum, int nScriptnum): Function to display the string at the specified index.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// A script for managing scripts (dialogues). It allows you to set the text of connected objects to either blank or predefined strings.
/// </summary>
public class ScriptManager : MonoBehaviour
{
    #region Variable Declarations

    public string[] ms_Script;                  // Array for storing scripts (dialogues).
    public GameObject[] mg_ScriptObject;        // Objects where scripts will be displayed.
    int mn_ScriptSequence = -1;                // Variable to store the sequence of scripts (dialogues) to be displayed.

    #endregion

    #region Function Declarations

    /// <summary>
    /// Sets the text to blank for the specified object.
    /// </summary>
    /// <param name="nGameObjectNum">Index of the object to clear the text.</param>
    public void v_NoneScript(int nGameObjectNum)
    {
        mg_ScriptObject[nGameObjectNum].GetComponent<Text>().text = "";
    }

    /// <summary>
    /// Displays the next string stored at the specified index of the object's text.
    /// </summary>
    /// <param name="nGameObjectNum">Index of the object where the text will be displayed.</param>
    public void v_NextScript(int nGameObjectNum)
    {
        mn_ScriptSequence += 1; // Increment the sequence before displaying.
        if (mn_ScriptSequence < ms_Script.Length)
        {
            mg_ScriptObject[nGameObjectNum].GetComponent<Text>().text = ms_Script[mn_ScriptSequence];
        }
        else if (mn_ScriptSequence >= ms_Script.Length)
        {
            Debug.Log(mg_ScriptObject[nGameObjectNum].name + " exceeded the maximum script array size.");
        }
    }

    /// <summary>
    /// Displays the string at the specified index.
    /// </summary>
    /// <param name="nGameObjectNum">Index of the object where the text will be displayed.</param>
    /// <param name="nScriptnum">Index of the text to be displayed.</param>
    public void v_NextScript(int nGameObjectNum, int nScriptnum)
    {
        if (nScriptnum >= ms_Script.Length)
        {
            Debug.Log(mg_ScriptObject[nGameObjectNum].name + " attempted to access an index beyond the maximum string array size using the NextScript(" + nScriptnum + ") function.");
        }
        else
        {
            mg_ScriptObject[nGameObjectNum].GetComponent<Text>().text = ms_Script[nScriptnum];
        }
    }

    #endregion
}
