using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicIdle : State
{
    BasicEnemyMachine sm;
    public BasicIdle(BasicEnemyMachine bem) : base(bem){
        sm = bem;
    }

    public override void Enter()
    {
        sm.animator.SetTrigger("Idle");
        sm.character.Move(Vector3.zero);
    }
    public override void UpdateLogic()
    {
        if(sm.changeTo == "GHit"){
            sm.ChangeTo("");
            sm.ChangeState(sm.basicGHit);
        }
        else if(Physics.CheckSphere(sm.transform.position, 6, sm.playerMask)){
            sm.ChangeState(sm.basicMove);
        }
        else if(sm.changeTo == "Dizzy"){
            sm.ChangeTo("");
            sm.ChangeState(sm.basicDizzy);
        }
    }
    public override void UpdatePhysics()
    {
        sm.character.Move(Physics.gravity);
    }
}
