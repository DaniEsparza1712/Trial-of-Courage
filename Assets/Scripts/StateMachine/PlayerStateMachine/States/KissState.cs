using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KissState : State
{
    PlayerMachine sm;
    public KissState(PlayerMachine pm): base(pm){
        sm = pm;
    }

    public override void Enter()
    {
        sm.animator.SetTrigger("Kiss");
        sm.kissManager.ChangeToKiss();
    }
    public override void UpdateLogic()
    {
        if(sm.changeTo == "Idle"){
            sm.kissManager.ChangeToPlayer();
            sm.ChangeTo("");
            sm.ChangeState(sm.idle);
        }
    }
    public override void UpdatePhysics()
    {
        
    }
}
