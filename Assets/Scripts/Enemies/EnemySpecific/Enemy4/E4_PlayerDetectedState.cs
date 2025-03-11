using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E4_PlayerDetectedState : PlayerDetectedState
{
    private Enemy4 enemy;


    public E4_PlayerDetectedState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_PlayerDetected stateData, Enemy4 enemy) : base(entity, stateMachine, animBoolName, stateData)
    {
        this.enemy = enemy;
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log("Enemy Detected Player");
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
            stateMachine.ChangeState(enemy.rangedAttackState);
            Debug.Log("Enemy Perform Ranged Attack condition 1");
        }
        else if (isPlayerInMinAgroRange)
        {
            stateMachine.ChangeState(enemy.rangedAttack2State);
            Debug.Log("Enemy Perform Ranged Attack condition 2");
        }
        else if (!isPlayerInMaxAgroRange)
        {
            stateMachine.ChangeState(enemy.lookForPlayerState);
            Debug.Log("Enemy didn't see Player");
        }
        if (EnemySenses.IsSensorTriggered("T1_Player") && !EnemySenses.IsSensorTriggered("T_Ground"))
        {
            enemy.transform.position += Vector3.up;
            Debug.Log("Enemy moves up 1 tile");
        }
        if (EnemySenses.IsSensorTriggered("B1_Player") && !EnemySenses.IsSensorTriggered("B_Ground"))
        {
            enemy.transform.position += Vector3.down;
            Debug.Log("Enemy moves down 1 tile");
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
