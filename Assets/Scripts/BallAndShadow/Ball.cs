using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] GameObject shadowNear;
    [SerializeField] GameObject shadowFar;
    SpriteRenderer farSprite = null;
    SpriteRenderer nearSprite = null;
    [SerializeField] Transform myplayer;

    bool isFar = false;

    private void Start()
    {
        farSprite = shadowFar.GetComponent<SpriteRenderer>();
        nearSprite = shadowNear.GetComponent<SpriteRenderer>();
        farSprite.transform.rotation = Quaternion.Euler(90f, 0f, 0f);
        nearSprite.transform.rotation = Quaternion.Euler(90f, 0f, 0f);
    
    }

    void Update()
    {
        if (transform.position.y <= 3)
        {
            isFar = false;
            nearSprite.enabled = true;
            farSprite.enabled = false;

        }
        else
        {
            isFar = true;
            nearSprite.enabled = false;
            farSprite.enabled = true;
        }
        if (isFar)
        {
            shadowFar.transform.position = new Vector3(transform.position.x, 0.1f, transform.position.z);
            shadowFar.transform.localScale = new Vector2(transform.position.y * 0.4f, transform.position.y * 0.4f);
        }
        else
        {
            shadowNear.transform.position = new Vector3(transform.position.x, 0.1f, transform.position.z);
            shadowNear.transform.localScale = new Vector2(transform.position.y * 0.4f, transform.position.y * 0.4f);
        }
    }
}