//using Photon.Pun;
using UnityEngine;

public class Wheel_Rotater : MonoBehaviour/*Pun, IPunObservable*/
{
    GameObject PutObj;

    private bool isCollChar;

    void Update()
    {
        if (isCollChar)
        {
            OrbitAround();
        }
    }

    private void OrbitAround()
    {
        transform.RotateAround(PutObj.transform.position, Vector3.down, -30f * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.transform.tag == "Wheel")
        {
            PutObj = collision.gameObject;
            isCollChar = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {

        if (collision.transform.tag == "Wheel")
        {
            PutObj = collision.gameObject;
            isCollChar = false;
        }
    }

    //public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    //{
    //    if (stream.IsWriting)
    //    {
    //        stream.SendNext(isCollChar);
    //    }
    //    else
    //    {
    //        isCollChar = (bool)stream.ReceiveNext();
    //    }
    //}
}