using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAttackState : AttackState
{
    protected D_RangedAttackState stateData;

    protected GameObject projectile;
    protected Projectile projectileScript;

    public RangedAttackState(Entity etity, FiniteStateMachine stateMachine, string animBoolName, Transform attackPosition, D_RangedAttackState stateData) : base(etity, stateMachine, animBoolName, attackPosition)
    {
        this.stateData = stateData;
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

    public override void FinishAttack()
    {
        base.FinishAttack();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public override void TriggerAttack()
    {
        base.TriggerAttack();

        Debug.Log("TriggerAttack called!");

        if (stateData.projectile == null)
        {
            Debug.LogError("Projectile Prefab is NULL in stateData!");
            return;
        }

        projectile = GameObject.Instantiate(stateData.projectile, attackPosition.position, attackPosition.rotation);
        Debug.Log("Projectile Instantiated!");

        projectileScript = projectile.GetComponent<Projectile>();

        if (projectileScript == null)
        {
            Debug.LogError("Projectile script is missing on the instantiated projectile!");
            return;
        }

        projectileScript.FireProjectile(stateData.projectileSpeed, stateData.projectileTravelDistance, stateData.projectileDamage);
        Debug.Log("Projectile Fired!");
    }


}
