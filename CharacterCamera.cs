using System.Collections;
using UnityEngine;

public class CharacterCamera : MonoBehaviour
{
    public GameObject num3;
    public GameObject num2;
    public GameObject num1;
    public GameObject numGo;

    private GameObject target;
    private Transform cam;
    public bool countDown { get; private set; }

    private float SetCameraPosX = 0f;
    private float SetCameraPosY = 7f;
    private float SetCameraPosZ = 10f;

    private float CameraPosYMinLimit = -20f;
    private float CameraPosYMaxLimit = 80f;

    private float RotateSpeedX = 220f;
    private float RotateSpeedY = 110f;

    WaitForSeconds delayTime = new WaitForSeconds(1f);
    WaitForSeconds firstDelayTime = new WaitForSeconds(8f);

    private float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360)
            angle += 360;
        if (angle > 360)
            angle -= 360;
        return Mathf.Clamp(angle, min, max);
    }
    private void Start()
    {
        num1.SetActive(false);
        num2.SetActive(false);
        num3.SetActive(false);
        numGo.SetActive(false);

       // Cursor.lockState = CursorLockMode.Locked;
        Vector3 angle = transform.eulerAngles;
       
        if (!countDown)
        {
            StartCoroutine(CouroutinNum());
        }
    }

    void LateUpdate()
    {

        if (countDown)
        {

            Vector3 FixedPos = new Vector3(target.transform.position.x + SetCameraPosX,
            target.transform.position.y + SetCameraPosY,
            target.transform.position.z + SetCameraPosZ);

            transform.position = FixedPos;

            SetCameraPosY -= Input.GetAxis("Mouse Y") * RotateSpeedY * 0.02f;
            SetCameraPosX += Input.GetAxis("Mouse X") * RotateSpeedX * 0.02f;
            SetCameraPosY = ClampAngle(SetCameraPosY, CameraPosYMinLimit, CameraPosYMaxLimit);

            Quaternion rotation = Quaternion.Euler(SetCameraPosY, SetCameraPosX, 0);
            Vector3 position = rotation * new Vector3(0, 0, -SetCameraPosZ) + target.transform.position + new Vector3(0.0f, 0, 0.0f);
            transform.rotation = rotation;
            transform.position = position;

        }
    }
    IEnumerator CouroutinNum()
    {
        yield return firstDelayTime;
        num3.SetActive(true);
        yield return delayTime;
        num3.SetActive(false);
        yield return delayTime;
        num2.SetActive(true);
        yield return delayTime;
        num2.SetActive(false);
        yield return delayTime;
        num1.SetActive(true);
        yield return delayTime;
        num1.SetActive(false);
        yield return delayTime;
        numGo.SetActive(true);
        yield return delayTime;
        numGo.SetActive(false);

        countDown = true;
        yield break;
    }

    public void SetTarget(GameObject _target)
    {
        target = _target;
    }
}
