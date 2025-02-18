using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E4_RangedAttackState : RangedAttackState
{
    private Enemy4 enemy;

    public E4_RangedAttackState(Entity etity, FiniteStateMachine stateMachine, string animBoolName, Transform attackPosition, D_RangedAttackState stateData, Enemy4 enemy) : base(etity, stateMachine, animBoolName, attackPosition, stateData)
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
        Debug.Log("Doing Ranged Attack");
    }

    public override void Exit()
    {
        base.Exit();
        Debug.Log("Ranged Attack Stop");
    }

    public override void FinishAttack()
    {
        base.FinishAttack();
        Debug.Log("Ranged Attack Stop");
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        Debug.Log("Checking if animation is finished: " + isAnimationFinished);

        if (isAnimationFinished)
        {
            if (isPlayerInMinAgroRange)
            {
                Debug.Log("Changing to PlayerDetectedState");
                stateMachine.ChangeState(enemy.playerDetectedState);
            }
            else
            {
                Debug.Log("Changing to LookForPlayerState");
                stateMachine.ChangeState(enemy.lookForPlayerState);
            }
        }
    }


    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public override void TriggerAttack()
    {
        base.TriggerAttack();
    }
}

