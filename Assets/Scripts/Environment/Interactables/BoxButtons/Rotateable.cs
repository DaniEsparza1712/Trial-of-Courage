using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotateable : MonoBehaviour
{
    Rigidbody rb;
    public Transform centerOfMass;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass =  transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddTorque(Vector3.up);
    }
}
