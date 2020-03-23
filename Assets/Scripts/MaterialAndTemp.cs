using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialAndTemp : MonoBehaviour
{
    // Start is called before the first frame update
    [Range(25, 40)]
    public int temp;
    [Range(80, 255)]
    public int mat;

    private Vector3 InitPos;
    private Quaternion InitRot;
    private new Rigidbody rigidbody;


    private void Start()
    {
        InitPos = transform.position;
        InitRot = transform.rotation;
        rigidbody = GetComponent<Rigidbody>();

    }

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            rigidbody.isKinematic = true;
            rigidbody.useGravity = false;
            rigidbody.velocity = new Vector3(0, 0, 0);
            Invoke("ResetObject", 1f);
        }
    }

    private void ResetObject()
    {
        transform.SetPositionAndRotation(InitPos, InitRot);
        rigidbody.isKinematic = false;
        rigidbody.useGravity = true;
    }
}
