using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class UserCol : MonoBehaviour
{
    public GameObject Camera;
    public GameObject Light;
    Vector3 VecPlayerCamera = new Vector3(0f, 0f, 0f);
    Vector3 VecPlayerLight = new Vector3(0f, 0f, 0f);

    void Start()
    {
        VecPlayerCamera.x = gameObject.transform.position.x;
        VecPlayerCamera.y = gameObject.transform.position.y + 5f;
        VecPlayerCamera.z = gameObject.transform.position.z;

        VecPlayerLight.x = gameObject.transform.position.x;
        VecPlayerLight.y = gameObject.transform.position.y + 2.5f;
        VecPlayerLight.z = gameObject.transform.position.z;

        Camera.transform.position = VecPlayerCamera;
        Light.transform.position = VecPlayerLight;
    }

     void Update()
    {
        VecPlayerCamera.x = gameObject.transform.position.x;
        VecPlayerCamera.y = gameObject.transform.position.y + 5f;
        VecPlayerCamera.z = gameObject.transform.position.z;

        VecPlayerLight.x = gameObject.transform.position.x;
        VecPlayerLight.y = gameObject.transform.position.y + 2.5f;
        VecPlayerLight.z = gameObject.transform.position.z;

        Camera.transform.position = VecPlayerCamera;
        Light.transform.position = VecPlayerLight;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Clear")
        {
            SceneManager.LoadScene("Running");
        }
    }
}
