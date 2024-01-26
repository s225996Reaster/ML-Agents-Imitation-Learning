using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ModeText : MonoBehaviour
{
    public TextMeshProUGUI tmpText;
    void Start()
    {
        tmpText.text = "Ground";
    }

    public void TextChange()
    {
        if(tmpText.text == "Ground")
        {
            tmpText.text = "Air";
        }
        else
            tmpText.text = "Ground";
    }
}
