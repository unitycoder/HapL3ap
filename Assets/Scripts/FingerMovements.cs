using System;
using System.Collections.Generic;
using UnityEngine;

public class FingerMovements : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform FingerTop;
    public Transform FingerMid, FingerEnd;
    private float rotationDegree = 0.70f;
    void Start()
    {
        FingerTop = GetComponent<Transform>();


    }

    // Update is called once per frame
    void Update()
    {
        float rot = rotationDegree * GetData.fingerValue;
        FingerEnd.transform.localEulerAngles = new Vector3(rot, 0, 0);
        FingerMid.transform.localEulerAngles = new Vector3(rot, 0, 0);
        FingerTop.transform.localEulerAngles = new Vector3(rot, 0, 0);

    }
}
