using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GruntAttack : State
{
    GruntEnemyMachine sm;
    public GruntAttack(GruntEnemyMachine gm): base(gm){
        sm = gm;
    }
    public override void Enter()
    {
        int animation = Random.Range(1, 3);
        sm.animator.SetTrigger("Attack0" + animation);
        sm.character.Move(Vector3.zero);
        sm.navAgent.speed = 0;
    }
    public override void UpdateLogic()
    {
        if(sm.changeTo == "GHit" && sm.GetHitCounter < sm.hitResistance){
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
