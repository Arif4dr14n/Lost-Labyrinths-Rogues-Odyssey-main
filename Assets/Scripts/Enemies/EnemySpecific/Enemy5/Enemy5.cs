using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy5 : Entity
{
    public BoxCollider2D BC { get; private set; }
    public E5_MoveState moveState { get; private set; }
    public E5_IdleState idleState { get; private set; }
    public E5_PlayerDetectedState playerDetectedState { get; private set; }
    public E5_LookForPlayerState lookForPlayerState { get; private set; }
    public E5_StunState stunState { get; private set; }
    public E5_DeadState deadState { get; private set; }
    public E5_ChargeState chargeState { get; private set; }
    public E5_RangedAttackState rangedAttackState { get; private set; }
    public E5_EnemyDashState enemyDashState { get; private set; }


    [SerializeField]
    private D_MoveState moveStateData;
    [SerializeField]
    private D_IdleState idleStateData;
    [SerializeField]
    private D_PlayerDetected playerDetectedStateData;
    [SerializeField]
    private D_LookForPlayer lookForPlayerStateData;
    [SerializeField]
    private D_StunState stunStateData;
    [SerializeField]
    private D_DeadState deadStateData;
    [SerializeField]
    private D_ChargeState chargeStateData;
    [SerializeField]
    private D_RangedAttackState rangedAttackStateData;
    [SerializeField]
    private D_EnemyDashState enemyDashStateData;

    [SerializeField]
    private Transform meleeAttackPosition;
    [SerializeField]
    private Transform rangedAttackPosition;

    public override void Awake()
    {
        base.Awake();
        BC = GetComponentInParent<BoxCollider2D>();
        moveState = new E5_MoveState(this, stateMachine, "move", moveStateData, this);
        idleState = new E5_IdleState(this, stateMachine, "idle", idleStateData, this);
        playerDetectedState = new E5_PlayerDetectedState(this, stateMachine, "playerDetected", playerDetectedStateData, this);
        lookForPlayerState = new E5_LookForPlayerState(this, stateMachine, "lookForPlayer", lookForPlayerStateData, this);
        stunState = new E5_StunState(this, stateMachine, "stun", stunStateData, this);
        deadState = new E5_DeadState(this, stateMachine, "dead", deadStateData, this);
        chargeState = new E5_ChargeState(this, stateMachine, "charge", chargeStateData, this);
        rangedAttackState = new E5_RangedAttackState(this, stateMachine, "rangedAttack", rangedAttackPosition, rangedAttackStateData, this);
        enemyDashState = new E5_EnemyDashState(this, stateMachine, "dash", enemyDashStateData, this);
    }

    private void Start()
    {
        stateMachine.Initialize(moveState);
    }

    public override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
    }
}
