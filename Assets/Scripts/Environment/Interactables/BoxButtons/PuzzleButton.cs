using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//Uses an event to control what happens when the indicated Block Object interacts with the button
public class PuzzleButton : MonoBehaviour
{
    public GameObject block;
    public UnityEvent activatedEvent;
    private bool activated;
    [Header("For Spawning Object")]
    [SerializeField]
    private GameObject spawnObj;
    [SerializeField]
    private ParticleSystem spawnPS;
    [Header("For Camera Focus")]
    [SerializeField]
    private CinemachineVirtualCamera virtualCamera;
    public float focusTime;
    private void Start()
    {
        activated = false;
        InitializeFunctions();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == block && !activated)
        {
            activated = true;
            activatedEvent.Invoke();
        }
    }

    //Default functions for activated event
    void InitializeFunctions()
    {
        if (spawnObj != null)
            spawnObj.SetActive(false);
    }
    public void SpawnObj()
    {
        if(spawnObj != null && spawnPS != null)
        {
            spawnObj.SetActive(true);
            Instantiate(spawnPS, spawnObj.transform.position, spawnPS.transform.rotation);
        }
    }
    public void FocusOnObj()
    {
        StartCoroutine(WaitForUnfocus());
    }
    public IEnumerator WaitForUnfocus()
    {
        virtualCamera.enabled = true;
        yield return new WaitForSeconds(focusTime);
        virtualCamera.enabled = false;
    }
}
