/*
 * - Name: ShowCaption.cs
 * 
 * - Content: Script to control caption on/off buttons.
 * 
 * - History
 *   1) 2021-08-20: Initial development
 *   2) 2021-08-30: Code standardization and comment formatting
 * 
 * - Variables
 *   mcc_CaptionControl: Object for obtaining the caption index from the CaptionControl class.
 *   mg_Offbtn: Reference to the "Off" button.
 *   mg_Onbtn: Reference to the "On" button.
 * 
 * - Functions
 *   captionOn: Function executed when the caption "On" button is pressed.
 *   captionOff: Function executed when the caption "Off" button is pressed.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowCaption : MonoBehaviour
{
    private CaptionControl mcc_CaptionControl;
    private GameObject mg_Offbtn;
    private GameObject mg_Onbtn;

    void Start()
    {
        mcc_CaptionControl = GameObject.Find("CaptionPanel").GetComponent<CaptionControl>();
        mg_Offbtn = GameObject.Find("Off");
        mg_Onbtn = GameObject.Find("On");
    }

    // Function to hide the caption and show the "Off" button when the "On" button is pressed.
    public void captionOn()
    {
        this.gameObject.SetActive(false);
        mg_Onbtn.SetActive(false);
        mg_Offbtn.SetActive(true);
    }

    // Function to show the caption and show the "On" button when the "Off" button is pressed.
    public void captionOff()
    {
        this.gameObject.SetActive(true);
        mg_Onbtn.SetActive(true);
        mg_Offbtn.SetActive(false);
    }
}
