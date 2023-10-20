using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateMachine: MonoBehaviour
{
    public CharacterController character;
    public Animator animator;
    public LifeSystem lifeSystem;
    public AudioSource audioSource;
    public float speed;
    [HideInInspector]
    public int damageToApply = 0;

    [HideInInspector]
    public string changeTo = "";
    [HideInInspector]
    public ParticleSystem getHitSpark;
    [HideInInspector]
    public AudioClip getHitAudio;

    [HideInInspector]
    public State currentState;
    private List<Material> materials = new List<Material>();
    public List<Material> GetMaterials => materials;
    private bool invincible = false;
    public bool GetInvincible => invincible;
    
    public void SetMaterialColor(Color color){
        foreach(Material mat in materials){
            mat.SetColor("_BaseColor", color);
        }
    }

    public virtual void Start() {
        /*currentState = idle;
        currentState.Enter(this);*/
        Renderer[] renderers = GetComponentsInChildren<Renderer>(true);
        foreach(Renderer renderer in renderers){
            materials.Add(renderer.material);
        }
    }

    public virtual void Update() {
        currentState.UpdateLogic();
    }
    private void LateUpdate() {
        currentState.UpdatePhysics();
    }
    public void ChangeState(State state){
        currentState = state;
        currentState.Enter();
    }
    public void ChangeTo(string state){
        changeTo = state;
    }
    public void ChangeInvincible(int value){
        switch(value){
            case 1:
                invincible = true;
                Debug.Log("Invincible");
                SetMaterialColor(new Color(229f/255f, 100f/255f, 127f/255f));
                break;
            case 2:
                invincible = false;
                Debug.Log("Vincible");
                SetMaterialColor(Color.white);
                ChangeTo("");
                break;
        }
    }
    public IEnumerator WaitForChangeInvincible(float seconds, int val){
        Debug.Log(seconds);
        yield return new WaitForSeconds(seconds);
        ChangeInvincible(val);
    }
}
