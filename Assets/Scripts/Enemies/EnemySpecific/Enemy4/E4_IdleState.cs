using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E4_IdleState : IdleState
{
    private Enemy4 enemy;
    public E4_IdleState(Entity etity, FiniteStateMachine stateMachine, string animBoolName, D_IdleState stateData, Enemy4 enemy) : base(etity, stateMachine, animBoolName, stateData)
    {
        this.enemy = enemy;
    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log("Enemy Idle State Start");
    }

    public override void Exit()
    {
        base.Exit();
        Debug.Log("Enemy Idle State Ended");
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (isPlayerInMinAgroRange)
        {
            stateMachine.ChangeState(enemy.playerDetectedState);
        }
        else if (isIdleTimeOver)
        {
            stateMachine.ChangeState(enemy.moveState);
        }
        else
        {
            if (EnemySenses.IsSensorTriggered("T_Ground"))
            {
                enemy.transform.position += Vector3.down;
                Debug.Log("Enemy moves down 1 tile");
            }
            else if (EnemySenses.IsSensorTriggered("B_Ground"))
            {
                enemy.transform.position += Vector3.up;
                Debug.Log("Enemy moves up 1 tile");
            }
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
