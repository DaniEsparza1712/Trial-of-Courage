using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayerPlatform : MonoBehaviour
{
    public class TargetInfo{
        public GameObject targetGameObject;
        public Vector3 moveVector;
        public TargetInfo(GameObject gameObj, Vector3 vector){
            targetGameObject = gameObj;
            moveVector = vector;
        }
    }
    public Vector3 vel;
    public List<TargetInfo> targets = new();
    private void OnTriggerStay(Collider other) {
         if(other.CompareTag("Player")){
            Vector3 baseVector = other.GetComponent<PlayerMachine>().baseMoveVector;
            targets.Add(new TargetInfo(other.gameObject, baseVector));
            other.GetComponent<PlayerMachine>().baseMoveVector = vel;
        }   
    }
    private void OnTriggerExit(Collider other) {
        if(other.CompareTag("Player")){
            other.GetComponent<PlayerMachine>().baseMoveVector = Vector3.zero;
            targets.Remove(targets[0]);
        }
    }

    private void Update() {
        /*foreach(GameObject gameObject in targets){
            gameObject.transform.position += vel * Time.deltaTime;
        }*/
    }
}
