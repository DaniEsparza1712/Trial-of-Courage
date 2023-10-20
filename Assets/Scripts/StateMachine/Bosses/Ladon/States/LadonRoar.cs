using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadonRoar : State
{
    LadonMachine sm;
    Vector3 direction;
    bool changedMusic;
    public LadonRoar(LadonMachine lm): base(lm){
        sm = lm;
    }
    public override void Enter()
    {
        sm.animator.SetTrigger("Roar");
        sm.hittable = false;
        direction = new Vector3(sm.target.transform.position.x, sm.transform.position.y, sm.target.transform.position.z);
        if(!changedMusic){
            sm.musicSource.clip = sm.music;
            sm.musicSource.Play();
            changedMusic = true;
        }
    }
    public override void UpdateLogic()
    {
        if(sm.changeTo == "Move"){
            sm.ChangeTo("");
            sm.ChangeState(sm.move);
        }
        direction = new Vector3(sm.target.transform.position.x, sm.transform.position.y, sm.target.transform.position.z);
    }
    public override void UpdatePhysics()
    {
        sm.transform.LookAt(direction);
    }
}
