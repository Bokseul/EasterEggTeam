using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public enum PLAYER_STATE_MINI
{
    STRETCHING,
    MOVE,
    JUMP,
    FALL,
    VICTORY,
    END
}


public class MiniGamePlayer : MonoBehaviour
{
    public string moveAxisName = "Vertical";
    public string rotateAxisName = "Horizontal";
    public string jumpAxisName = "Jump";

    public float move { get; private set; }
    public float rotate { get; private set; }
    public bool jump { get; set; }

    CharacterCamera chCamera;

    private bool IsJump;

    [SerializeField]
    PLAYER_STATE_MINI state = PLAYER_STATE_MINI.STRETCHING;

    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        chCamera = GameObject.Find("MainCamera").GetComponent<CharacterCamera>();
    }

    void Update()
    {
        
            if (GameManager.instance != null && GameManager.instance.isGameover)
            {
                move = 0;
                rotate = 0;
                jump = false;
                IsJump = false;
                return;
            }
            if (Input.GetButtonDown(jumpAxisName) && !IsJump)
            {
                jump = true;
                IsJump = true;
                ChangeState(PLAYER_STATE_MINI.JUMP);
            }

            move = Input.GetAxis(moveAxisName);
            rotate = Input.GetAxis(rotateAxisName);

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Ground")
        {
            jump = false;
            IsJump = false;
            ChangeState(PLAYER_STATE_MINI.MOVE);
        }
        else if (collision.transform.tag == "Wheel")
        {
            jump = false;
            IsJump = false;
            ChangeState(PLAYER_STATE_MINI.MOVE);
        }
        if (collision.transform.tag == "Win")
        {
            ChangeState(PLAYER_STATE_MINI.VICTORY);
            StartCoroutine(CoroutineChangeVictory());
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Fall")
        {
            ChangeState(PLAYER_STATE_MINI.FALL);
        }
    }

    void ChangeState(PLAYER_STATE_MINI nextState)
    {
        state = nextState;

        anim.SetBool("isJump", false);
        anim.SetBool("isStretch", false);
        anim.SetBool("isFall", false);
        anim.SetBool("isVictory", false);
        anim.SetBool("isMove", false);

        StopAllCoroutines();

        switch (state)
        {
            case PLAYER_STATE_MINI.STRETCHING:
                StartCoroutine(CoroutineStretch());
                break;
            case PLAYER_STATE_MINI.MOVE:
                StartCoroutine(CoroutineMove());
                break;
            case PLAYER_STATE_MINI.JUMP:
                StartCoroutine(CoroutineJump());
                break;
            case PLAYER_STATE_MINI.FALL:
                StartCoroutine(CoroutineFall());
                break;
            case PLAYER_STATE_MINI.VICTORY:
                StartCoroutine(CoroutineVictory());
                break;
        }
    }

    IEnumerator CoroutineChangeVictory()
    {
        while (true)
        {
            yield return new WaitForSeconds(8f);
            SceneManager.LoadScene("Victory");
            yield break;
        }
    }
    IEnumerator CoroutineStretch()
    {
        anim.SetBool("isStretch", true);

        while (true)
        {
            yield return new WaitForSeconds(2f);
            ChangeState(PLAYER_STATE_MINI.MOVE);
            yield break;
        }
        yield break;
    }
    IEnumerator CoroutineMove()
    {
        anim.SetBool("isMove", true);
        yield break;
    }
    IEnumerator CoroutineJump()
    {
        anim.SetBool("isJump", true);
        yield break;
    }
    IEnumerator CoroutineFall()
    {
        anim.SetBool("isFall", true);
        yield break;
    }
    IEnumerator CoroutineVictory()
    {
        anim.SetBool("isVictory", true);
        yield break;
    }

}
