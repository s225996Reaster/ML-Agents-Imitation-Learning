using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEditor;

public class LittleNightmare : MonoBehaviour
{
    //力量,敏捷,智力,體質,外貌,意志,體型,教育,機動力
    //str, dex, int, con, app, pow, siz, edu, mov
    int hp, tou, mov;
    float dmg, heal;
    float t_dmg;
    public List<GameObject> skillSetList = new List<GameObject>();
    //GameObject aCollider;
    bool airMode = false;
    GameManager gm;
    bool myTurn = false;
    //private void Awake()
    //{
    //    CreateNewTag("LittleNightmare");
    //    this.gameObject.tag = "LittleNightmare";
        
    //}

    void Awake()
    {
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        gameObject.name = "LittleNightmare";
        ChangeStatue();
        foreach (GameObject obj in skillSetList)
            obj.SetActive(false);
        //aCollider = gameObject.transform.Find("AttackCollider").gameObject;
        //aCollider.SetActive(false);
    }

    public void Action()
    {
        Debug.Log("nm action");
        foreach (GameObject obj in skillSetList)
            obj.SetActive(true);
        myTurn = true;
    }

    public bool AgentTurnStart()
    {
        return myTurn;
    }

    public void AgentTurnEnd()
    {
        myTurn = false;
    }

    public void ChangeStatue()
    {
        try
        {
            //StatusManager sm = GameObject.FindGameObjectWithTag("LittleNightmare").GetComponent<StatusManager>();
            Status sm = gameObject.GetComponent<Status>();
            hp = (sm.GetCon() + sm.GetSiz());
            tou = (sm.GetCon() + sm.GetSiz()) * 1;
            sm.SetHp(hp);
            sm.SetTou(tou);
            //Debug.Log("ChangeStatue");
        }
        catch(Exception e) { Debug.Log(e); }
    }

    //敵我，範圍，hp傷害(dmg)，韌性傷害(t_dmg)，治療(heal)，buff，debuff
    public void AirModeSwitch()
    {
        if (!airMode)
            airMode = true;
        else
            airMode = false;
        gm.AimTheTarget_False();
    }

    public bool IsitAirMode()
    {
        return airMode;
    }

    public void BladeAttack()
    {
        // 
        //do some perpare action
        // 
        if(airMode)
        {
            Status sm = gameObject.GetComponent<Status>();
            dmg = sm.GetStr() + (float)((double)sm.GetCon() * 0.3) + (float)((double)sm.GetSiz() * 0.3);
            t_dmg = sm.GetStr() + (float)((double)sm.GetCon() * 0.2) + (float)((double)sm.GetSiz() * 0.2);
            try
            {
                GameManager gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
                Debug.Log("dmg:" + dmg);
                gm.ActionMark(dmg, t_dmg, 2,airMode,true);
                //sm.IsItGrounded(false);
            }
            catch (Exception e) { Debug.Log(e); }
        }
        else
        try
        {
            Status sm = gameObject.GetComponent<Status>();
            dmg = sm.GetStr() + (float)((double)sm.GetCon() * 0.3) + (float)((double)sm.GetSiz() * 0.3);
            t_dmg = sm.GetStr() + (float)((double)sm.GetCon() * 0.2) + (float)((double)sm.GetSiz() * 0.2);
            try
            {
                GameManager gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
                Debug.Log("dmg:" + dmg);
                gm.ActionMark(dmg,t_dmg,2);
                //aCollider.SetActive(true);
            }
            catch (Exception e) { Debug.Log(e); }
        }
        catch (Exception e) { Debug.Log(e); }

        
    }

    public void AgentBladeAttack(int target)
    {
        try
        {
            Debug.Log("Agent Blade Attack");
            Status sm = gameObject.GetComponent<Status>();
            dmg = sm.GetStr() + (float)((double)sm.GetCon() * 0.3) + (float)((double)sm.GetSiz() * 0.3);
            t_dmg = sm.GetStr() + (float)((double)sm.GetCon() * 0.2) + (float)((double)sm.GetSiz() * 0.2);
            gm.AgentActionMark(dmg, t_dmg, target);
        }
        catch (Exception e) { Debug.Log(e); }
    }

    public void FistAttack()
    {
        // 
        //do some perpare action
        // 
        
        Status sm = gameObject.GetComponent<Status>();
        Debug.Log(sm.IsItGrounded());
        if (airMode)
        {
            dmg = sm.GetStr() + (float)((double)sm.GetCon() * 0.2) + (float)((double)sm.GetSiz() * 0.2);
            t_dmg = sm.GetStr() + (float)((double)sm.GetCon() * 0.2) + (float)((double)sm.GetSiz() * 0.5);
            gm.SelfActionMark(1, 0);
        }
        else
        {
            dmg = sm.GetStr() + (float)((double)sm.GetCon() * 0.2) + (float)((double)sm.GetSiz() * 0.2);
            t_dmg = sm.GetStr() + (float)((double)sm.GetCon() * 0.2) + (float)((double)sm.GetSiz() * 0.5);
        }
        
        try
        {
            GameManager gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
            Debug.Log("dmg:" + dmg);
            if (airMode&&sm.IsItGrounded())
            {
                
                if(sm.FocusStack()>0)
                    gm.FocusActionMark(1, 1, dmg, t_dmg, 1, true, true);
                else
                    gm.FocusActionMark(1, 1, dmg, t_dmg, 1, true, false);
            }
            else if (airMode && !sm.IsItGrounded())
            {
                gm.ActionMark(dmg, t_dmg, 1, false, true);
            }
            else if (!sm.IsItGrounded())
            {
                gm.ActionMark(dmg, t_dmg, 1, false, false);
            }
            else
            {
                gm.ActionMark(dmg, t_dmg, 1);
            }
            
        }
        catch (Exception e) { Debug.Log(e); }
    }

    public void AgentFistAttack(int target)
    {
        try
        {
            Debug.Log("Agent Fist Attack");
            Status sm = gameObject.GetComponent<Status>();
            dmg = sm.GetStr() + (float)((double)sm.GetCon() * 0.2) + (float)((double)sm.GetSiz() * 0.2);
            t_dmg = sm.GetStr() + (float)((double)sm.GetCon() * 0.2) + (float)((double)sm.GetSiz() * 0.5);
            gm.AgentActionMark(dmg, t_dmg, target);
        }
        catch (Exception e) { Debug.Log(e); }
    }

    public void MagicAttack()
    {
        // 
        //do some perpare action
        // 
        Status sm = gameObject.GetComponent<Status>();
        dmg = sm.GetStr() + (float)((double)sm.GetCon() * 0.2) + (float)((double)sm.GetSiz() * 0.2);
        t_dmg = sm.GetStr() + (float)((double)sm.GetCon() * 0.2) + (float)((double)sm.GetSiz() * 0.2);
        try
        {
            GameManager gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
            if (!airMode)
            {
                Debug.Log("dmg:" + dmg);
                gm.MagicActionMark(dmg, t_dmg, 4);
            }
            else
            {
                gm.MagicActionMark(dmg, t_dmg, 4);
                //gm.PullActionMark(dmg);
            }
                
        }
        catch (Exception e) { Debug.Log(e); }
    }

    public void AgentMagicAttack(int target)
    {
        try
        {
            Debug.Log("Agent Magic Attack");
            Status sm = gameObject.GetComponent<Status>();
            dmg = sm.GetStr() + (float)((double)sm.GetCon() * 0.2) + (float)((double)sm.GetSiz() * 0.2);
            t_dmg = sm.GetStr() + (float)((double)sm.GetCon() * 0.2) + (float)((double)sm.GetSiz() * 0.2);
            gm.AgentActionMark(dmg, t_dmg, target);
        }
        catch (Exception e) { Debug.Log(e); }
    }

    //static void CreateNewTag(string tagName)
    //{
    //    SerializedObject tagManager = new SerializedObject(
    //        AssetDatabase.LoadAllAssetsAtPath("ProjectSettings/TagManager.asset")[0]);
    //    SerializedProperty tagsProp = tagManager.FindProperty("tags");

    //    // Check if the tag already exists
    //    bool tagExists = false;
    //    for (int i = 0; i < tagsProp.arraySize; i++)
    //    {
    //        SerializedProperty t = tagsProp.GetArrayElementAtIndex(i);
    //        if (t.stringValue == tagName)
    //        {
    //            tagExists = true;
    //            break;
    //        }
    //    }

    //    // Add the tag if it doesn't exist
    //    if (!tagExists)
    //    {
    //        tagsProp.InsertArrayElementAtIndex(tagsProp.arraySize);
    //        SerializedProperty newTag = tagsProp.GetArrayElementAtIndex(tagsProp.arraySize - 1);
    //        newTag.stringValue = tagName;
    //        tagManager.ApplyModifiedProperties();
    //    }
    //}
}
