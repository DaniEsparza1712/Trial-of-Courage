using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondaryAttackBState : State
{
    PlayerMachine sm;
    public SecondaryAttackBState(PlayerMachine pm): base(pm){
        sm = pm;
    }
    public override void Enter()
    {
        sm.animator.SetTrigger(sm.secWeaponManager.secondaryWeaponDataB.secondaryWeapon.animTrigger);
        sm.weaponManager.weaponHolder.SetActive(false);
        sm.secWeaponManager.weaponHolder.SetActive(true);
        sm.secWeaponManager.ChangeActiveWeaponB();
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
