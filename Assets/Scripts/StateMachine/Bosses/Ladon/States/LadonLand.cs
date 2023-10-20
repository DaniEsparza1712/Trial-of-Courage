using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadonLand : State
{
    LadonMachine sm;
    Vector3 direction;
    bool changedMusic;
    bool stunned;
    public LadonLand(LadonMachine lm): base(lm){
        sm = lm;
    }
    public override void Enter()
    {
        sm.animator.SetTrigger("Land");
        sm.animator.ResetTrigger("Fly Move");
        sm.hittable = false;
        direction = new Vector3(sm.target.transform.position.x, sm.transform.position.y, sm.target.transform.position.z);
        if(sm.changeTo == "Stun"){
            sm.ChangeTo("");
            stunned = true;
        }
        else{
            stunned = false;
        }
    }
    public override void UpdateLogic()
    {
        if(sm.changeTo == "Move" || sm.changeTo == "GHit"){
            sm.ChangeTo("");
            if(stunned)
                sm.ChangeState(sm.weak);
            else
                sm.ChangeState(sm.move);
        }
        direction = new Vector3(sm.target.transform.position.x, sm.transform.position.y, sm.target.transform.position.z);
    }
    public override void UpdatePhysics()
    {
        sm.transform.LookAt(direction);
    }
}
