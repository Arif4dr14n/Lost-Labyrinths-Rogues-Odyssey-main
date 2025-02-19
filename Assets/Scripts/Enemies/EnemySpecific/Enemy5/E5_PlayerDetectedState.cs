using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E5_PlayerDetectedState : PlayerDetectedState
{
    private Enemy5 enemy;
    private System.Random random;

    public E5_PlayerDetectedState(Entity etity, FiniteStateMachine stateMachine, string animBoolName, D_PlayerDetected stateData, Enemy5 enemy) : base(etity, stateMachine, animBoolName, stateData)
    {
        this.enemy = enemy;
        this.random = new System.Random();
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log("Enemy detecting player");
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (performCloseRangeAction)
        {
            Debug.Log("Enemy Dash");
            stateMachine.ChangeState(enemy.enemyDashState);
        }
        else if (performLongRangeAction)
        {
            stateMachine.ChangeState(enemy.rangedAttackState);
            Debug.Log("Melakukan Ranged Attack");

        }
        else if (!isPlayerInMaxAgroRange)
        {
            stateMachine.ChangeState(enemy.lookForPlayerState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
