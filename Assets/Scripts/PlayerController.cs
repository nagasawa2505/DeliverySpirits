using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    const int MinLane = -2;
    const int MaxLane = 2;
    const float LaneWidth = 1.0f;

    CharacterController controller;
    //Animator animator;

    Vector3 moveDirection = Vector3.zero;
    int targetLane;

    public float gravity;
    public float speedZ;
    public float speedX;
    public float speedJump;
    public float accelerationZ;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        //animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (controller.isGrounded)
        {
            if (Input.GetKeyDown("left"))
            {
                MoveToLeft();
            }
            if (Input.GetKeyDown("right"))
            {
                MoveToRight();
            }
            if (Input.GetKeyDown("space"))
            {
                Jump();
            }
        }

        // 前進ベロシティの計算
        float acceleratedZ = moveDirection.z + (accelerationZ * Time.deltaTime);
        moveDirection.z = Mathf.Clamp(accelerationZ, 0, speedZ);

        // 横移動ベロシティの計算
        float ratioX = (targetLane * LaneWidth - transform.position.x) / LaneWidth;
        moveDirection.x = ratioX * speedX;

        // 重力分の力を毎フレーム追加
        moveDirection.y -= gravity * Time.deltaTime;

        // 移動実行
        Vector3 globalDirection = transform.TransformDirection(moveDirection);
        controller.Move(globalDirection * Time.deltaTime);

        if (controller.isGrounded)
        {
            moveDirection.y = 0;
        }

        //animator.SetBool("run", moveDirection.z > 0.0f);
    }

    public void MoveToLeft()
    {
        if (targetLane > MinLane)
        {
            targetLane--;
        }
    }

    public void MoveToRight()
    {
        if (targetLane < MaxLane)
        {
            targetLane++;
        }
    }

    public void Jump()
    {
        moveDirection.y = speedJump;

        //animator.SetTrigger("Jump");
    }
}
