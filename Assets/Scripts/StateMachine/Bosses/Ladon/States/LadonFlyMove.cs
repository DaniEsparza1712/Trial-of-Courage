using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadonFlyMove : State
{
    LadonMachine sm;
    Transform flyTarget;
    Vector3 direction;
    public LadonFlyMove(LadonMachine lm): base(lm){
        sm = lm;
    }
    public override void Enter()
    {
        Debug.Log("Fly Move");
        sm.animator.SetTrigger("Fly Move");
        sm.hittable = false;
        flyTarget = sm.flyTargets[Random.Range(0, sm.flyTargets.Count)];
        direction = new Vector3(flyTarget.transform.position.x, sm.transform.position.y, flyTarget.transform.position.z);
    }
    public override void UpdateLogic()
    {
        if(Vector3.Distance(sm.transform.position, direction) < 1f){
            sm.ChangeState(sm.flyFire);
        }
    }
    public override void UpdatePhysics()
    {
        sm.transform.LookAt(direction);
        sm.character.Move(sm.transform.forward * sm.speed * Time.deltaTime);
    }
}
