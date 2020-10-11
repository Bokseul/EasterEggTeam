using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePoint : MonoBehaviour
{
    GameObject StartPosObj;
    GameObject SavePosObj;

    private bool dropstart;
    private bool dropsave;

    private void Awake()
    {
        StartPosObj = GameObject.Find("StartPos");
        SavePosObj = GameObject.Find("SavePos");
    }
    void Update()
    {
        if (dropstart)
        {
            transform.position = StartPosObj.transform.position;
            dropstart = false;
        }
        if (dropsave)
        {
            transform.position = SavePosObj.transform.position;
            dropsave = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "StartPos")
        {
            dropstart = true;
        }
        else if (other.tag == "SavePos")
        {
            dropsave = true;
        }
    }
}
