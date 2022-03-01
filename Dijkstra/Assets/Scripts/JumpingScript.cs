using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingScript : MonoBehaviour
{

    public GameObject target;
    public float launchForce = 10f;
    Rigidbody rb;
    Vector3 startPos;

    // Start is called before the first frame update
    void Start()
    {

        startPos = transform.position;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {

            FiringSolution fs = new FiringSolution();
            Nullable<Vector3> aimVector = fs.TimeToTarget(transform.position, target.transform.position, launchForce, Physics.gravity);


            if (aimVector.HasValue)
            {
                rb.AddForce(aimVector.Value.normalized * launchForce, ForceMode.VelocityChange);
            }
            else
            {
                Debug.Log("Error Occured! Launch sequence aborted!");
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            rb.isKinematic = true;
            transform.position = startPos;
            rb.isKinematic = false;
        }

        if(Input.mouseScrollDelta.y != 0)
        {
            launchForce += Input.mouseScrollDelta.y;
        }
    }
}
