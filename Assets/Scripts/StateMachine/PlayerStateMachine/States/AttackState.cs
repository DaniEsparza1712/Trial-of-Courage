using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State
{
    public PlayerMachine sm;
    private Vector3 moveVector;
    public AttackState(PlayerMachine pm) : base(pm){
        sm = pm;
    }
    public override void Enter()
    {
        sm.animator.SetTrigger("Attack");
        //sm.audioSource.PlayOneShot(sm.weaponManager.weapon.attackClip);
        sm.character.Move(Vector3.zero);
    }
    public override void UpdateLogic()
    {
        if(sm.lifeSystem.life <= 0){
            sm.ChangeState(sm.death);
        }
        else if(sm.changeTo == "Idle" && !sm.pause.paused){
            sm.ChangeTo("");
            sm.ChangeState(sm.idle);
        }
        else if(sm.changeTo == "GHit" && !sm.pause.paused){
            sm.ChangeTo("");
            sm.ChangeState(sm.hurt);
        }
        moveVector = sm.baseMoveVector * Time.deltaTime;
    }
    public override void UpdatePhysics()
    {
        sm.character.Move(moveVector);
        sm.character.Move(Physics.gravity * Time.deltaTime);
    }
}
