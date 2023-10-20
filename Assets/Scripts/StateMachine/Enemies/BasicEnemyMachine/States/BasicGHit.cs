using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicGHit : State
{
    BasicEnemyMachine sm;
    public BasicGHit(BasicEnemyMachine bem):base(bem){
        sm = bem;
    }

    public override void Enter()
    {
        sm.animator.SetTrigger("GHit");
        sm.character.Move(Physics.gravity);
        sm.ChangeInvincible(1);
        sm.StartCoroutine(sm.WaitForChangeInvincible(0.8f, 2));
        sm.navAgent.SetDestination(sm.transform.position);
    }
    public override void UpdateLogic()
    {
        if(sm.changeTo == "Idle"){
            sm.ChangeState(sm.basicIdle);
        }
        else if(sm.changeTo == "GHit"){
            sm.ChangeTo("");
            sm.ChangeState(sm.basicGHit);
        }
        else if(sm.lifeSystem.life <= 0){
            sm.ChangeState(sm.basicDeath);
        }
    }
    public override void UpdatePhysics()
    {
        sm.character.Move(Physics.gravity);
    }
}
