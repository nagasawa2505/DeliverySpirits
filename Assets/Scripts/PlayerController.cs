using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public const int MinLane = -1;
    public const int MaxLane = 1;
    public const float LaneWidth = 3.0f;

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
        if (controller.isGrounded && GameController.gameState == GameState.playing)
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

        // 前進ベロシティの計算
        // FPSはハード毎に異なるので経過時間を使って移動先を計算する
        // Clampで値の範囲を設定する
        float acceleratedZ = moveDirection.z + (accelerationZ * Time.deltaTime);
        moveDirection.z = Mathf.Clamp(accelerationZ, 0, speedZ);

        // 横移動ベロシティの計算
        float ratioX = (targetLane * LaneWidth - transform.position.x) / LaneWidth;
        moveDirection.x = ratioX * speedX;

        // 重力分の力を毎フレーム追加
        moveDirection.y -= gravity * Time.deltaTime;

        // 移動実行
        // transformのRotationを考慮して移動先の座標を変換する
        //Vector3 globalDirection = transform.TransformDirection(moveDirection);
        //controller.Move(globalDirection * Time.deltaTime);

        // 移動実行
        // 今回のように主体が回転しない場合はこれでいい
        controller.Move(moveDirection * Time.deltaTime);

        if (controller.isGrounded)
        {
            moveDirection.y = 0;
        }

        //animator.SetBool("run", moveDirection.z > 0.0f);
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag("Danger"))
        {
            controller.Move(new Vector3(0, 5, 0));
            controller.transform.Rotate(Random.Range(-45, 45), Random.Range(-45, 45), Random.Range(-45, 45));
            GameController.gameState = GameState.gameover;
            Destroy(gameObject, 3.0f);
        }
    }

    // レーン番号変更
    public void MoveToLeft()
    {
        if (targetLane > MinLane)
        {
            targetLane--;
        }
    }

    // レーン番号変更
    public void MoveToRight()
    {
        if (targetLane < MaxLane)
        {
            targetLane++;
        }
    }

    // 移動先Y座標変更
    public void Jump()
    {
        moveDirection.y = speedJump;

        //animator.SetTrigger("Jump");
    }
}
