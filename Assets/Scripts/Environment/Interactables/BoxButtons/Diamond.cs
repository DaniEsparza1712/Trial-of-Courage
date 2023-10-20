using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : MonoBehaviour
{
    public bool correct;
    public bool activated;
    public ParticleSystem spawnParticle;
    public GameObject enemy;
    public Transform spawnPos;
    public DiamondDoor door;
    public AudioManager audioManager;
    GameObject enemyInstance;

    private void Update() {
        if(enemyInstance == null && !door.opened){
            door.canOpen = true;
        }
    }

    public void CheckAnswer(){
        if(correct && door.canOpen){
            audioManager.PlayAudioFromSource(0);
            door.canOpen = false;
            door.StartCoroutine("RotateDoor");
        }
        else if(!correct && door.canOpen){
            audioManager.PlayAudioFromSource(1);
            door.canOpen = false;
            SpawnEnemy();
        }
    }

    void SpawnEnemy(){
        Instantiate(spawnParticle, spawnPos.position, spawnParticle.transform.rotation);
        enemyInstance = Instantiate(enemy, spawnPos.position, enemy.transform.rotation);
    }
}
