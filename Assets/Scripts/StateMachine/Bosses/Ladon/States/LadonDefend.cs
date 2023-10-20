using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadonDefend : State
{
    LadonMachine sm;
    Vector3 direction;
    public LadonDefend(LadonMachine lm): base(lm){
        sm = lm;
    }
    public override void Enter()
    {
        sm.animator.SetTrigger("Defend");
        sm.hittable = false;
        direction = new Vector3(sm.target.transform.position.x, sm.transform.position.y, sm.target.transform.position.z);
    }
    public override void UpdateLogic()
    {
        if(sm.changeTo == "Move"){
            sm.ChangeTo("");
            sm.ChangeState(sm.move);
        }
        direction = new Vector3(sm.target.transform.position.x, sm.transform.position.y, sm.target.transform.position.z);
    }
    public override void UpdatePhysics()
    {
        sm.transform.LookAt(direction);
    }
}
