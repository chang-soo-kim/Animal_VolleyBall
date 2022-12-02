using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    [Header("따라다닐 Target")]
    [SerializeField] public GameObject target;
    [Header("target 과의 거리")]
    [SerializeField] public float offsetY;
    [SerializeField] public float offsetZ;
    [Header("카메라 흔들림 세기 및 시간")]
    [SerializeField] public float shakeAmount = 0.05f;
    [SerializeField] public float shakeTime = 0.1f;


    public enum type
    {
        Player1,
        Player2,
    }
    public type myType;
    void Update()
    {
        /*//해당키를 눌면 shake 코루틴함수 호출
        if (Input.GetKeyDown(KeyCode.LeftShift) && myType == type.Player1)
        {
            Debug.Log("LeftShift");
            StartCoroutine(Shake());
        }
        else if (Input.GetKeyDown(KeyCode.RightShift) && myType == type.Player2)
        {
            Debug.Log("RightShift");
            StartCoroutine(Shake());
        }*/
        transform.position = new Vector3(target.transform.position.x, target.transform.position.y + offsetY, target.transform.position.z + offsetZ);
    }
    // amount로 세기를 정하고, duration 흔들리는 시간을 지정한다
    public IEnumerator Shake()
    {
        float timer = 0;
        while (timer <= shakeTime)
        {
            //insideUnitSphere 구안에 랜덤한 좌표를 하나 받아온다
            transform.position += (Vector3)Random.insideUnitSphere * shakeAmount;

            timer += Time.deltaTime;
            yield return null;
        }
        transform.position = new Vector3(target.transform.position.x, target.transform.position.y + offsetY, target.transform.position.z + offsetZ);

    }
}

