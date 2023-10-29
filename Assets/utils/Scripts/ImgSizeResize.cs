/*
 * - Name: ImgSizeResize.cs
 * - Content: A script that adjusts the game screen to fit the device's screen size. 
 * - History -
 * 2021-07-23: Commented
 * 2021-07-27: Comment updates based on feedback.
 *
 * - ImgSizeResize Member Variables
 *
 * sprImg: A variable that stores the sprite (background image) received from the Inspector window.
 *
 * - ImgSizeResize Member Functions
 *
 * Start(): Initializes the script to adjust the sprite (background image) and canvas received from the Inspector window to fit the device's screen size.
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// This script is responsible for adjusting the background image to fit the screen of the device in all stages.
public class ImgSizeResize : MonoBehaviour {
    public Sprite sprImg = null;

    // Initializes the script to adjust the sprite (background image) and canvas received from the Inspector window to fit the device's screen size.
    void Start() {
        GameObject tempImg = transform.GetChild(0).gameObject;
        if (sprImg == null) {
            RectTransform rt_saveTransform = (RectTransform)this.transform;
            rt_saveTransform.sizeDelta = new Vector2(Screen.width, Screen.height);
            return;
        }
        Image img = tempImg.GetComponent<Image>() as Image;
        img.sprite = sprImg;
        RectTransform rt_saveImgTransform = (RectTransform)tempImg.transform;
        rt_saveImgTransform.sizeDelta = new Vector2(Screen.width, Screen.height);
    }
}
