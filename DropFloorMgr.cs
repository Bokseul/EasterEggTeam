using UnityEngine;
//using Photon.Pun;
using System.Collections;

public class DropFloorMgr : MonoBehaviour/*Pun, IPunObservable*/
{
    public float FloorColorRand { get; set; }   // 바닥 색 관련 변수
    public float RandWait { get; set; }         // 코르틴 wait 기다릴값 담아주는 변수
    private Renderer ColorRend;
    WaitForSeconds NewWait = new WaitForSeconds(2f);
    GameObject ChildObject = null;

    private void Awake()
    {
        Puntest();
        //if (PhotonNetwork.IsMasterClient)
        //{
        //    FloorColorRand = Random.Range(110f, 256f);
        //    RandWait = Random.Range(10f, 20f);
        //}
    }

    public void Puntest()
    {
        FloorColorRand = 150f;
        RandWait = 11f;
    }
    
    //public void Puntest()
    //{
    //    FloorColorRand = Random.Range(110f, 256f);
    //    RandWait = Random.Range(10f, 20f);
    //}

    private void Start()
    {
        ColorRend = GetComponent<Renderer>();
    }
    
    public void OnEnableFunc()
    {
        StartCoroutine(DelayFloor());
    }

    IEnumerator DelayFloor()
    {
        ChildObject = gameObject.transform.GetChild(0).gameObject;
        while (ChildObject)
        {
            if (ChildObject.activeSelf)
            {
                yield return new WaitForSeconds(RandWait);
                ChildObject.GetComponentInChildren<Renderer>().material.color =
                    new Color(255 / 255, 255 / 255, 255 / 255);
                yield return NewWait;
                ChildObject.SetActive(false);
            }
            else if (!ChildObject.activeSelf)
            {
                yield return NewWait;
                ChildObject.SetActive(true);
                ChildObject.gameObject.GetComponentInChildren<Renderer>().material.color =
                    new Color(FloorColorRand / 255, 0 / 255, 0 / 255);
            }
        }
    }

    //public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    //{
    //    if (stream.IsWriting)
    //    {
    //        stream.SendNext(RandWait);
    //        stream.SendNext(FloorColorRand);
    //    }
    //    else
    //    {
    //        RandWait = (float)stream.ReceiveNext();
    //        FloorColorRand = (float)stream.ReceiveNext();
    //    }
    //}
}