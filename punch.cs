using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class punch : MonoBehaviour, IPunObservable
{
    private float m_punch;
    private float punch_time;
    private bool coll_check;
    private bool coll_time;

    void Start()
    {
        //RectTransform rt = GetComponent<RectTransform>();
        //rt.DOAnchorPosY(0, 5).SetDelay(1.5f).SetEase(Ease.OutElastic); 
        punch_time = Random.Range(1f, 3f);
        StartCoroutine(Test()); //코루틴할떄는 이거로 코루틴 함수를 불러와야됨
    }


    private IEnumerator Test()
    {
        while (true)
        {
            yield return new WaitForSeconds(punch_time);
            
            transform.DORotate(new Vector3(0, 0, 76), punch_time).SetEase(Ease.OutBounce);

            yield return new WaitForSeconds(punch_time+1f);
            transform.DORotate(new Vector3(0, 0, -10), punch_time);
            yield return null;
        }
    }
    private void Update()
    {
    }
   
    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if(stream.IsWriting)
        {
            stream.SendNext(punch_time);
            ChangePunchTime(punch_time);
        }
        else
        {
            punch_time = (float)stream.ReceiveNext();
            ChangePunchTime(punch_time);
        }
    }

    void ChangePunchTime(float nextPunch_time)
    {
        if (punch_time == nextPunch_time)
            return;
        else
        {
            StopCoroutine(Test());

            punch_time = nextPunch_time;

            StartCoroutine(Test());
        }
    }
}
