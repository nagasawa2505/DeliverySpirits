using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    public float deleteTime;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, deleteTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        // �d�͂��p���I�ɒǉ�
       GetComponent<Rigidbody>().AddForce(Physics.gravity, ForceMode.Acceleration);
    }
}
