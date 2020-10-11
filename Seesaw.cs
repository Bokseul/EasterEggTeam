using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seesaw : MonoBehaviourPun, IPunObservable
{
    private float randTheta;

    private void Awake()
    {
        RandTheta();
    }
    void RandTheta()
    {
        randTheta = Random.Range(-0.1f, 0.2f);
    }

    void Update()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            transform.Rotate(0.0f, 0.0f, randTheta);
            randTheta += 0.1f * Time.deltaTime;
            if (randTheta >= 0.3f)
            {
                randTheta *= -1f;
            }
            if (randTheta <= -0.3f)
            {
                randTheta *= 1f;
            }
        }

    }
    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(randTheta);
        }
        else
        {
            randTheta = (float)stream.ReceiveNext();
        }
    }
}


