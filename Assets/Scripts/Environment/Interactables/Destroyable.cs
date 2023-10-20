using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Destroyable : MonoBehaviour
{
    public ParticleSystem destroyParticles;
    public GameObject item;
    public UnityEvent destroyEvent;
    private bool appActive = true;
    private void OnApplicationQuit()
    {
        appActive = false;
    }

    private void OnDestroy()
    {
        if(appActive)
            destroyEvent.Invoke();
    }

    public void DestroyParticles()
    {
        Instantiate(destroyParticles, transform.position, destroyParticles.transform.rotation);
    }
    public void DropItem()
    {
        Instantiate(item, transform.position, item.transform.rotation);
    }
}
