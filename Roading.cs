using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roading : MonoBehaviour
{
    Vector3 vecResetPos;
    private void Start()
    {
        vecResetPos = new Vector3(transform.position.x, 105, transform.position.z);
    }
    void Update()
    {
        transform.Translate(0, -1, 0);
        if (transform.position.y < -40)
        {
            transform.position = vecResetPos;

        }
    }
            

}
