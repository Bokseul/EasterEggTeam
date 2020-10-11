using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ChangeScene : MonoBehaviour
{
    public static int SceneNum = 0;
    private bool isScene = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            isScene = true;
        }
    }

    private void Update()
    {
        if (isScene)
        {
            SceneManager.LoadScene(++SceneNum);
        }
    }
}
