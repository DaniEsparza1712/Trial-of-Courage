using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LadonMachine : StateMachine
{
    [HideInInspector]
    public LadonIdle idle;
    [HideInInspector]
    public LadonMove move;
    [HideInInspector]
    public LadonBite bite;
    [HideInInspector]
    public LadonDefend defend;
    [HideInInspector]
    public LadonStun stun;
    [HideInInspector]
    public LadonShootFire shootFire;
    [HideInInspector]
    public LadonRoar roar;
    [HideInInspector]
    public LadonTakeOff takeOff;
    [HideInInspector]
    public LadonFlyMove flyMove;
    [HideInInspector]
    public LadonFlyFire flyFire;
    [HideInInspector]
    public LadonFlyIdle flyIdle;
    [HideInInspector]
    public LadonLand land;
    [HideInInspector]
    public LadonWeak weak;
    public Transform target;
    public Pathfinding pathfinding;
    public bool hittable;
    public GameObject flamethrowerA;
    public GameObject flamethrowerB;
    public AudioManager audioManager;
    [HideInInspector]
    public AudioSource musicSource;
    public AudioClip music;
    public GameObject lackeys;
    public ItemData reward;
    public ParticleSystem spawnParticles;
    public List<Transform> spawnPositions = new List<Transform>();
    public List<Transform> flyTargets = new List<Transform>();
    public Collider baseCollider;
    public Collider flyCollider;
    public GameObject message;
    public TMP_Text text;
    public GameObject sceneManager;
    public override void Start() {
        base.Start();
        Physics.IgnoreLayerCollision(3, 10);
        idle = new LadonIdle(this);
        move = new LadonMove(this);
        bite = new LadonBite(this);
        defend = new LadonDefend(this);
        stun = new LadonStun(this);
        shootFire = new LadonShootFire(this);
        roar = new LadonRoar(this);
        takeOff = new LadonTakeOff(this);
        flyMove = new LadonFlyMove(this);
        flyFire = new LadonFlyFire(this);
        flyIdle = new LadonFlyIdle(this);
        land = new LadonLand(this);
        weak = new LadonWeak(this);

        currentState = idle;
        idle.Enter();
        musicSource = Camera.main.GetComponent<AudioSource>();
    }
    public void ChangeSpeed(int newSpeed){
        speed = newSpeed;
    }
    public void ChangeFlamethrowerA(int flameCase){
        if(flameCase == 1){
            flamethrowerA.SetActive(true);
        }
        else{
            flamethrowerA.SetActive(false);
        }
    }
    public void ChangeFlamethrowerB(int flameCase){
        if(flameCase == 1){
            flamethrowerB.SetActive(true);
        }
        else{
            flamethrowerB.SetActive(false);
        }
    }
    public void Spawn(){
        foreach(Transform spawnPos in spawnPositions){
            Instantiate(spawnParticles, spawnPos.position, spawnParticles.transform.rotation);
            Instantiate(lackeys, spawnPos.position, lackeys.transform.rotation);
        }
    }
    public void ChangeColliders(){
        Debug.Log("Changed!");
        baseCollider.enabled = !baseCollider.enabled;
        flyCollider.enabled = !flyCollider.enabled;
    }
    public void Die(){
        if(lifeSystem.life <= 0){
            Instantiate(lifeSystem.disappearParticles, transform.position, lifeSystem.disappearParticles.transform.rotation);
            Inventory.instance.AddToInventory(reward, 1);
            Inventory.instance.SetMessage(reward);
            Instantiate(sceneManager);
            
            Destroy(gameObject);
        }
    }
    
}
