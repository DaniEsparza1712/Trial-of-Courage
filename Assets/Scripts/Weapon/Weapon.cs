using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public ParticleSystem hitSpark;
    public AudioManager audioManager;
    public int audioInt;
    public int damage;
    public float invincibleTime;
    public string targetTag;
    public bool interacts;
    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag(targetTag)){
            if(!other.GetComponent<StateMachine>().GetInvincible){
                audioManager.PlayAudioAtPoint(audioInt);
                Vector3 sparkDir = (transform.position - other.transform.position).normalized;
                Vector3 sparkPos = transform.position + sparkDir * 0.5f;
                Instantiate(hitSpark, other.transform.position, transform.rotation);
                other.GetComponent<LifeSystem>().ApplyDamage(damage);
                StateMachine sm = other.GetComponent<StateMachine>();
                sm.ChangeTo("GHit");
                sm.ChangeInvincible(1);
                sm.StartCoroutine(sm.WaitForChangeInvincible(invincibleTime, 2));
            }
        }
        else if(other.CompareTag("Hittable")){
            Debug.Log("Hit");
        }
        else if(interacts && other.CompareTag("Diamond")){
            other.GetComponent<Diamond>().CheckAnswer();
        }
        else if(interacts && other.gameObject.CompareTag("Ladon")){
            audioManager.PlayAudioAtPoint(audioInt);
            Vector3 sparkDir = (transform.position - other.transform.position).normalized;
            Vector3 sparkPos = transform.position + sparkDir * 0.5f;
            Instantiate(hitSpark, sparkPos, transform.rotation);
            LadonMachine ladon = other.gameObject.GetComponent<LadonMachine>();
            ladon.ChangeTo("GHit");
            if(ladon.hittable){
                ladon.lifeSystem.ApplyDamage(damage);
                ladon.StartCoroutine(ladon.WaitForChangeInvincible(0.8f, 2));
            }
        }
        else if(interacts && other.CompareTag("Destroyable"))
        {
            Vector3 sparkPos = other.transform.position;
            Instantiate(hitSpark, sparkPos, transform.rotation);
            if(damage > 0)
                Destroy(other.gameObject);
        }
        else if(interacts && other.CompareTag("Interactable"))
        {
            Vector3 sparkPos = other.transform.position;
            Instantiate(hitSpark, sparkPos, transform.rotation);
            other.GetComponent<Interactable>().Action();
        }
    }
}
