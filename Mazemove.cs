using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mazemove : MonoBehaviour
{
    public float RotateSpeed;
    private float UpDown_R;
    private float LeftRight_R;
    void Start()
    {
        RotateSpeed = 1f;
    }
    
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow) && UpDown_R <= 10)
        {
            transform.Rotate(-RotateSpeed, 0f, 0f);
            UpDown_R++;
        }
        else if (Input.GetKey(KeyCode.DownArrow) && UpDown_R >= -10)
        {
            transform.Rotate(RotateSpeed, 0f, 0f);
            UpDown_R--;
        }
        if (Input.GetKey(KeyCode.LeftArrow) && LeftRight_R <= 10)
        {
            transform.Rotate(0f, 0f, -RotateSpeed);
            LeftRight_R++;
        }
        else if (Input.GetKey(KeyCode.RightArrow) && LeftRight_R >= -10)
        {
            transform.Rotate(0f, 0f, RotateSpeed);
            LeftRight_R--;
        }
    }
}
