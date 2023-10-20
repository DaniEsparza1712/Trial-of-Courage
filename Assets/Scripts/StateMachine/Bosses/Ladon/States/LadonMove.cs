using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadonMove : State
{
    LadonMachine sm;
    Vector3 direction;
    float timeToChange;
    float timer;
    public LadonMove(LadonMachine lm): base(lm){
        sm = lm;
    }
    public override void Enter()
    {
        sm.hittable = false;
        sm.animator.SetTrigger("Move");
        timeToChange = Random.Range(0.5f, 4);
        timer = 0;
        direction = new Vector3(sm.target.transform.position.x, sm.transform.position.y, sm.target.transform.position.z);
    }
    public override void UpdateLogic()
    {
        timer += Time.deltaTime;
        if(timer >= timeToChange){
            int stateNum = Random.Range(0, 40);
            if(stateNum < 20)
                sm.ChangeState(sm.shootFire);
            else if(stateNum < 30)
                sm.ChangeState(sm.roar);
            else if(stateNum <= 40)
                sm.ChangeState(sm.takeOff);
        }
        if(Vector3.Distance(sm.transform.position, sm.target.transform.position) < 5){
            sm.ChangeState(sm.bite);
        }
        else if(sm.changeTo == "GHit"){
            sm.ChangeTo("");
            sm.ChangeState(sm.defend);
        }
        else if(sm.changeTo == "GHit"){
            sm.ChangeTo("");
            sm.ChangeState(sm.defend);
        }
        else if(sm.changeTo == "Stun"){
            sm.ChangeTo("");
            sm.ChangeState(sm.defend);
        }
        
        direction = new Vector3(sm.target.transform.position.x, sm.transform.position.y, sm.target.transform.position.z);
    }
    public override void UpdatePhysics()
    {
        sm.transform.LookAt(direction);
        sm.character.Move(sm.transform.forward * sm.speed * Time.deltaTime);
    }
}
