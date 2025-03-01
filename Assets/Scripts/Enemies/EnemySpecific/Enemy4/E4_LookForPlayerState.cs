using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class E4_LookForPlayerState : LookForPlayerState
{
    private Enemy4 enemy;

    public E4_LookForPlayerState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_LookForPlayer stateData, Enemy4 enemy) : base(entity, stateMachine, animBoolName, stateData)
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
        Debug.Log("Enemy Look For Player State Start");
    }

    public override void Exit()
    {
        Debug.Log("Enemy Look For Player State Stop");
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (isPlayerInMinAgroRange)
        {
            stateMachine.ChangeState(enemy.playerDetectedState);
        }
        else if (isAllTurnsTimeDone)
        {
            stateMachine.ChangeState(enemy.moveState);
        }
        else if (EnemySenses.IsSensorTriggered("T1_Player"))
        {
            if (!EnemySenses.IsSensorTriggered("T_Ground"))
            {
                enemy.transform.position += Vector3.up;
                Debug.Log("Enemy moves up 1 tile");
            }
        }
        else if (EnemySenses.IsSensorTriggered("B1_Player"))
        {
            if (!EnemySenses.IsSensorTriggered("B_Ground"))
            {
                enemy.transform.position += Vector3.down;
                Debug.Log("Enemy moves down 1 tile");
            }
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
