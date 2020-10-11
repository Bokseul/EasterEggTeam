using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum FLOORSTATE
{
    FadeIn,
    FadeOut
}
public class FadeOut : MonoBehaviour
{
    public bool isCollPlayer;   // 안빠지는 발판 충돌 체크
    public bool isTrigPlayer;   // 빠지는 발판 충돌 체크

    private FLOORSTATE floorstate = FLOORSTATE.FadeIn;
    private Renderer rend;
    private BoxCollider boxcoll;

    public ParticleSystem effect;

    WaitForSeconds wainfor2sec = new WaitForSeconds(2f);    //세컨드 함수 캐싱
    WaitForSeconds wainfor4sec = new WaitForSeconds(4f);

    void Start()
    {
        effect.transform.position = transform.position;
        rend = GetComponent<Renderer>();
        ChangeRend(FLOORSTATE.FadeIn);
    }
    void Update()
    {
        if (isTrigPlayer)
        {
            ChangeRend(FLOORSTATE.FadeOut);
        }
        else if (!isTrigPlayer)
        {
            ChangeRend(FLOORSTATE.FadeIn);
        }
        if (isCollPlayer)
        {
            effect.Play(true);
        }
    }
    IEnumerator CoruFadeInFloor()
    {
        while (true)
        {
            yield return wainfor4sec;
            rend.enabled = true;
            yield break ;
        }
    }
    IEnumerator CoruFadeOutFloor()
    {
        while (true)
        {
            yield return wainfor2sec;
            rend.enabled = false;
            yield break;
        }
    }
    void ChangeRend(FLOORSTATE howstate)
    {
        floorstate = howstate;

        StopAllCoroutines();

        switch(floorstate)
        {
            case FLOORSTATE.FadeIn:
                StartCoroutine(CoruFadeInFloor());
                break;
            case FLOORSTATE.FadeOut:
                StartCoroutine(CoruFadeOutFloor());
                break;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Player")
        {
            isCollPlayer = true;
        }

    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            isTrigPlayer = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            isTrigPlayer = true;
        }
    }
}
