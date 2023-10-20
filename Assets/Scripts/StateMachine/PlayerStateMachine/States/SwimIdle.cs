using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwimIdle : State
{
    public PlayerMachine sm;
    public SwimIdle(PlayerMachine pm) : base(pm){
        sm = pm;
    }
    public override void Enter()
    {
        sm.animator.SetTrigger("SwimIdle");
        sm.character.Move(Vector3.zero);
    }

    public override void UpdateLogic()
    {
        if(sm.lifeSystem.life <= 0){
            sm.ChangeState(sm.death);
        }
        else if(Mathf.Abs(Input.GetAxisRaw("Horizontal")) > Mathf.Epsilon | Mathf.Abs(Input.GetAxisRaw("Vertical")) > Mathf.Epsilon && !sm.pause.paused){
            sm.ChangeState(sm.swimMove);
        }
        else if(sm.dialogueDetector.action == "Talk" && Input.GetButtonDown("Sprint")){
            sm.ChangeState(sm.talk);
        }
        else if(sm.dialogueDetector.action == "Kiss" && Input.GetButtonDown("Sprint")){
            sm.ChangeState(sm.kiss);
        }
        else if(sm.dialogueDetector.action == "Chest" && Input.GetButtonDown("Sprint")){
            sm.dialogueDetector.talkablesCollider[0].GetComponent<Chest>().ChestEvent();
        }
        else if(sm.dialogueDetector.action == "Door" && Input.GetButtonDown("Sprint")){
            sm.dialogueDetector.talkablesCollider[0].GetComponent<TransportDoor>().OpenDoor();
        }
        else if(sm.changeTo == "GHit" && !sm.pause.paused){
            sm.ChangeTo("");
            sm.ChangeState(sm.hurt);
        }
    }

    public override void UpdatePhysics()
    {
    }
}
