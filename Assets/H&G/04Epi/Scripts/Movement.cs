/*
  * - Name: Movement.cs
  *
  * - Content: Hansel and Gretel Epi4 _ Game object movement script
  * 1) Sound when a rock is dropped
  *
  * - HISTORY
  * 2021-08-05: Initial development
  * 2021-08-06: Code standardization and comment processing
  * 2021-08-20: Reset screen position
  * 2021-08-20: Movement speed reset
  * 2021-08-26: Set the sound when a rock is dropped
  *
  * <Variable>
  * mgo_Gratel: Gretel game object
  * mgo_Hansel: Hansel game object
  * mv3_GratelPos: Target position to move Gretel to
  * mv3_HanselPos: Target position to move Hansel to
  * mgo_Dad: Father game object
  * mgo_Mom: Mother game object
  * mv3_DadPos: Target position to move father
  * mv3_MomPos: Target position to move mother
  * mgo_RockRight: Right stone game object
  * mgo_RockMid: Middle stone game object
  * mgo_RockLeft: Left rock game object
  * mv3_RockRightPosBefore: Target position to move before the right stone falls
  * mv3_RockMidPosBefore: Target position to move before the middle stone falls
  * mv3_RockLeftPosBefore: Target position to move before the left stone falls
  * mv3_RockRightPosAfter: Target position to move to after dropping the right stone
  * mv3_RockMidPosAfter: Target position to move to after the middle stone falls
  * mv3_RockLeftPosAfter: Target position to move to after the left stone falls
  *
  * <Function>
  * ChangePosition(GameObject go_Object,Vector3 v3_Pos,float f_Velocity): A function where go_Object moves to the v3_Pos position at f_Velocity speed.
  */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

 //Game object movement script from Epi4
public class Movement : MonoBehaviour
{
    //Variables needed to move Hansel and Gretel
    private GameObject mgo_Gratel;
    private GameObject mgo_Hansel;
    private Vector3 mv3_GratelPos;
    private Vector3 mv3_HanselPos;
    
    //Variables needed to move father and mother
    private GameObject mgo_Dad;
    private GameObject mgo_Mom;
    private Vector3 mv3_DadPos;
    private Vector3 mv3_MomPos;
    
    //Variables needed to move the pebble
    private GameObject mgo_RockRight;
    private GameObject mgo_RockMid;
    private GameObject mgo_RockLeft;
    private Vector3 mv3_RockRightPosBefore;
    private Vector3 mv3_RockMidPosBefore;
    private Vector3 mv3_RockLeftPosBefore;
    private Vector3 mv3_RockRightPosAfter;
    private Vector3 mv3_RockMidPosAfter;
    private Vector3 mv3_RockLeftPosAfter;

    GameObject mg_SoundManager;

    bool mb_checkFirst;
    bool mb_checkSecond;
    bool mb_checkThird;
    void Start(){
        mgo_Gratel = GameObject.Find("Gratel");
        mgo_Hansel = GameObject.Find("Hansel");
        mv3_GratelPos = new Vector3(-1.5f,1.0f,-6.5f);                          
        mv3_HanselPos = new Vector3(0.4f,1.2f,-6.5f);

        mgo_Dad = GameObject.Find("Dad");
        mgo_Mom = GameObject.Find("Mom");
        mv3_DadPos = new Vector3(-14.0f,1.5f,-7.0f);
        mv3_MomPos = new Vector3(-10.0f,1.5f,-7.0f);

        mgo_RockRight = GameObject.Find("rockright");
        mgo_RockMid = GameObject.Find("rockmid");
        mgo_RockLeft = GameObject.Find("rockleft");
        
        mv3_RockRightPosBefore = new Vector3(0.3f,0.5f,-6.5f);
        mv3_RockMidPosBefore = new Vector3(0.3f,0.5f,-6.5f);
        mv3_RockLeftPosBefore = new Vector3(0.3f,0.5f,-6.5f);
        mv3_RockRightPosAfter = new Vector3(9.0f,-0.5f,-6.5f);
        mv3_RockMidPosAfter = new Vector3(6.0f,-0.5f,-6.5f);
        mv3_RockLeftPosAfter = new Vector3(3.0f,-0.5f,-6.5f);
        
        mg_SoundManager = GameObject.Find("SoundManager");                 

        mb_checkFirst = false;
        mb_checkSecond = false;
        mb_checkThird = false;
    }
void Update(){
    // Gretel movement
    ChangePosition(mgo_Gratel, mv3_GratelPos, 1.0f);

    // Hansel movement
    ChangePosition(mgo_Hansel, mv3_HanselPos, 1.0f);

    // Dad movement
    ChangePosition(mgo_Dad, mv3_DadPos, 2.0f);

    // Mom movement
    ChangePosition(mgo_Mom, mv3_MomPos, 2.0f);

    // First rock movement
    ChangePosition(mgo_RockRight, mv3_RockRightPosBefore, 1.0f);

    // Second rock movement
    ChangePosition(mgo_RockMid, mv3_RockMidPosBefore, 1.0f);

    // Third rock movement
    ChangePosition(mgo_RockLeft, mv3_RockLeftPosBefore, 1.0f);

    if (mgo_Hansel.transform.position.x <= 7.5) {
        // Drop the first rock
        ChangePosition(mgo_RockRight, mv3_RockRightPosAfter, 3.0f);
        if (!mb_checkFirst) {
            // Sound when dropping the rock
            mg_SoundManager.GetComponent<SoundManager>().playSound("DropRock");
            mb_checkFirst = true;
        }

        if (mgo_Hansel.transform.position.x <= 4.5) {
            // Drop the second rock
            ChangePosition(mgo_RockMid, mv3_RockMidPosAfter, 3.0f);
            if (!mb_checkSecond) {
                // Sound when dropping the rock
                mg_SoundManager.GetComponent<SoundManager>().playSound("DropRock");
                mb_checkSecond = true;
            }
            
            if (mgo_Hansel.transform.position.x <= 1.5) {
                // Drop the third rock
                ChangePosition(mgo_RockLeft, mv3_RockLeftPosAfter, 3.0f);
                if (!mb_checkThird) {
                    // Sound when dropping the rock
                    mg_SoundManager.GetComponent<SoundManager>().playSound("DropRock");
                    mb_checkThird = true;
                }
            }
        }
    }
}

// Move goObject to v3Pos with a velocity of fVelocity
void ChangePosition(GameObject goObject, Vector3 v3Pos, float fVelocity) {
    goObject.transform.position = Vector3.MoveTowards(goObject.transform.position, v3Pos, fVelocity * Time.deltaTime);
}

