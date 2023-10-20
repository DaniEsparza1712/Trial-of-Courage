using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxButton : MonoBehaviour
{
    public GameObject box;
    private bool isActivated;
    public bool Activated => isActivated;
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject == box){
            isActivated = true;
        }
    }
    private void OnTriggerExit(Collider other) {
        if(other.gameObject == box){
            isActivated = false;
        }
    }
}
