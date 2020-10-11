using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapePos : MonoBehaviour
{
    private float PosPoint;
    public GameObject StarPos;
    public GameObject Posone;
    public GameObject Postwo;
    public GameObject Posthree;
    public GameObject Posfour;

    void Start()
    {
        PosPoint = Random.Range(0f, 4f);
        if (PosPoint >= 0f && PosPoint < 1f)
        {
            StarPos.transform.position = Posone.transform.position;
        }
        else if (PosPoint >= 1f && PosPoint < 2f)
        {
            StarPos.transform.position = Postwo.transform.position;
        }
        else if (PosPoint >= 2f && PosPoint < 3f)
        {
            StarPos.transform.position = Posthree.transform.position;
        }
        else
        {
            StarPos.transform.position = Posfour.transform.position;
        }

    }

}
