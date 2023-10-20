using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadonIdle : State
{
    LadonMachine sm;
    public LadonIdle(LadonMachine lm): base(lm){
        sm = lm;
    }
    public override void Enter()
    {
        sm.hittable = false;
    }
    public override void UpdateLogic()
    {
        if(sm.target != null){
            sm.ChangeState(sm.roar);
        }
    }
    public override void UpdatePhysics()
    {
        Collider[] colliders = Physics.OverlapSphere(sm.transform.position, 8);
        foreach(Collider collider in colliders){
            if(collider.gameObject.CompareTag("Player")){
                sm.target = collider.gameObject.transform;
            }
        }
    }
}
