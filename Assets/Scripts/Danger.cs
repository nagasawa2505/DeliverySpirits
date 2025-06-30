using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Danger : MonoBehaviour
{
    public float dangerSpeed = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 10.0f);
    }

    // Update is called once per frame
    void Update()
    {
        // �Q�[���I����̏Փ˂������
        if (GameController.gameState == GameState.timeover)
        {
            GetComponent<BoxCollider>().enabled = false;
            Destroy(gameObject);
        }

        transform.position += transform.forward * dangerSpeed * Time.deltaTime;
    }
}
