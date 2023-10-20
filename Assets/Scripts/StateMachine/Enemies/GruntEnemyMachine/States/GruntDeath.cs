using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GruntDeath : State
{
    GruntEnemyMachine sm;
    float timer;
    public GruntDeath(GruntEnemyMachine gm): base(gm){
        sm = gm;
    }
    public override void Enter()
    {
        sm.animator.SetTrigger("Death");
        timer = 0;
        sm.navAgent.speed = 0;
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
        
    }
}
