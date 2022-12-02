using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{

    Rigidbody rg;
    CapsuleCollider capsule;
    Animator animator;

    Vector3 Dir;
    Vector3 CheckSpherePos;
    float inputX;
    float inputZ;

    [SerializeField]
    float Speed = 8f;

    [SerializeField]
    float jumppower = 5f;

    [SerializeField] bool isground = false;
    bool isMove = false;
    float CheckSpherePosY;

    int GroundedLayer;

    [SerializeField] FollowCam fc;

    enum PlayerSwap
    {
        Player1,
        Player2
    }

    [SerializeField]
    PlayerSwap playerSwap;

    void Start()
    {
        rg = GetComponent<Rigidbody>();
        capsule = GetComponent<CapsuleCollider>();
        animator = GetComponent<Animator>();
        GroundedLayer = 1 << LayerMask.NameToLayer("Water");
        CheckSpherePos = new Vector3(0, -0.1f, 0);
    }



    void Update()
    {


        isground = Physics.CheckSphere(transform.position, 0.1f, 1<<LayerMask.NameToLayer("Default")) == true ? true : false;

        animator.SetBool("ground", isground);

        if (Input.GetKeyDown(KeyCode.N) && isground && playerSwap == PlayerSwap.Player1)
            playerJump();
        else if (Input.GetKeyDown(KeyCode.Keypad0) && isground && playerSwap == PlayerSwap.Player2)
            playerJump();

        if (Input.GetKeyDown(KeyCode.M) && playerSwap == PlayerSwap.Player1)
        {
            if (!isground)
            {
                spike();
            }
            else if (isground)
            {
                Dash();
            }
        }
        else if (Input.GetKeyDown(KeyCode.Keypad1) && playerSwap == PlayerSwap.Player2)
        {
            if (!isground)
            {
                spike();
            }
            else if (isground)
            {
                Dash();
            }
        }

    }

    private void OnDrawGizmos()
    {


        Gizmos.DrawSphere(transform.position, 0.1f);
    }

    private void FixedUpdate()
    {

        playerMove();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            collision.gameObject.GetComponent<Rigidbody>().AddForce((transform.forward + Vector3.up).normalized * 5f, ForceMode.Impulse);
        }
    }

    void playerMove()
    {

        if (playerSwap == PlayerSwap.Player1)
        {
        inputX = Input.GetAxis("Horizontal");
        inputZ = Input.GetAxis("Vertical");
        }

        else if(playerSwap == PlayerSwap.Player2)
        {
        inputX = -Input.GetAxis("Horizontal2P");
        inputZ = -Input.GetAxis("Vertical2P");
        }


        //�ٻ�ġ�� ã����
        isMove = !Mathf.Approximately(inputX, 0f) || !Mathf.Approximately(inputZ, 0f);
        animator.SetBool("Walk", isMove);
        Dir = new Vector3(inputX, 0f, inputZ).normalized;
        if (isMove)
        {
            rg.velocity += Speed * Time.deltaTime * Dir;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Dir), 3f * Time.deltaTime);
        }
        //�ӵ��� ũ��
        if (rg.velocity.magnitude > 10f)
        {
            //����� ���͸� ũ�Ⱑ �����Ǿ��ִ� maxLength�� �����Ѵ�.
            rg.velocity = Vector3.ClampMagnitude(rg.velocity, 10f);
        }
    }

    void playerJump()
    {
        animator.SetTrigger("Jump");
        rg.AddForce(Vector3.up * jumppower, ForceMode.Impulse);
    }
    void spike()
    {
        StartCoroutine(fc.Shake());
        animator.SetTrigger("Spike");

    }
    void Dash()
    {
        animator.SetTrigger("Dash");
        rg.AddForce(Dir * jumppower, ForceMode.Impulse);

    }
}
