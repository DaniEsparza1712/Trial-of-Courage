using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GruntGetHit : State
{
    GruntEnemyMachine sm;
    public GruntGetHit(GruntEnemyMachine gm): base(gm){
        sm = gm;
    }
    public override void Enter()
    {
        sm.ResetHitCounter();
        sm.animator.SetTrigger("GHit");
        sm.navAgent.speed = 0;
    }
    public override void UpdateLogic()
    {
        if(sm.lifeSystem.life == 0){
            sm.ChangeState(sm.gruntDeath);
        }
        else if(sm.changeTo == "Move"){
            sm.ChangeTo("");
            sm.ChangeState(sm.gruntMove);
        }
    }
    public override void UpdatePhysics()
    {
        
    }
}
