using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GruntIdle : State
{
    GruntEnemyMachine sm;
    public GruntIdle(GruntEnemyMachine gm): base(gm){
        sm = gm;
    }
    public override void Enter()
    {
        //sm.animator.SetTrigger("Idle");
        sm.character.Move(Vector3.zero);
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
        else if(Physics.CheckSphere(sm.transform.position, 8f, sm.playerMask)){
            sm.ChangeState(sm.gruntMove);
        }
    }
    public override void UpdatePhysics()
    {
        
    }
}
