using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy4 : Entity
{
    public E4_MoveState moveState { get; private set; }
    public E4_IdleState idleState { get; private set; }
    public E4_PlayerDetectedState playerDetectedState { get; private set; }
    public E4_LookForPlayerState lookForPlayerState { get; private set; }
    public E4_StunState stunState { get; private set; }
    public E4_DeadState deadState { get; private set; }
    public E4_RangedAttackState rangedAttackState { get; private set; }
    public E4_RangedAttackState2 rangedAttack2State { get; private set; }

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
    private D_RangedAttackState rangedAttackStateData;
    [SerializeField]
    private D_RangedAttackState rangedAttackState2Data;

    [SerializeField]
    private Transform rangedAttackPosition;
    [SerializeField]
    private Transform rangedAttack2Position;

    public override void Awake()
    {
        base.Awake();

        moveState = new E4_MoveState(this, stateMachine, "move", moveStateData, this);
        idleState = new E4_IdleState(this, stateMachine, "idle", idleStateData, this);
        playerDetectedState = new E4_PlayerDetectedState(this, stateMachine, "playerDetected", playerDetectedStateData, this);
        lookForPlayerState = new E4_LookForPlayerState(this, stateMachine, "lookForPlayer", lookForPlayerStateData, this);
        stunState = new E4_StunState(this, stateMachine, "stun", stunStateData, this);
        deadState = new E4_DeadState(this, stateMachine, "dead", deadStateData, this);
        rangedAttackState = new E4_RangedAttackState(this, stateMachine, "rangedAttack", rangedAttackPosition, rangedAttackStateData, this);
        rangedAttack2State = new E4_RangedAttackState2 (this, stateMachine, "rangedAttack2", rangedAttack2Position, rangedAttackState2Data, this);

    }

    private void Start()
    {
        stateMachine.Initialize(moveState);
        Debug.Log("Enemy Spawned");
    }

    public override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
    }
    public D_MoveState GetMoveStateData()
    {
        return moveStateData;
    }

}