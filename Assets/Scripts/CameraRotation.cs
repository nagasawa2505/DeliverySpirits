using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    // �}�E�X���x
    float mouseSensitivity = 2f;

    // �㉺�̌����͈̔�
    float minVerticalAngle = -20.0f;
    float maxVerticalAngle = 30.0f;

    // ���E�̌����͈̔�
    float minHorizontalAngle = -80f;
    float maxHorizontalAngle = 80f;

    // �v���C�J�n���̌���
    float verticalRotation = 0;
    float horizontalRotation = 0;

    // ���E�̊
    float initialY = 0;

    // Start is called before the first frame update
    void Start()
    {
        // �}�E�X�J�[�\������ʂ̒��S�ɌŒ�
        Cursor.lockState = CursorLockMode.Locked;
        
        // �J�[�\����\��
        Cursor.visible = false;

        // ���݂̌���
        Vector3 angles = transform.eulerAngles;
        initialY = angles.y;

        // �J�����̌�����������
        horizontalRotation = 0f;
        verticalRotation = angles.x;
    }

    // Update is called once per frame
    void Update()
    {
        // �}�E�X���͎擾
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        // ������
        horizontalRotation += mouseX;
        horizontalRotation = Mathf.Clamp(horizontalRotation, minHorizontalAngle,maxHorizontalAngle);

        // ��������Ƃ��̓}�C�i�X
        verticalRotation -= mouseY;
        verticalRotation = Mathf.Clamp(verticalRotation, minVerticalAngle, maxVerticalAngle);

        // ���E�̊�_���l��
        float yRotation = initialY + horizontalRotation;

        // �J�����̌��������肷��
        transform.rotation = Quaternion.Euler(verticalRotation, yRotation, 0);
    }
}
