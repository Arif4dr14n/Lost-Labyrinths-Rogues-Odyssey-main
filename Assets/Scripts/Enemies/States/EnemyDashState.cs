using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDashState : State
{
    protected D_EnemyDashState stateData;
    protected bool isDashOver;
    protected bool isPlayerInMinAgroRange;
    protected Vector2 dashStartPosition;
    protected BoxCollider2D enemyCollider;
    protected int dashDirection;

    protected Movement Movement { get => movement ?? core.GetCoreComponent(ref movement); }
    private Movement movement;
    protected EnemySenses EnemySenses { get => enemySenses ?? core.GetCoreComponent(ref enemySenses); }
    private EnemySenses enemySenses;

    public EnemyDashState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_EnemyDashState stateData): base(entity, stateMachine, animBoolName)
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
        Debug.Log("Enemy Melakukan dash");
        isDashOver = false;
        dashStartPosition = entity.transform.position;

        entity.gameObject.layer = LayerMask.NameToLayer("EnemyDash");

        if (!stateData.dashTowardPlayer)
        {
            Movement.Flip();
            Debug.Log("Dash menjauh dari player");
        }

        dashDirection = Movement.FacingDirection;

        if (EnemySenses.IsSensorTriggered("M1_Ground"))
        {
            Movement.Flip();
            Debug.Log("Mendeteksi tembok, berbalik arah");
        }

        Movement?.SetVelocityX(stateData.dashSpeed * dashDirection);
    }

    public override void Exit()
    {
        base.Exit();
        entity.gameObject.layer = LayerMask.NameToLayer("Damageable");
        isDashOver = true;
        Debug.Log("Dash selesai, musuh kembali bisa terkena hit");
    }


    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (Time.time >= startTime + stateData.dashDuration)
        {
            isDashOver = true;
            Debug.Log("Dash selesai karena durasi habis");
        }
        if (Mathf.Abs(entity.transform.position.x - dashStartPosition.x) >= stateData.dashDistance)
        {
            isDashOver = true;
            Debug.Log("Dash selesai karena sudah mencapai jarak maksimal");
        }
        if (EnemySenses.IsSensorTriggered("M1_Ground"))
        {
            isDashOver = true;
            Debug.Log("Dash berhenti karena menabrak tembok");
        }
    }

}