using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class PlayerSpawn : MonoBehaviourPun
{
    public GameObject character;

    public GameObject startPos;
    private GameObject char1;
    private GameObject char2;


    void Start()
    {
    //    Vector3 spawn;
    //    if (PhotonNetwork.IsMasterClient)
    //    {
    //        spawn = new Vector3(transform.localPosition.x, transform.localPosition.y + 10, transform.localPosition.z);
    //    }
    //    else
    //    {
    //        spawn = new Vector3(transform.localPosition.x + 10, transform.localPosition.y + 10, transform.localPosition.z);
    //    }

    //    PhotonNetwork.Instantiate("player2",spawn, Quaternion.identity);
    //    //char1 = Instantiate(character, spawn, Quaternion.identity);
    //    //Camera.main.GetComponent<CharacterCamera>().SetTarget(char1);
    }
    
}
