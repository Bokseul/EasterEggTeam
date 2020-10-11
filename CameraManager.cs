using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Camera Main;         //메인카메라(캐릭터 따라가는 카메라)
    public Camera Surve;        //서브카메라(서브로 움직이는 카메라)
    public GameObject PosOne;   //카메라목표지점
    public GameObject PosTwo;   //카메라 두번째 목표지점
    private float Timer;        //타이머 저장할 변수
    public float DelayTime = 1f;    //증가할 시간 기준 (= ++과 같은 역할)
    public float ChangeTime = 6f;  //카메라 on/off 언제될지 기준시간
    private float CameraSpeed = 1f;

    void Update()
    {
        Timer += DelayTime * Time.deltaTime;    //타이머에 딜레이 시간을 쌓는다
        if (Timer <= 3f)    //기준시간보다 미달일 경우는
        {
            Main.enabled = false;   //메인 카메라는 끄고
            Surve.enabled = true;   //서브 카메라는 킨다
            Surve.transform.localPosition = Vector3.Lerp(Surve.transform.localPosition, PosOne.transform.localPosition, Time.deltaTime * CameraSpeed);
            //서브 카메라의 로컬위치는        =         (서브카메라로 부터.                카메라 목표지점까지 델타타임만큼 이동을 한다.)
        }
        else if (Timer <= ChangeTime)
        {
            Surve.transform.localPosition = Vector3.Lerp(Surve.transform.localPosition, PosTwo.transform.localPosition, Time.deltaTime * CameraSpeed);
            Surve.transform.localRotation = Quaternion.Lerp(Surve.transform.localRotation, PosTwo.transform.localRotation, Time.deltaTime * CameraSpeed);
        }
        else//
        {
            Main.enabled = true;
            Surve.enabled = false;
        }
    }

    //public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    //{
    //    if (stream.IsWriting)
    //    {
    //        stream.SendNext(Main.enabled);
    //        stream.SendNext(Surve.enabled);
    //        stream.SendNext(Surve.transform.position);
    //        stream.SendNext(Surve.transform.rotation);
    //    }
    //    else
    //    {
    //        Main.enabled = (bool)stream.ReceiveNext();
    //        Surve.enabled = (bool)stream.ReceiveNext();
    //        Surve.transform.position = (Vector3)stream.ReceiveNext();
    //        Surve.transform.rotation = (Quaternion)stream.ReceiveNext();
    //    }
    //}
}
