using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadonTakeOff : State
{
    LadonMachine sm;
    public LadonTakeOff(LadonMachine lm): base(lm){
        sm = lm;
    }
    public override void Enter()
    {
        Debug.Log("Take off");
        sm.animator.SetTrigger("Take Off");
        sm.hittable = false;
    }
    public override void UpdateLogic()
    {
        if(sm.changeTo == "FlyMove"){
            sm.ChangeTo("");
            sm.ChangeState(sm.flyMove);
        }
    }
    public override void UpdatePhysics()
    {
        
    }
}
