using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadonFlyFire : State
{
    LadonMachine sm;
    Vector3 direction;
    public LadonFlyFire(LadonMachine lm): base(lm){
        sm = lm;
    }
    public override void Enter()
    {
        sm.animator.SetTrigger("Fly Fire");
        sm.hittable = false;
        direction = new Vector3(sm.target.transform.position.x, sm.transform.position.y, sm.target.transform.position.z);
    }
    public override void UpdateLogic()
    {
        if(sm.changeTo == "Fly Idle"){
            sm.ChangeTo("");
            sm.ChangeState(sm.flyIdle);
        }
        else if(sm.changeTo == "Stun"){
            sm.ChangeState(sm.land);
        }
        direction = new Vector3(sm.target.transform.position.x, sm.transform.position.y, sm.target.transform.position.z);
    }
    public override void UpdatePhysics()
    {
        sm.transform.LookAt(direction);
    }
}
