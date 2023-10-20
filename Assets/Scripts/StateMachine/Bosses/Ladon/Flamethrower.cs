using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flamethrower : MonoBehaviour
{
    public int damage;
    public GameObject spark;
    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player") || other.CompareTag("Enemy")){
            Instantiate(spark, other.transform.position, spark.transform.rotation);
        }
    }
    private void OnTriggerStay(Collider other) {
        if(other.CompareTag("Player") || other.CompareTag("Enemy")){
            other.GetComponent<LifeSystem>().ApplyDamage(damage);
            other.GetComponent<StateMachine>().ChangeTo("GHit");
        }
    }
}
