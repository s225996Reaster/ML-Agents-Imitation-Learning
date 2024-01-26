using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class StatusManager : MonoBehaviour
{
    public GameObject n_attack;
    GameObject marker;
    //Slider hp;
    GameManager gm;
    //力量,敏捷,智力,體質,外貌,意志,體型,教育,機動力
    //str, dex, int, con, app, pow, siz, edu, mov
    //s_ = player status
    //[SerializeField]
    public int s_str, s_dex, s_int, s_con, s_app, s_pow, s_siz, s_edu, s_mov;
    [SerializeField]
    int hp, tou, mov, speed;

    GameObject findChildFromParent(string parentName, string childNameToFind)
    {
        string childLocation = parentName + "/" + childNameToFind;
        GameObject childObject = GameObject.Find(childLocation);
        return childObject;
    }

    private void Awake()
    {
        PlayerPrefs.DeleteAll();
        if (s_app == 0 && s_con == 0 && s_dex == 0 && s_edu == 0 && s_int == 0 && s_mov == 0)
            GetStatus();
        hp = s_con + s_siz;
        Debug.Log(hp);
        tou = (s_con + s_siz) / 3;
        speed = (s_dex - s_siz / 5)*10;
    }

    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        string t=gameObject.tag;
        if(t=="LittleNightmare")
        {
            LittleNightmare ln = gameObject.GetComponent<LittleNightmare>();
            ln.ChangeStatue();
        }
        //marker = findChildFromParent(gameObject.name, "Marker");
        //hp = findChildFromParent(gameObject.name, "Health").GetComponent<Slider>();
    }

    //getter method
    #region
    public int GetStr()
    {
        //s_str = ConvertStringToNumber(PlayerPrefs.GetString("str"));
        //s_str = PlayerPrefs.GetInt("str");
        return s_str;
    }

    public int GetDex()
    {
        //s_dex = ConvertStringToNumber(PlayerPrefs.GetString("dex"));
        //s_dex = PlayerPrefs.GetInt("dex");
        return s_dex;
    }

    public int GetInt()
    {
        //s_int = ConvertStringToNumber(PlayerPrefs.GetString("int"));
        //s_int = PlayerPrefs.GetInt("int");
        return s_int;
    }

    public int GetCon()
    {
        //s_con = ConvertStringToNumber(PlayerPrefs.GetString("con"));
        //s_con = PlayerPrefs.GetInt("con");
        return s_con;
    }

    public int GetApp()
    {
        //s_app = ConvertStringToNumber(PlayerPrefs.GetString("app"));
        //s_app = PlayerPrefs.GetInt("app");
        return s_app;
    }

    public int GetPow()
    {
        //s_pow = ConvertStringToNumber(PlayerPrefs.GetString("pow"));
        //s_app = PlayerPrefs.GetInt("app");
        return s_pow;
    }

    public int GetSiz()
    {
        //s_siz = ConvertStringToNumber(PlayerPrefs.GetString("siz"));
        //s_siz = PlayerPrefs.GetInt("siz");
        return s_siz;
    }

    public int GetEdu()
    {
        //s_edu = ConvertStringToNumber(PlayerPrefs.GetString("edu"));
        //s_edu = PlayerPrefs.GetInt("edu");
        return s_edu;
    }

    public int GetMov()
    {
        //s_mov = ConvertStringToNumber(PlayerPrefs.GetString("mov"));
        //s_mov = PlayerPrefs.GetInt("mov");
        return s_mov;
    }
    #endregion

    public void SetHp(int hp_value)
    {
        hp = hp_value;
        Debug.Log("SetHp = " + hp);
    }

    public int GetHp()
    {
        return hp;
    }

    public void SetTou(int tou_value)
    {
        tou = tou_value;
    }

    public int GetTou()
    {
        return tou;
    }

    public int GetSpeed()
    {
        return speed;
    }

    void GetStatus()
    {
        s_str = PlayerPrefs.GetInt("str");
        s_dex = PlayerPrefs.GetInt("dex");
        s_int = PlayerPrefs.GetInt("int");
        s_con = PlayerPrefs.GetInt("con");
        s_app = PlayerPrefs.GetInt("app");
        s_pow = PlayerPrefs.GetInt("pow");
        s_siz = PlayerPrefs.GetInt("siz");
        s_edu = PlayerPrefs.GetInt("edu");
        s_mov = PlayerPrefs.GetInt("mov");
        //s_str = ConvertStringToNumber(PlayerPrefs.GetString("str"));
        //s_dex = ConvertStringToNumber(PlayerPrefs.GetString("dex"));
        //s_int = ConvertStringToNumber(PlayerPrefs.GetString("int"));
        //s_con = ConvertStringToNumber(PlayerPrefs.GetString("con"));
        //s_app = ConvertStringToNumber(PlayerPrefs.GetString("app"));
        //s_pow = ConvertStringToNumber(PlayerPrefs.GetString("pow"));
        //s_siz = ConvertStringToNumber(PlayerPrefs.GetString("siz"));
        //s_edu = ConvertStringToNumber(PlayerPrefs.GetString("edu"));
        //s_mov = ConvertStringToNumber(PlayerPrefs.GetString("mov"));
        if (s_app == 0 && s_con == 0 && s_dex == 0 && s_edu == 0 && s_int == 0 && s_mov == 0)
            SetDefaultStatue();
    }

    void SetDefaultStatue()
    {
        //Debug.Log("DefaultStatue is Set");
        PlayerPrefs.SetInt("str", 5);
        PlayerPrefs.SetInt("dex", 5);
        PlayerPrefs.SetInt("int", 5);
        PlayerPrefs.SetInt("con", 5);
        PlayerPrefs.SetInt("app", 5);
        PlayerPrefs.SetInt("pow", 5);
        PlayerPrefs.SetInt("siz", 5);
        PlayerPrefs.SetInt("edu", 5);
        PlayerPrefs.SetInt("mov", 5);
        //PlayerPrefs.SetString("str", "F");
        //PlayerPrefs.SetString("dex", "F");
        //PlayerPrefs.SetString("int", "F");
        //PlayerPrefs.SetString("con", "F");
        //PlayerPrefs.SetString("app", "F");
        //PlayerPrefs.SetString("pow", "F");
        //PlayerPrefs.SetString("siz", "F");
        //PlayerPrefs.SetString("edu", "F");
        //PlayerPrefs.SetString("mov", "F");
        GetStatus();
        //Debug.Log(ConvertStringToNumber("AB")+" "+ConvertStringToNumber("AC")+" "+ ConvertStringToNumber("AD"));
        //Debug.Log(ConvertNumberToString(10) + " " + ConvertNumberToString(11) + " " + ConvertNumberToString(12));
    }

    int ConvertStringToNumber(string str)
    {
        string t="";
        int result = 0;
        for (int i = 0; i <= str.Length - 1; i++)
        {
            switch (str[i])
            {
                case 'A':
                    t += "0";
                    break;
                case 'B':
                    t += "1";
                    break;
                case 'C':
                    t += "2";
                    break;
                case 'D':
                    t += "3";
                    break;
                case 'E':
                    t += "4";
                    break;
                case 'F':
                    t += "5";
                    break;
                case 'G':
                    t += "6";
                    break;
                case 'H':
                    t += "7";
                    break;
                case 'I':
                    t += "8";
                    break;
                case 'J':
                    t += "9";
                    break;
                default:
                    t += "0";
                    break;
            }
        }
        try { result = int.Parse(t); }
        catch (Exception e) { }
        return result;
    }

    public static string ConvertNumberToString(int number)
    {
        string s_num = number.ToString();
        string t = "";
        for (int i = 0; i <= s_num.Length - 1; i++)
        {
            switch (s_num[i])
            {
                case '0':
                    t += "A";
                    break;
                case '1':
                    t += "B";
                    break;
                case '2':
                    t += "C";
                    break;
                case '3':
                    t += "D";
                    break;
                case '4':
                    t += "E";
                    break;
                case '5':
                    t += "F";
                    break;
                case '6':
                    t += "G";
                    break;
                case '7':
                    t += "H";
                    break;
                case '8':
                    t += "I";
                    break;
                case '9':
                    t += "J";
                    break;
                default:
                    t += "";
                    break;
            }
        }
        //Debug.Log(t);
        return t;
    }
}
