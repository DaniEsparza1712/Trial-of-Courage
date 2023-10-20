using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwimMove : State
{
    public PlayerMachine sm;
    public SwimMove(PlayerMachine pm) : base(pm){
        sm = pm;
    }
    private Vector3 direction;
    private Vector3 moveVector;
    private RaycastHit hit;

    public override void Enter()
    {
        sm.animator.SetTrigger("SwimMove");
        sm.character.Move(Vector3.zero);
        sm.currentSpeed = sm.speed;
    }

    public override void UpdateLogic()
    {
        //if(Physics.Raycast(sm.transform.position, Vector3.down, out hit,0.3f)){
        if(Physics.CapsuleCast(sm.transform.position + Vector3.up * 0.13f, sm.transform.position + Vector3.up * 0.13f, sm.character.radius, Vector3.down, out hit, 0.2f, sm.ignorePlayer)){
            if(hit.collider.gameObject.CompareTag("Floor")){
                sm.ChangeTo("Move");
            }
        }

        float hAxis = Input.GetAxis("Horizontal");
        float vAxis = Input.GetAxis("Vertical");
        
        direction = new Vector3(hAxis, 0, vAxis);
        moveVector = direction * sm.currentSpeed * Time.deltaTime;

        if(sm.lifeSystem.life <= 0){
            sm.ChangeState(sm.death);
        }
        else if(sm.changeTo == "Move"){
            sm.ChangeTo("");
            sm.ChangeState(sm.move);
        }
        else if(Mathf.Abs(hAxis) < Mathf.Epsilon && Mathf.Abs(vAxis) < Mathf.Epsilon && !sm.pause.paused){
            sm.ChangeState(sm.swimIdle);
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
            sm.character.Move(moveVector);
        }
        //if(Physics.BoxCast(sm.transform.position, new Vector3(0.4f, 0.1f, 0.4f), Vector3.down, out hit, Quaternion.identity, 0.1f, sm.ignorePlayer)){
    }
}
