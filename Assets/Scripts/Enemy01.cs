using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Enemy01 : MonoBehaviour
{
    GameObject marker;
    int hp, tou, mov;
    GameManager gm;
    EnemyStatus es;
    float dmg, heal;
    int t_dmg;
    //力量,敏捷,智力,體質,外貌,意志,體型,教育,機動力
    //s_ = player status
    //[SerializeField]
    //private int s_str, s_dex, s_int, s_con, s_app, s_pow, s_siz, s_edu, s_mov;
    //string code = "e01";

    GameObject findChildFromParent(string parentName, string childNameToFind)
    {
        string childLocation = parentName + "/" + childNameToFind;
        GameObject childObject = GameObject.Find(childLocation);
        return childObject;
    }

    private void Awake()
    {
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        gameObject.name = "Enemy01";
        ChangeStatue();
    }

    public void Action()
    {
        Debug.Log("e01 action "+gameObject.tag);
        //using methop to do st
        RandomAction();
    }

    void Start()
    {

    }

    public void ChangeStatue()
    {
        try
        {
            //StatusManager sm = GameObject.FindGameObjectWithTag("LittleNightmare").GetComponent<StatusManager>();
            Status sm = gameObject.GetComponent<Status>();
            hp = (sm.GetCon() + sm.GetSiz());
            tou = (sm.GetCon() + sm.GetSiz()) / 2;
            sm.SetHp(hp);
            sm.SetTou(tou);
            //Debug.Log("ChangeStatue");
        }
        catch { }
    }

    public void RandomAction()
    {
        NormalAttack();
    }

    public void ToGM_Action()
    {
        if (gameObject.tag == "Enemy1")
            gm.eActionMark(0, dmg);
        else if (gameObject.tag == "Enemy2")
            gm.eActionMark(1, dmg);
        else if (gameObject.tag == "Enemy3")
            gm.eActionMark(2, dmg);
        else if (gameObject.tag == "Enemy4")
            gm.eActionMark(3, dmg);
    }

    public void NormalAttack()
    {
        try
        {
            Status sm = gameObject.GetComponent<Status>();
            dmg = sm.GetStr() + (float)((double)sm.GetCon() * 0.2) + (float)((double)sm.GetSiz() * 0.2);
            try
            {
                GameManager gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
                Debug.Log("dmg:" + dmg);
                ToGM_Action();
            }
            catch (Exception e) { Debug.Log("nattack false in\n"+e); }
        }
        catch (Exception e) { Debug.Log("nattack false "+e); }


    }

    public void HeavyAttack()
    {
        dmg = PlayerPrefs.GetInt("str") + (float)((double)PlayerPrefs.GetInt("con") * 0.5);
        try
        {
            GameManager gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
            Debug.Log("dmg:" + dmg);
            ToGM_Action();
        }
        catch (Exception e) { Debug.Log("nattack false " + e); }
    }

    public void GunAttack()
    {
        try
        {
            Status sm = gameObject.GetComponent<Status>();
            dmg = sm.GetStr() + (float)((double)sm.GetCon() * 0.2) + (float)((double)sm.GetSiz() * 0.2);
            try
            {
                GameManager gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
                Debug.Log("dmg:" + dmg);
                ToGM_Action();
            }
            catch (Exception e) { Debug.Log("nattack false in\n" + e); }
        }
        catch (Exception e) { Debug.Log("nattack false "+e); }


    }

    //getter method
    //#region
    //public int GetStr()
    //{
    //    //s_str = ConvertStringToNumber(PlayerPrefs.GetString("str"));
    //    s_str = PlayerPrefs.GetInt(code + "_str");
    //    return s_str;
    //}

    //public int GetDex()
    //{
    //    //s_dex = ConvertStringToNumber(PlayerPrefs.GetString("dex"));
    //    s_dex = PlayerPrefs.GetInt(code + "_dex");
    //    return s_dex;
    //}

    //public int GetInt()
    //{
    //    //s_int = ConvertStringToNumber(PlayerPrefs.GetString("int"));
    //    s_int = PlayerPrefs.GetInt(code + "_int");
    //    return s_int;
    //}

    //public int GetCon()
    //{
    //    //s_con = ConvertStringToNumber(PlayerPrefs.GetString("con"));
    //    s_con = PlayerPrefs.GetInt(code + "_con");
    //    return s_con;
    //}

    //public int GetApp()
    //{
    //    //s_app = ConvertStringToNumber(PlayerPrefs.GetString("app"));
    //    s_app = PlayerPrefs.GetInt(code + "_app");
    //    return s_app;
    //}

    //public int GetPow()
    //{
    //    //s_pow = ConvertStringToNumber(PlayerPrefs.GetString("pow"));
    //    s_app = PlayerPrefs.GetInt(code + "_app");
    //    return s_pow;
    //}

    //public int GetSiz()
    //{
    //    //s_siz = ConvertStringToNumber(PlayerPrefs.GetString("siz"));
    //    s_siz = PlayerPrefs.GetInt(code + "_siz");
    //    return s_siz;
    //}

    //public int GetEdu()
    //{
    //    //s_edu = ConvertStringToNumber(PlayerPrefs.GetString("edu"));
    //    s_edu = PlayerPrefs.GetInt(code + "_edu");
    //    return s_edu;
    //}

    //public int GetMov()
    //{
    //    //s_mov = ConvertStringToNumber(PlayerPrefs.GetString("mov"));
    //    s_mov = PlayerPrefs.GetInt(code + "_mov");
    //    return s_mov;
    //}
    //#endregion

    //void GetStatus()
    //{
    //    s_str = PlayerPrefs.GetInt(code + "_str");
    //    s_dex = PlayerPrefs.GetInt(code + "_dex");
    //    s_int = PlayerPrefs.GetInt(code + "_int");
    //    s_con = PlayerPrefs.GetInt(code + "_con");
    //    s_app = PlayerPrefs.GetInt(code + "_app");
    //    s_pow = PlayerPrefs.GetInt(code + "_pow");
    //    s_siz = PlayerPrefs.GetInt(code + "_siz");
    //    s_edu = PlayerPrefs.GetInt(code + "_edu");
    //    s_mov = PlayerPrefs.GetInt(code + "_mov");
    //    //s_str = ConvertStringToNumber(PlayerPrefs.GetString("str"));
    //    //s_dex = ConvertStringToNumber(PlayerPrefs.GetString("dex"));
    //    //s_int = ConvertStringToNumber(PlayerPrefs.GetString("int"));
    //    //s_con = ConvertStringToNumber(PlayerPrefs.GetString("con"));
    //    //s_app = ConvertStringToNumber(PlayerPrefs.GetString("app"));
    //    //s_pow = ConvertStringToNumber(PlayerPrefs.GetString("pow"));
    //    //s_siz = ConvertStringToNumber(PlayerPrefs.GetString("siz"));
    //    //s_edu = ConvertStringToNumber(PlayerPrefs.GetString("edu"));
    //    //s_mov = ConvertStringToNumber(PlayerPrefs.GetString("mov"));
    //    if (s_app == 0 && s_con == 0 && s_dex == 0 && s_edu == 0 && s_int == 0 && s_mov == 0)
    //        SetDefaultStatue();
    //}
}
