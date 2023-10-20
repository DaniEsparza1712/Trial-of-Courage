using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushObjects : MonoBehaviour
{
    public float pushForce;
    private void OnControllerColliderHit(ControllerColliderHit hit) {
        if(hit.gameObject.CompareTag("Moveable")){
            Rigidbody rb = hit.gameObject.GetComponent<Rigidbody>();

            Vector3 direction = hit.point - transform.position;
            direction.y = 0;
            direction.Normalize();

            rb.AddForceAtPosition(direction * pushForce, transform.position, ForceMode.Force);
        }
    }
}
