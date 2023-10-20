using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GruntMove : State
{
    GruntEnemyMachine sm;
    float timeForAttack;
    float timer;
    public GruntMove(GruntEnemyMachine gm): base(gm){
        sm = gm;
    }
    public override void Enter()
    {
        sm.animator.SetTrigger("Run");
        sm.target = GameObject.Find("Player");
        sm.navAgent.SetDestination(sm.target.transform.position);
        sm.navAgent.speed = sm.speed;
    }
    public override void UpdateLogic()
    {
        sm.navAgent.SetDestination(sm.target.transform.position);

        if(sm.lifeSystem.life == 0){
            sm.ChangeState(sm.gruntDeath);
        }
        else if(sm.changeTo == "GHit" && sm.GetHitCounter < sm.hitResistance){
            sm.ChangeTo("");
            sm.AddHit();
        }
        else if(sm.changeTo == "GHit" && sm.GetHitCounter >= sm.hitResistance){
            sm.ChangeTo("");
            sm.ChangeState(sm.gruntGHit);
        }
        else if(Vector3.Distance(sm.transform.position, sm.target.transform.position) < 4){
            sm.ChangeState(sm.gruntScavenge);
        }
    }
    public override void UpdatePhysics()
    {
        
    }
}
