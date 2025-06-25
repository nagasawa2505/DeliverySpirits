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

    public float speedZ;
    public float accelerationZ;

    public float speedX;

    public float speedJump;
    public float gravity;

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
            if (Input.GetKeyDown(KeyCode.A))
            {
                MoveToLeft();
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                MoveToRight();
            }
            if (Input.GetKeyDown("space"))
            {
                Jump();
            }
        }

        // �O�i�x���V�e�B�̌v�Z
        // FPS�̓n�[�h���ɈقȂ�̂Ōo�ߎ��Ԃ��g���Ĉړ�����v�Z����
        // Clamp�Œl�͈̔͂�ݒ肷��
        float acceleratedZ = moveDirection.z + (accelerationZ * Time.deltaTime);
        moveDirection.z = Mathf.Clamp(accelerationZ, 0, speedZ);

        // ���ړ��x���V�e�B�̌v�Z
        float ratioX = (targetLane * LaneWidth - transform.position.x) / LaneWidth;
        moveDirection.x = ratioX * speedX;

        // �d�͕��̗͂𖈃t���[���ǉ�
        moveDirection.y -= gravity * Time.deltaTime;

        // �ړ����s
        // transform��Rotation���l�����Ĉړ���̍��W��ϊ�����
        //Vector3 globalDirection = transform.TransformDirection(moveDirection);
        //controller.Move(globalDirection * Time.deltaTime);

        // �ړ����s
        // ����̂悤�Ɏ�̂���]���Ȃ��ꍇ�͂���ł���
        controller.Move(moveDirection * Time.deltaTime);

        if (controller.isGrounded)
        {
            moveDirection.y = 0;
        }

        //animator.SetBool("run", moveDirection.z > 0.0f);
    }

    // ���[���ԍ��ύX
    public void MoveToLeft()
    {
        if (targetLane > MinLane)
        {
            targetLane--;
        }
    }

    // ���[���ԍ��ύX
    public void MoveToRight()
    {
        if (targetLane < MaxLane)
        {
            targetLane++;
        }
    }

    // �ړ���Y���W�ύX
    public void Jump()
    {
        moveDirection.y = speedJump;

        //animator.SetTrigger("Jump");
    }
}
