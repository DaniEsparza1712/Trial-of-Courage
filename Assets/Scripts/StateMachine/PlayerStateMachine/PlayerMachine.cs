using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerMachine : StateMachine
{
    public MagicSystem magicSystem;
    public LayerMask ignorePlayer;
    public Rigidbody rb;
    [HideInInspector]
    public IdleState idle;
    [HideInInspector]
    public MoveState move;
    [HideInInspector]
    public AttackState attack;
    [HideInInspector]
    public HurtState hurt;
    [HideInInspector]
    public DeathState death;
    [HideInInspector]
    public SecondaryAttackState secAttack;
    [HideInInspector]
    public SecondaryAttackBState secAttackB;
    [HideInInspector]
    public TalkState talk;
    [HideInInspector]
    public KissState kiss;
    [HideInInspector]
    public SwimIdle swimIdle;
    [HideInInspector]
    public SwimMove swimMove;
    [HideInInspector]
    public JumpState jump;

    public WeaponManager weaponManager;
    public SecondaryWeaponManager secWeaponManager;
    public DialogueDetector dialogueDetector;
    public Pause pause;

    [HideInInspector]
    public float currentSpeed = 0;
    [HideInInspector]
    public Vector3 baseMoveVector;
    public KissManager kissManager;


    public override void Start()
    {
        base.Start();
        Physics.IgnoreLayerCollision(8, 7);
        Physics.IgnoreLayerCollision(8, 6);

        idle = new IdleState(this);
        move = new MoveState(this);
        attack = new AttackState(this);
        hurt = new HurtState(this);
        death = new DeathState(this);
        secAttack = new SecondaryAttackState(this);
        secAttackB = new SecondaryAttackBState(this);
        talk = new TalkState(this);
        kiss = new KissState(this);
        swimIdle = new SwimIdle(this);
        swimMove = new SwimMove(this);
        jump = new JumpState(this);

        currentState = idle;
        currentState.Enter();
    }
}
