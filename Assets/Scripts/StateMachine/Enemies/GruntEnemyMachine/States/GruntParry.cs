using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GruntParry : State
{
    GruntEnemyMachine sm;
    public GruntParry(GruntEnemyMachine gm): base(gm){
        sm = gm;
    }
    public override void Enter()
    {
        sm.animator.SetTrigger("Parry");
        sm.character.Move(Vector3.zero);
        sm.navAgent.speed = 0;
    }
    public override void UpdateLogic()
    {
        if(sm.lifeSystem.life == 0){
            sm.ChangeState(sm.gruntDeath);
        }
        else if(sm.changeTo == "GHit" && sm.GetHitCounter < sm.hitResistance){
            sm.ChangeTo("");
            sm.AddHit();
        }
        else if(sm.changeTo == "GHit" && sm.GetHitCounter >= sm.hitResistance){
            sm.ChangeTo("");
            sm.ChangeState(sm.gruntGHit);
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
