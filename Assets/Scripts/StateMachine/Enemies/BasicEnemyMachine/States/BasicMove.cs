using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMove : State
{
    BasicEnemyMachine sm;
    Vector3 movePos;
    Vector3 direction;
    Vector3 lookPos;
    Quaternion lookRotation;
    string animation;
    float timer;
    public BasicMove(BasicEnemyMachine bem): base(bem){
        sm = bem;
    }

    public override void Enter()
    {
        sm.animator.SetTrigger("Move");
        sm.target = GameObject.Find("Player");
        sm.navAgent.SetDestination(sm.target.transform.position);
    }
    public override void UpdateLogic()
    {
        sm.navAgent.SetDestination(sm.target.transform.position);
        if(sm.changeTo == "GHit"){
            sm.ChangeTo("");
            sm.ChangeState(sm.basicGHit);
        }
        else if(Vector3.Distance(sm.transform.position, sm.target.transform.position) < 1f){
            sm.ChangeState(sm.basicAttack);
        }
        else if(sm.changeTo == "Dizzy"){
            sm.ChangeTo("");
            sm.ChangeState(sm.basicDizzy);
        }
    }
    public override void UpdatePhysics()
    {

    }
}
