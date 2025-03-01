using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E5_EnemyDashState : EnemyDashState
{
    private Enemy5 enemy;

    public E5_EnemyDashState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_EnemyDashState stateData, Enemy5 enemy)
        : base(entity, stateMachine, animBoolName, stateData)
    {
        this.enemy = enemy;
    }

    public override void Enter()
    {
        base.Enter();

        enemy.BC.enabled = false;
    }

    public override void Exit()
    {
        base.Exit();

        enemy.BC.enabled = true;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (isDashOver)
        {
            stateMachine.ChangeState(enemy.moveState);
        }
    }
}