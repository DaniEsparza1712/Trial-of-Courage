using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BasicEnemyMachine : StateMachine
{
    public LayerMask playerMask;
    public LayerMask enemyMask;
    public NavMeshAgent navAgent;
    [HideInInspector]
    public BasicIdle basicIdle;
    [HideInInspector]
    public BasicMove basicMove;
    [HideInInspector]
    public BasicGHit basicGHit;
    [HideInInspector]
    public BasicDeath basicDeath;
    [HideInInspector]
    public BasicAttack basicAttack;
    [HideInInspector]
    public BasicDizzy basicDizzy;
    public GameObject target;
    public override void Start() {
        base.Start();

        basicIdle = new BasicIdle(this);
        basicMove = new BasicMove(this);
        basicGHit = new BasicGHit(this);
        basicDeath = new BasicDeath(this);
        basicAttack = new BasicAttack(this);
        basicDizzy = new BasicDizzy(this);

        currentState = basicIdle;
        basicIdle.Enter();
    }
   
}
