using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.AI;

public class TransportDoor : MonoBehaviour
{
    public UnityEvent doorOpen;
    public string sceneToLoad;
    public GameObject level;
    public Vector3 playerSpawnPos;
    public AudioClip newAreaMusic;
    private void Start() {
        GameObject manager = GameObject.Find("Manager");
        SceneLoader managerSceneLoader = manager.GetComponent<SceneLoader>();
        doorOpen.AddListener(delegate{managerSceneLoader.LoadLevelAdditive(sceneToLoad, level, playerSpawnPos, newAreaMusic);});
    }

    public void OpenDoor(){
        doorOpen.Invoke();
    }
}
