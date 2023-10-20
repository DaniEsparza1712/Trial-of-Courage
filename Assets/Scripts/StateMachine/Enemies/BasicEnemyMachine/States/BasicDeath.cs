using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicDeath : State
{
    BasicEnemyMachine sm;
    float timer;
    public BasicDeath(BasicEnemyMachine bem): base(bem){
        sm = bem;
    }
    public override void Enter()
    {
        sm.animator.SetTrigger("Death");
        sm.character.Move(Vector3.zero);
        Score.instance.AddScore(100);
        timer = 0;
        sm.navAgent.SetDestination(sm.transform.position);
    }
    public override void UpdateLogic()
    {
        timer += Time.deltaTime;
        if(sm.changeTo == "Disappear" || timer >= 2){
            sm.gameObject.SetActive(false);
        }
    }
    public override void UpdatePhysics()
    {
        sm.character.Move(Physics.gravity);
    }
}
