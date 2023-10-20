using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpState : State
{
    public PlayerMachine sm;
    public JumpState(PlayerMachine pm) : base(pm){
        sm = pm;
    }
    private RaycastHit hit;
    private Vector3 jumpSpeed;
    public override void Enter()
    {
        jumpSpeed = Vector3.up * 5;
        jumpSpeed += sm.transform.forward * 5;
        sm.animator.SetTrigger("Jump");
        sm.transform.SetParent(null);
    }

    public override void UpdateLogic()
    {
        if(Physics.CapsuleCast(sm.transform.position + Vector3.up * 0.13f, sm.transform.position + Vector3.up * 0.13f, sm.character.radius, Vector3.down, out hit, 0.1f, sm.ignorePlayer, QueryTriggerInteraction.Ignore)){
            if(hit.collider.gameObject.CompareTag("Swim")){
                sm.ChangeTo("Swim");
            }
            else if(hit.collider.gameObject.CompareTag("Floor")){
                sm.ChangeTo("Idle");
                sm.transform.SetParent(hit.collider.transform);
            }
        }
        if(sm.lifeSystem.life <= 0){
            sm.ChangeState(sm.death);
        }
        else if(sm.changeTo == "Swim"){
            sm.ChangeTo("");
            sm.ChangeState(sm.swimIdle);
        }
        else if(sm.changeTo == "Idle"){
            sm.ChangeTo("");
            sm.ChangeState(sm.idle);
        }
        else if(sm.changeTo == "GHit" && !sm.pause.paused){
            sm.ChangeTo("");
            sm.ChangeState(sm.hurt);
        }
    }

    public override void UpdatePhysics()
    {
        if(!sm.pause.paused){
            jumpSpeed += Physics.gravity * Time.deltaTime;
            jumpSpeed.y = Mathf.Clamp(jumpSpeed.y + Physics.gravity.y * Time.deltaTime, Physics.gravity.y, jumpSpeed.y);
            sm.character.Move(jumpSpeed * Time.deltaTime);
        }
    }
}