using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallRegen : MonoBehaviour
{
    public GameObject RegenPos;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "RegenPoint")
        {
            transform.position = RegenPos.transform.position;
        }
    }
}
