using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondaryAttackState : State
{
    PlayerMachine sm;
    public SecondaryAttackState(PlayerMachine pm): base(pm){
        sm = pm;
    }
    public override void Enter()
    {
        sm.animator.SetTrigger(sm.secWeaponManager.secondaryWeaponData.secondaryWeapon.animTrigger);
        sm.weaponManager.weaponHolder.SetActive(false);
        sm.secWeaponManager.weaponHolder.SetActive(true);
        sm.secWeaponManager.ChangeActiveWeapon();
    }
    public override void UpdateLogic()
    {
        if(sm.changeTo == "Idle"){
            sm.ChangeTo("");
            sm.weaponManager.weaponHolder.SetActive(true);
            sm.secWeaponManager.weaponHolder.SetActive(false);
            sm.ChangeState(sm.idle);
        }
        else if(sm.changeTo == "GHit" && !sm.pause.paused){
            sm.ChangeTo("");
            sm.weaponManager.weaponHolder.SetActive(true);
            sm.secWeaponManager.weaponHolder.SetActive(false);
            sm.ChangeState(sm.hurt);
        }
    }
    public override void UpdatePhysics()
    {
        sm.character.Move(Physics.gravity);
    }
}
