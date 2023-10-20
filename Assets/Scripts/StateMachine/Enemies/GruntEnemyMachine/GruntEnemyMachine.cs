using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GruntEnemyMachine : StateMachine
{
    public LayerMask playerMask;
    public NavMeshAgent navAgent;
    public int hitResistance;
    private int hitCounter;
    public int GetHitCounter => hitCounter;
    public GameObject target;
    [HideInInspector]
    public GruntIdle gruntIdle;
    [HideInInspector]
    public GruntMove gruntMove; 
    [HideInInspector]
    public GruntScavenge gruntScavenge;
    [HideInInspector]
    public GruntAttack gruntAttack;
    [HideInInspector]
    public GruntGetHit gruntGHit;
    [HideInInspector]
    public GruntParry gruntParry;
    [HideInInspector]
    public GruntDeath gruntDeath;
    public override void Start() {
        base.Start();
        hitCounter = 0;

        gruntIdle = new GruntIdle(this);
        gruntMove = new GruntMove(this);
        gruntScavenge = new GruntScavenge(this);
        gruntAttack = new GruntAttack(this);
        gruntGHit = new GruntGetHit(this);
        gruntParry = new GruntParry(this);
        gruntDeath = new GruntDeath(this);

        currentState = gruntIdle;
        gruntIdle.Enter();
    }

    public void AddHit(){
        hitCounter++;
    }
    public void ResetHitCounter(){
        hitCounter = 0;
    }
}
