using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathState : State
{
    PlayerMachine sm;
    float timer;
    float timeToChange;
    public DeathState(PlayerMachine pm): base(pm){
        sm = pm;
    }
    public override void Enter()
    {
        sm.animator.SetTrigger("Death");
        timer = 0;
        timeToChange = 3;
    }
    public override void UpdateLogic()
    {
        timer += Time.deltaTime;
        if(timer >= timeToChange){
            SceneManager.LoadScene("Lose");
        }
    }
    public override void UpdatePhysics()
    {
    }
}
