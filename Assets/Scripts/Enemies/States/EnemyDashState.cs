using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDashState : State
{
    protected D_EnemyDashState stateData;
    protected bool isDashOver;
    protected bool isPlayerInMinAgroRange;

    public EnemyDashState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_EnemyDashState stateData)
        : base(entity, stateMachine, animBoolName)
    {
        this.stateData = stateData;
    }

    public override void Enter()
    {
        base.Enter();
        isDashOver = false;

        entity.Movement?.SetVelocityX(stateData.dashSpeed * entity.Movement.FacingDirection);
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (Time.time >= startTime + stateData.dashDuration)
        {
            isDashOver = true;
        }
    }

    public override void Exit()
    {
        base.Exit();
    }
}