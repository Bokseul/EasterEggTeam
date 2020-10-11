using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class punchR : MonoBehaviour
{
    private float m_punch;
    private float punch_time1;
    private bool coll_check;
    void Start()
    {
        //RectTransform rt = GetComponent<RectTransform>();
        //rt.DOAnchorPosY(0, 5).SetDelay(1.5f).SetEase(Ease.OutElastic); 
        punch_time1 = Random.Range(1f, 3f);
        StartCoroutine(Test()); //코루틴할떄는 이거로 코루틴 함수를 불러와야됨
    }


    private IEnumerator Test()
    {
        while (true)
        {
            yield return new WaitForSeconds(punch_time1);

            transform.DORotate(new Vector3(0, 0, -76), punch_time1).SetEase(Ease.OutBounce);

            yield return new WaitForSeconds(punch_time1+1f);
            transform.DORotate(new Vector3(0, 0, 10), punch_time1);
            yield return null;
        }
    }
}
