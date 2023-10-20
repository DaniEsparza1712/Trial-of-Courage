using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    public ParticleSystem splash;
    private void OnTriggerEnter(Collider other) {
        Vector3 spawnPos = other.transform.position;
        spawnPos.y = transform.position.y;
        Instantiate(splash, spawnPos, splash.transform.rotation);
    }    
}
