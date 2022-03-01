using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    public GameObject MovingObject;
    public float MoveSpeed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            MovingObject.transform.position += Vector3.forward * Time.deltaTime * MoveSpeed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            MovingObject.transform.position += -Vector3.forward * Time.deltaTime* MoveSpeed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            MovingObject.transform.position += Vector3.right * Time.deltaTime * MoveSpeed;

        }
        if (Input.GetKey(KeyCode.A))
        {
            MovingObject.transform.position += -Vector3.right * Time.deltaTime * MoveSpeed;
        }
    }
}
