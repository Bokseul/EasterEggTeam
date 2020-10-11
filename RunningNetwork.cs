using Photon.Pun;
using System.Collections;
using UnityEngine;

public class RunningNetwork : MonoBehaviourPun
{
    public GameObject floor;
    private GameObject Char;
    private int num;

    public Transform[] spawnPoints = new Transform[4];
        
    void Awake()
    {
        Vector3 spawn;
        if (PhotonNetwork.IsMasterClient)
        {
            spawn = spawnPoints[Random.Range(0, 4)].position;
            //spawn = new Vector3(floor.transform.position.x, floor.transform.position.y + 10, floor.transform.position.z);
        }
        else
        {
            spawn = spawnPoints[Random.Range(0, 4)].position;
            //num += 10;
            //spawn = new Vector3(floor.transform.position.x + num, floor.transform.position.y + 10, floor.transform.position.z);
        }
        Char = PhotonNetwork.Instantiate("Player", spawn, Quaternion.identity);
        // Char = Instantiate(Char, spawn, Quaternion.identity);
       Camera.main.GetComponent<CharacterCamera>().SetTarget(Char);
    }

        
}
