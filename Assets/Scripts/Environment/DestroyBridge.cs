using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBridge : MonoBehaviour
{
    public GameObject wall;
    public List<GameObject> bridges = new List<GameObject>();
    public ParticleSystem explosion;
    public AudioManager audioManager;
    bool blonwUp;
    
    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.CompareTag("Player") && !blonwUp){
            StartCoroutine("BlowUp");
        }
    }
    IEnumerator BlowUp(){
        wall.SetActive(true);
        blonwUp = true;
        foreach(GameObject bridge in bridges){
            audioManager.PlayAudioFromSource(0);
            Instantiate(explosion, bridge.transform.position, explosion.transform.rotation);
            bridge.SetActive(false);
            yield return new WaitForSeconds(0.2f);
        }
    }
}
