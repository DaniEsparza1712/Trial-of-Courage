using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
    public PlayerMachine sm;
    private Vector3 moveVector;
    public IdleState(PlayerMachine pm) : base(pm){
        sm = pm;
    }
    public override void Enter()
    {
        sm.animator.SetTrigger("Idle");
        sm.character.Move(Vector3.zero);
    }

    public override void UpdateLogic()
    {
        if(sm.lifeSystem.life <= 0){
            sm.ChangeState(sm.death);
        }
        else if(Mathf.Abs(Input.GetAxisRaw("Horizontal")) > Mathf.Epsilon | Mathf.Abs(Input.GetAxisRaw("Vertical")) > Mathf.Epsilon && !sm.pause.paused){
            sm.ChangeState(sm.move);
        }
        else if(Input.GetButtonDown("Attack1") && !sm.pause.paused){
            sm.ChangeState(sm.attack);
        }
        else if(Input.GetButtonDown("SupportA") && !sm.pause.paused){
            sm.ChangeState(sm.secAttack);
        }
        else if(Input.GetButtonDown("SupportB") && !sm.pause.paused){
            sm.ChangeState(sm.secAttackB);
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
        else if (sm.dialogueDetector.action == "LockedDoor" && Input.GetButtonDown("Sprint"))
        {
            Door door = sm.dialogueDetector.talkablesCollider[0].GetComponent<Door>();
            if (Inventory.instance.HasItem(door.keyID))
            {
                Inventory.instance.AddToInventory(door.keyID, -1);
                door.OpenDoor();
            }
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
