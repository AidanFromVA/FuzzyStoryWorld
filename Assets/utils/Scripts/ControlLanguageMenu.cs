/*
 * - Name: ControlLanguageMenu.cs
 *
 * - Content: Controls the language change menu to show or hide it as needed.
 * 
 * - History
 * 1) 2021-08-27: Set up the language change menu to be hidden or shown.
 * 
 * - Variables
 * mg_Country: Variable for connecting to the country object
 * mg_LanguagePanel: Variable for connecting to the background panel behind the language menu
 * ms_ButtonImage: Button image
 * ms_ButtonImageFlip: Button image flipped vertically
 * 
 * - Function
 * v_ControlLanguageMenu(): Function to show or hide the list of countries when the button is pressed.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlLanguageMenu : MonoBehaviour
{
    GameObject mg_Country;
    GameObject mg_LanguagePanel;
    public Sprite ms_ButtonImage;
    public Sprite ms_ButtonImageFlip;

    void Start()
    {
        // Object connections
        mg_Country = GameObject.Find("Country");
        mg_LanguagePanel = GameObject.FindWithTag("LanguagePanel");

        // First run without a key
        if (PlayerPrefs.HasKey("ShowLanguageMenu") == false)
        {
            PlayerPrefs.SetInt("ShowLanguageMenu", 1);
            mg_Country.SetActive(true);
            mg_LanguagePanel.SetActive(true);
        }
        // Menu is open
        else if (PlayerPrefs.GetInt("ShowLanguageMenu") == 1)
        {
            mg_Country.SetActive(true);
            this.GetComponent<Image>().sprite = ms_ButtonImage;
            mg_LanguagePanel.GetComponent<RectTransform>().localPosition = new Vector3(50f, -50f, 0);
            mg_LanguagePanel.GetComponent<RectTransform>().localScale = new Vector3(0.1f, 0.53f, 0);
            this.transform.localPosition = new Vector3(40, -325, 0);
        }
        // Menu is closed
        else if (PlayerPrefs.GetInt("ShowLanguageMenu") == 0)
        {
            mg_Country.SetActive(false);
            this.GetComponent.Image().sprite = ms_ButtonImageFlip;
            mg_LanguagePanel.GetComponent<RectTransform>().localPosition = new Vector3(50f, 200f, 0);
            mg_LanguagePanel.GetComponent<RectTransform>().localScale = new Vector3(0.1f, 0.1f, 0);
            this.transform.localPosition = new Vector3(40, 175, 0);
        }
    }

    public void v_ControlLanguageMenu()
    {
        // Closing the open menu
        if (PlayerPrefs.GetInt("ShowLanguageMenu") == 1)
        {
            PlayerPrefs.SetInt("ShowLanguageMenu", 0);
            mg_Country.SetActive(false);
            mg_LanguagePanel.GetComponent<RectTransform>().localPosition = new Vector3(50f, 200f, 0);
            mg_LanguagePanel.GetComponent<RectTransform>().localScale = new Vector3(0.1f, 0.1f, 0);
            this.GetComponent<Image>().sprite = ms_ButtonImageFlip;
            this.transform.localPosition = new Vector3(40, 175, 0);  
        }
        // Opening the closed menu
        else if (PlayerPrefs.GetInt("ShowLanguageMenu") == 0)
        {
            PlayerPrefs.SetInt("ShowLanguageMenu", 1);
            mg_Country.SetActive(true);
            mg_LanguagePanel.GetComponent<RectTransform>().localPosition = new Vector3(50f, -50f, 0);
            mg_LanguagePanel.GetComponent<RectTransform>().localScale = a Vector3(0.1f, 0.53f, 0);
            this.GetComponent<Image>().sprite = ms_ButtonImage;
            this.transform.localPosition = new Vector3(40, -325, 0);
        }
    }
}
