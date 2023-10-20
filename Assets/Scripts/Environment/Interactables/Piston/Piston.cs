using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piston : MonoBehaviour
{
    private bool activated;
    public bool GetActivated => activated;
    public bool hitted;
    public Transform targetPos;
    private Collider pistonCollider;
    private void Start() {
        pistonCollider = GetComponent<Collider>();
    }
    public void SetActivated(){
        hitted = false;
        pistonCollider.enabled = false;
        transform.localScale = new Vector3(1, 0.1f, 1);
        activated = true;
    }
    public void SetDeactivated(){
        hitted = false;
        pistonCollider.enabled = true;
        transform.localScale = new Vector3(1, 1, 1);
        activated = false;
    }
}
