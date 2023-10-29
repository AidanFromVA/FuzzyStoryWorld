/*
 * - Name: BlinkObject.cs
 * - Writer: Kim Myung Hyun
 * 
 * - Content:
 * A script that adds a blinking effect to an object.
 * 
 * - History
 * 1. 2021-07-27: Initial draft
 *                  
 * - Variables 
 * mf_time: Variable for time measurement.
 * mb_BlinkFlag: If the Flag is True, the object blinks.
 * mb_HideFlag: If the Hide Flag is on, the object is hidden.
 * 
 * - Functions
 * v_StartBlink(): Makes the object blink.
 * v_StopBlink(): Removes the blinking effect and shows the object.
 * v_HideObject(): Sets the object to be invisible.
 * ChangBlinkFlagTrue(): Changes the Blink Flag to True.
 * ChangeBlinkFlagFalse(): Changes the Blink Flag to False.
 * ChangeHideFlagTrue(): Sets the object hiding Flag to True.
 * ChangeHideFlagFalse(): Sets the object hiding Flag to False.
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkObject : MonoBehaviour
{
    float mf_time;
    bool mb_BlinkFlag = true;
    bool mb_HideFlag = false;

    // Update is called once per frame
    void Update()
    {
        if (mb_BlinkFlag == true)
        {
            v_StartBlink();
        }
        else if (mb_BlinkFlag == false && mb_HideFlag == false)
        {
            v_StopBlink();
        }
        else if (mb_HideFlag == true)
        {
            v_HideObject();
        }
    }

    #region Function Declarations
    /// <summary>
    /// Makes the object blink.
    /// </summary>
    public void v_StartBlink()
    {
        if (mf_time < 0.5f)
        {
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
        }
        else
        {
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
            if (mf_time > 1f)
                mf_time = 0;
        }
        mf_time += Time.deltaTime;
    }
    /// <summary>
    /// Removes the blinking effect and shows the object.
    /// </summary>
    public void v_StopBlink()
    {
        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
    }
    /// <summary>
    /// Sets the object to be invisible.
    /// </summary>
    public void v_HideObject()
    {
        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
    }
    /// <summary>
    /// Changes the Blink Flag to True.
    /// </summary>
    public void ChangBlinkFlagTrue()
    {
        mb_BlinkFlag = true;
    }
    /// <summary>
    /// Changes the Blink Flag to False.
    /// </summary>
    public void ChangeBlinkFlagFalse()
    {
        mb_BlinkFlag = false;
    }
    /// <summary>
    /// Sets the object hiding Flag to True.
    /// </summary>
    public void ChangeHideFlagTrue()
    {
        mb_HideFlag = true;
    }
    /// <summary>
    /// Sets the object hiding Flag to False.
    /// </summary>
    public void ChangeHideFlagFalse()
    {
        mb_HideFlag = false;
    }
    #endregion
}
