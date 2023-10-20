using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicDizzy : State
{
    BasicEnemyMachine sm;
    float time;
    float dizzyTime;
    public BasicDizzy(BasicEnemyMachine bem): base(bem){
        sm = bem;
    }
    public override void Enter()
    {
        sm.animator.SetTrigger("Dizzy");
        sm.character.Move(Physics.gravity);
        dizzyTime = 3.0f;
        time = 0;
    }
    public override void UpdateLogic()
    {
        time += Time.deltaTime;
        if(time >= dizzyTime){
            sm.ChangeState(sm.basicIdle);
        }
        if(sm.changeTo == "GHit"){
            sm.ChangeTo("");
            sm.ChangeState(sm.basicGHit);
        }
    }
    public override void UpdatePhysics()
    {
        sm.character.Move(Physics.gravity);
    }
}
