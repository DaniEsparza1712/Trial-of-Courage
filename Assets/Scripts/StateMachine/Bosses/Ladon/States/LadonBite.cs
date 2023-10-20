using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadonBite : State
{
    LadonMachine sm;
    Vector3 direction;
    public LadonBite(LadonMachine lm): base(lm){
        sm = lm;
    }
    public override void Enter()
    {
        sm.animator.SetTrigger("Bite");
        sm.character.Move(Vector3.zero);
        direction = new Vector3(sm.target.transform.position.x, sm.transform.position.y, sm.target.transform.position.z);
    }
    public override void UpdateLogic()
    {
        if(sm.changeTo == "Move"){
            sm.ChangeTo("");
            sm.ChangeState(sm.move);
        }
        else if(sm.changeTo == "Stun"){
            sm.ChangeTo("");
            sm.ChangeState(sm.stun);
        }
        direction = new Vector3(sm.target.transform.position.x, sm.transform.position.y, sm.target.transform.position.z);
    }
    public override void UpdatePhysics()
    {
        sm.transform.LookAt(direction);
    }
}
