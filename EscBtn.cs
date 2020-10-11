using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class EscBtn : MonoBehaviourPunCallbacks
{
    public Button ExitBtn;

    public override void OnLeftRoom()
    {
        SceneManager.LoadScene("Character");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
