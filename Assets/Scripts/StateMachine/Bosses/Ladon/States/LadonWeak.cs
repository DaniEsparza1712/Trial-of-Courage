using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadonWeak : State
{
    LadonMachine sm;
    float timer;
    float timeToChange;
    public LadonWeak(LadonMachine lm): base(lm){
        sm = lm;
    }
    public override void Enter()
    {
        sm.animator.SetTrigger("Weak");
        timeToChange = 5;
        timer = 0;
    }
    public override void UpdateLogic()
    {
        if(timer > 0.5f){
            sm.hittable = true;
        }
        timer += Time.deltaTime;
        if(timer >= timeToChange){
            sm.ChangeTo("");
            sm.ChangeState(sm.move);
        }
    }
    public override void UpdatePhysics()
    {
    }
}
