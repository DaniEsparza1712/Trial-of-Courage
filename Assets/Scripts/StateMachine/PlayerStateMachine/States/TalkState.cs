using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkState : State
{
    PlayerMachine sm;
    Vector3 direction;
    public TalkState(PlayerMachine pm): base(pm){
        sm = pm;
    }

    public override void Enter()
    {
        sm.animator.SetTrigger("Talk");
        sm.dialogueDetector.talkablesCollider[0].gameObject.GetComponent<DialogueTrigger>().TriggerDialogue();
        direction = sm.dialogueDetector.talkablesCollider[0].gameObject.transform.position;
        direction.y = sm.transform.position.y;
    }
    public override void UpdateLogic()
    {
        if(sm.changeTo == "Idle"){
            sm.ChangeTo("");
            sm.ChangeState(sm.idle);
        }
    }
    public override void UpdatePhysics()
    {
        sm.transform.LookAt(direction);
    }
}
