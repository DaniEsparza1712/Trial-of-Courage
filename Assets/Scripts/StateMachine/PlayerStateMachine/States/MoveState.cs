using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder;

public class MoveState : State
{
    public PlayerMachine sm;
    public MoveState(PlayerMachine pm) : base(pm){
        sm = pm;
    }

    private Vector3 direction;
    private Vector3 moveVector;
    private RaycastHit swimHit;
    private float sprintModifier;
    public override void Enter()
    {
        sm.animator.SetTrigger("Move");
        sm.currentSpeed = sm.speed;
        sprintModifier = 1.5f;

        float hAxis = Input.GetAxis("Horizontal");
        float vAxis = Input.GetAxis("Vertical");
        direction = new Vector3(hAxis, 0, vAxis);
        sm.transform.forward = direction;
    }

    public override void UpdateLogic()
    {
        if(Physics.CapsuleCast(sm.transform.position + Vector3.up * 0.26f + sm.transform.forward * 0.1f, sm.transform.position + Vector3.up * 0.26f + sm.transform.forward * 0.1f, sm.character.radius, Vector3.down, out swimHit, sm.character.stepOffset * 1.1f + 0.13f, sm.ignorePlayer)){
            if(swimHit.collider.gameObject.CompareTag("Swim")){
                sm.ChangeTo("Swim");
            }
        }
        else{
            sm.ChangeTo("Jump");
        }

        float hAxis = Input.GetAxis("Horizontal");
        float vAxis = Input.GetAxis("Vertical");

        if(Input.GetButton("Sprint") && sm.currentSpeed < sm.speed * sprintModifier){
            sm.currentSpeed *= sprintModifier;
        }
        else if(Input.GetButtonUp("Sprint")){
            sm.currentSpeed = sm.speed;
        }
        
        direction = new Vector3(hAxis, 0, vAxis);
        moveVector = (sm.baseMoveVector + direction * sm.currentSpeed) * Time.deltaTime;

        sm.animator.SetFloat("Speed", direction.magnitude * sm.currentSpeed / (sm.speed * sprintModifier));

        if(sm.lifeSystem.life <= 0){
            sm.ChangeState(sm.death);
        }
        else if(sm.changeTo == "Swim" && !sm.pause.paused){
            sm.ChangeTo("");
            sm.ChangeState(sm.swimMove);
        }
        else if(Mathf.Abs(hAxis) < Mathf.Epsilon && Mathf.Abs(vAxis) < Mathf.Epsilon && !sm.pause.paused){
            sm.ChangeState(sm.idle);
        }
        else if(sm.changeTo == "Jump"){
            sm.ChangeTo("");
            sm.ChangeState(sm.jump);
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
        else if(sm.changeTo == "GHit" && !sm.pause.paused){
            sm.ChangeTo("");
            sm.ChangeState(sm.hurt);
        }
    }

    public override void UpdatePhysics()
    {
        if(!sm.pause.paused){
            sm.transform.forward = direction;
            //Vector3 newMoveVector = new Vector3(moveVector.x, sm.rb.velocity.y, moveVector.z);
            //sm.rb.velocity = newMoveVector;
            sm.character.Move(moveVector);
            sm.character.Move(Physics.gravity * Time.deltaTime);
        }
    }
}
