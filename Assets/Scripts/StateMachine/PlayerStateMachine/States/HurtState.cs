using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtState : State
{
    public PlayerMachine sm;
    public HurtState(PlayerMachine pm): base(pm){
        sm = pm;
    }

    public override void Enter()
    {
        sm.animator.SetTrigger("GHit");
        sm.rb.velocity = Vector3.zero;
        sm.ChangeInvincible(1);
        //sm.StartCoroutine(sm.WaitForChangeInvincible(0.8f, 2));
    }
    public override void UpdateLogic()
    {
        if(sm.lifeSystem.life <= 0){
            sm.ChangeState(sm.death);
        }
        else if(sm.changeTo == "Idle" && !sm.pause.paused){
            sm.ChangeTo("");
            sm.ChangeState(sm.idle);
        }
        else if(sm.changeTo == "GHit" && !sm.pause.paused){
            sm.ChangeTo("");
            sm.ChangeState(sm.hurt);
        }
    }
    public override void UpdatePhysics()
    {
    }
}
