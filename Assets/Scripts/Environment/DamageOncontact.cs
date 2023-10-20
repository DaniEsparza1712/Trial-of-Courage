using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOncontact : MonoBehaviour
{
    public string targetTag;
    public float invincibleTime;
    public int damage;
    private void OnTriggerStay(Collider other) {
        if(other.CompareTag(targetTag)){
            if(!other.GetComponent<StateMachine>().GetInvincible){
                other.GetComponent<LifeSystem>().ApplyDamage(damage);
                StateMachine sm = other.GetComponent<StateMachine>();
                sm.ChangeTo("GHit");
                sm.ChangeInvincible(1);
                sm.StartCoroutine(sm.WaitForChangeInvincible(invincibleTime, 2));
            }
        }
    }
}
