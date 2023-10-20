using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadonFlyIdle : State
{
    LadonMachine sm;
    Vector3 direction;
    float timer;
    float timeToChange;
    public LadonFlyIdle(LadonMachine lm): base(lm){
        sm = lm;
    }
    public override void Enter()
    {
        sm.animator.SetTrigger("Fly Idle");
        sm.hittable = false;
        timeToChange = Random.Range(0.5f, 2);
        timer = 0;
        direction = new Vector3(sm.target.transform.position.x, sm.transform.position.y, sm.target.transform.position.z);
    }
    public override void UpdateLogic()
    {
        timer += Time.deltaTime;
        if(timer >= timeToChange){
            int stateNum = Random.Range(0, 30);
            Debug.Log(stateNum);
            if(stateNum < 15)
                sm.ChangeState(sm.land);
            else if(stateNum < 20)
                sm.ChangeState(sm.flyFire);
            else if(stateNum < 30)
                sm.ChangeState(sm.flyMove);
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
