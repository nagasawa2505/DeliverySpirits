using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public static int boxNum;

    public GameObject[] boxPrefabs;
    float shootSpeed = 100f; // ������Ƃ��̐��������̗�
    float upSpeed = 80f; // ������Ƃ��̏�����̗�
    bool startShoot; // ��������OK��
    bool switching;

    Camera cam;
    Transform player;

    public static int[] shootCounts = { 0, 0, 0 };

    // Start is called before the first frame update
    void Start()
    {
        // ���C���J�����^�O���t���Ă�΂���ł�����
        cam = Camera.main;

        player = GameObject.FindGameObjectWithTag("Player").transform;

        Invoke("ShootEnabled", 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameController.gameState != GameState.playing)
        {
            return;
        }

        // ���N���b�N
        if (startShoot && Input.GetMouseButton(0))
        {
            Shoot();
        }

        // �E�N���b�N
        if (!switching && Input.GetMouseButton(1))
        {
            switching = true;

            // �����锠�̐؂�ւ�
            boxNum++;
            if (boxNum == boxPrefabs.Length)
            {
                boxNum = 0;
            }

            Invoke("UnsetSwitching", 0.2f);
        }
    }

    void ShootEnabled()
    {
        startShoot = true;
    }

    void UnsetSwitching()
    {
        switching = false;
    }

    void Shoot()
    {
        if (player == null)
        {
            return;
        }

        startShoot = false;

        GameObject box = Instantiate(boxPrefabs[boxNum], player.position, Quaternion.identity);
        Rigidbody rbody = box.GetComponent<Rigidbody>();

        // cam.transform.forward�̓J�����������Ă����
        // Y������+�ɂ��邱�Ƃŕ������ɂȂ�
        rbody.AddForce(new Vector3(
            cam.transform.forward.x * shootSpeed,
            cam.transform.forward.y + upSpeed,
            cam.transform.forward.z * shootSpeed), ForceMode.Impulse);

        shootCounts[boxNum]++;

        Invoke("ShootEnabled", 1f);
    }
}
