using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Message : MonoBehaviour
{
    private float lifeTime = 4;
    public AudioSource source;
    public AudioClip clip;
    private void OnEnable() {
        StartCoroutine("Disappear");
    }
    IEnumerator Disappear(){
        source.PlayOneShot(clip);
        yield return new WaitForSeconds(lifeTime);
        gameObject.SetActive(false);
    }
}
