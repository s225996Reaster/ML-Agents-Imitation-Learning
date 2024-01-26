using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Test : MonoBehaviour
{
    public GameManager gm;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    GameObject findChildFromParent(string parentName, string childNameToFind)
    {
        string childLocation = parentName + "/" + childNameToFind;
        GameObject childObject = GameObject.Find(childLocation);
        return childObject;
    }
}
