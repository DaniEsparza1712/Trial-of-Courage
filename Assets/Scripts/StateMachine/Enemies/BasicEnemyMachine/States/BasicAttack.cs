using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicAttack : State
{
    BasicEnemyMachine sm;
    Vector3 lookPos;
    public BasicAttack(BasicEnemyMachine bem):base(bem){
        sm = bem;
    }
    public override void Enter()
    {
        sm.animator.SetTrigger("Attack");
        sm.character.Move(Vector3.zero);
        sm.navAgent.SetDestination(sm.transform.position);
    }
    public override void UpdateLogic()
    {     
        lookPos = new Vector3(sm.target.transform.position.x, sm.transform.position.y, sm.target.transform.position.z);
        if(sm.changeTo == "Move"){
            sm.ChangeTo("");
            sm.ChangeState(sm.basicMove);
        }
        else if(sm.changeTo == "GHit"){
            sm.ChangeTo("");
            sm.ChangeState(sm.basicGHit);
        }
        else if(sm.changeTo == "Dizzy"){
            sm.ChangeTo("");
            sm.ChangeState(sm.basicDizzy);
        }
    }
    public override void UpdatePhysics()
    {
        sm.transform.LookAt(lookPos);
        sm.character.Move(Physics.gravity);
    }
}
