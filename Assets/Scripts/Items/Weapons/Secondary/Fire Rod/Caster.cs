using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caster : MonoBehaviour
{
    public AudioManager audioManager;
    public ParticleSystem explosion;
    public float explosionRadius;
    public ItemData itemData;
    public float speed;
    public float lifeTime;
    private float time;
    private void Start() {
        audioManager.PlayAudioFromSource(0);
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if(time >= lifeTime){
            Detonate();
        }
        transform.position += transform.forward * speed * Time.deltaTime;
    }
    private void OnTriggerEnter(Collider other) {
        if(!other.CompareTag("Player"))
            Detonate();
    }
    public void Detonate(){
        audioManager.PlayAudioAtPoint(1);
        Instantiate(explosion, transform.position, explosion.transform.rotation);
        Collider[] collisions = Physics.OverlapSphere(transform.position, explosionRadius);
        if(collisions.Length > 0){
            foreach(Collider collider in collisions){
                if(collider.CompareTag("Enemy")){
                    collider.gameObject.GetComponent<LifeSystem>().ApplyDamage(itemData.value);
                    collider.gameObject.GetComponent<StateMachine>().ChangeTo("GHit");
                }
                else if(collider.CompareTag("Ice")){
                    Destroy(collider.gameObject);
                }
            }
        }
        Destroy(gameObject);
    }
}
