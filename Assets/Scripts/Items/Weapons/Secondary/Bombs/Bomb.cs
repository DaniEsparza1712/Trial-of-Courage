using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public AudioManager audioManager;
    public float lifeTime;
    public ParticleSystem explosion;
    public float explosionRadius;
    public ItemData itemData;
    // Start is called before the first frame update
    void Start()
    {
        SpawnManager.spawnManager.AddBomb(1);
        StartCoroutine("bombCoroutine", lifeTime);
    }

    public IEnumerator bombCoroutine(float seconds){
        yield return new WaitForSeconds(seconds);
        Detonate();
    }
    public void Detonate(){
        audioManager.PlayAudioAtPoint(0);
        SpawnManager.spawnManager.AddBomb(-1);
        Instantiate(explosion, transform.position, explosion.transform.rotation);
        Collider[] collisions = Physics.OverlapSphere(transform.position, explosionRadius);
        if(collisions.Length > 0){
            foreach(Collider collider in collisions){
                if(collider.CompareTag("Player") || collider.CompareTag("Enemy")){
                    if(collider.CompareTag("Player"))
                        collider.gameObject.GetComponent<LifeSystem>().ApplyDamage(itemData.value * 2);
                    else
                        collider.gameObject.GetComponent<LifeSystem>().ApplyDamage(itemData.value);
                    collider.gameObject.GetComponent<StateMachine>().ChangeTo("GHit");
                }
                else if(collider.gameObject.CompareTag("Diamond")){
                    collider.gameObject.GetComponent<Diamond>().CheckAnswer();
                }
                else if(collider.gameObject.CompareTag("Ladon")){
                    collider.gameObject.GetComponent<LadonMachine>().ChangeTo("Stun");
                }
            }
        }
        Destroy(gameObject);
    }
    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.CompareTag("Sticky")){
            gameObject.transform.SetParent(other.gameObject.transform);
        }
    }
}
