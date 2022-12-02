using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    [Header("����ٴ� Target")]
    [SerializeField] public GameObject target;
    [Header("target ���� �Ÿ�")]
    [SerializeField] public float offsetY;
    [SerializeField] public float offsetZ;
    [Header("ī�޶� ��鸲 ���� �� �ð�")]
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
        /*//�ش�Ű�� ���� shake �ڷ�ƾ�Լ� ȣ��
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
    // amount�� ���⸦ ���ϰ�, duration ��鸮�� �ð��� �����Ѵ�
    public IEnumerator Shake()
    {
        float timer = 0;
        while (timer <= shakeTime)
        {
            //insideUnitSphere ���ȿ� ������ ��ǥ�� �ϳ� �޾ƿ´�
            transform.position += (Vector3)Random.insideUnitSphere * shakeAmount;

            timer += Time.deltaTime;
            yield return null;
        }
        transform.position = new Vector3(target.transform.position.x, target.transform.position.y + offsetY, target.transform.position.z + offsetZ);

    }
}

