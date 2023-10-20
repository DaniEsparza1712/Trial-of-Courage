using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public Transform target;
    public float speed;
    public bool carryPlayer;
    public bool CanGoUp => CheckIfCanGoUp();
    public void SetTarget(Transform transformTarget){
        target = transformTarget;
    }
    bool CheckIfCanGoUp(){
        if(!carryPlayer && transform.Find("Player") != null){
            return false;
        }
        else{
            return true;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position, target.position) >= 0.1f){
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
        }
    }
    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.CompareTag("Player") && gameObject.CompareTag("Sticky")){
            other.transform.SetParent(gameObject.transform);
        }
    }
    private void OnCollisionExit(Collision other) {
        if(other.gameObject.CompareTag("Player"))    {
            other.transform.SetParent(null);
        }
    }
}
