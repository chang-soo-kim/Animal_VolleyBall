using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shadow : MonoBehaviour
{
    [SerializeField] GameObject ball;
    
    private void Start()
    {
        transform.rotation = Quaternion.Euler(90, 0, 0);
        transform.position = new Vector3(ball.transform.position.x, 0.1f, ball.transform.position.z);
        transform.localScale = new Vector2(ball.transform.position.y * 0.4f, ball.transform.position.y * 0.4f);
    }

    void Update()
    {
        transform.position = new Vector3(ball.transform.position.x, 0.1f, ball.transform.position.z);
        transform.localScale = new Vector2(ball.transform.position.y * 0.4f, ball.transform.position.y * 0.4f);
    }
}
