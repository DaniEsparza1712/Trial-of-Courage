using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GruntScavenge : State
{
    GruntEnemyMachine sm;
    private float timer;
    private float timeForAttack;
    public GruntScavenge(GruntEnemyMachine gm): base(gm){
        sm = gm;
    }
    public override void Enter()
    {
        sm.animator.SetTrigger("Walk");
        sm.target = GameObject.Find("Player");
        sm.navAgent.SetDestination(sm.target.transform.position);
        sm.navAgent.speed = sm.speed / 2;
        timer = 0;
        timeForAttack = Random.Range(0.5f, 1f);
    }
    public override void UpdateLogic()
    {
        timer += Time.deltaTime;
        sm.navAgent.SetDestination(sm.target.transform.position);
        float distance = Vector3.Distance(sm.transform.position, sm.target.transform.position);
        if(Vector3.Distance(sm.transform.position, sm.target.transform.position) < 2.5f){
            sm.navAgent.speed = 0.1f;
        }
        else{
            sm.navAgent.speed = sm.speed / 2;
        }

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
        else if(distance > 4){
            sm.ChangeState(sm.gruntMove);
        }
        else if(Input.GetButtonDown("Attack1") && distance <= 3){
            int chance = Random.Range(1, 4);
            if(chance > 2){
                Vector3 viewVector = sm.target.transform.position;
                viewVector.y = sm.transform.position.y;
                sm.transform.LookAt(viewVector);
                sm.ChangeState(sm.gruntParry);
            }
        }
        else if(timer >= timeForAttack && distance <= 3){
            Vector3 viewVector = sm.target.transform.position;
            viewVector.y = sm.transform.position.y;
            sm.transform.LookAt(viewVector);
            sm.ChangeState(sm.gruntAttack);
        }
        
    }
    public override void UpdatePhysics()
    {
        
    }
}
