using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextSceneBtn : MonoBehaviour
{
    //public GameObject btn;
    //void FixedUpdate()
    //{
    //    if (Input.GetMouseButton(0))
    //    {
    //        CastRay();
    //        if (btn == this.gameObject)
    //        {
    //            SceneManager.LoadScene(1);
    //        }
    //    }
    //}

    //void CastRay()
    //{
    //    btn = null;
    //    Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    //    RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero, 0f);

    //    if (hit.collider != null)
    //    {
    //        Debug.Log (hit.collider.name);
    //        btn = hit.collider.gameObject;
    //    }
    //}

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            SceneManager.LoadScene(1);
        }
    }
}
