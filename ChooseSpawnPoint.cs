using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseSpawnPoint : MonoBehaviour
{
    public GameObject SpawnObject;  //스폰시킬 오브젝트
    public GameObject SpawnPos;     //스폰시킬 지역

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ball1")
        {
            SpawnObject.transform.position = SpawnPos.transform.position;
        }
        if (other.tag == "Ball2")
        {
            SpawnObject.transform.position = SpawnPos.transform.position;
        }
        if (other.tag == "Ball3")
        {
            SpawnObject.transform.position = SpawnPos.transform.position;
        }
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.transform.tag == "Ball")
    //    {
    //        SpawnObject.transform.position = SpawnPos.transform.position;
    //    }

    //}
}
