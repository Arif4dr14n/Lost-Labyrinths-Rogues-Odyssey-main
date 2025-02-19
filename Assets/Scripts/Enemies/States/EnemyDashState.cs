using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDashState : State
{
    protected D_EnemyDashState stateData;
    protected bool isDashOver;
    protected Vector2 dashStartPosition;
    protected BoxCollider2D enemyCollider;

    public EnemyDashState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_EnemyDashState stateData)
        : base(entity, stateMachine, animBoolName)
    {
        this.stateData = stateData;
    }

    public override void Enter()
    {
        base.Enter();
        isDashOver = false;
        dashStartPosition = entity.transform.position;

        enemyCollider = entity.GetComponent<BoxCollider2D>();
        if (enemyCollider != null)
        {
            enemyCollider.enabled = false;
        }

        entity.Movement?.SetVelocityX(stateData.dashSpeed * entity.Movement.FacingDirection);
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (Mathf.Abs(entity.transform.position.x - dashStartPosition.x) >= stateData.dashDistance)
        {
            isDashOver = true;
        }
    }

    public override void Exit()
    {
        base.Exit();

        if (enemyCollider != null)
        {
            enemyCollider.enabled = true;
        }
    }

    public bool IsDashOver()
    {
        return isDashOver;
    }
}
