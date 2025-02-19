using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E3_PlayerDetectedState : PlayerDetectedState
{
    private Enemy3 enemy;
    private System.Random random;

    public E3_PlayerDetectedState(Entity etity, FiniteStateMachine stateMachine, string animBoolName, D_PlayerDetected stateData, Enemy3 enemy) : base(etity, stateMachine, animBoolName, stateData)
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
            stateMachine.ChangeState(enemy.meleeAttackState);
        }
        else if (performLongRangeAction)
        {
            if (random.Next(2) == 0)
            {
                stateMachine.ChangeState(enemy.rangedAttackState);
                Debug.Log("Melakukan Ranged Attack");
            }
            else
            {
                stateMachine.ChangeState(enemy.chargeState);
                Debug.Log("Melakukan Charge");
            }
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
