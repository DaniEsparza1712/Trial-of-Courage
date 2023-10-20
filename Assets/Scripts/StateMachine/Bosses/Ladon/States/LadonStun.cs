using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadonStun : State
{
    LadonMachine sm;
    public LadonStun(LadonMachine lm): base(lm){
        sm = lm;
    }
    public override void Enter()
    {
        sm.animator.SetTrigger("Stun");
        sm.hittable = true;
    }
    public override void UpdateLogic()
    {
        if(sm.changeTo == "Move"){
            sm.ChangeTo("");
            sm.ChangeState(sm.move);
        }
    }
    public override void UpdatePhysics()
    {
        
    }
}
