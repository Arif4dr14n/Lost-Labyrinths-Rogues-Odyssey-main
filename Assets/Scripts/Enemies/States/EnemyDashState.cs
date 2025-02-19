using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDashState : State
{
    protected D_EnemyDashState stateData;
    protected bool isDashOver;
<<<<<<< Updated upstream
    protected bool isPlayerInMinAgroRange;
=======
    protected Vector2 dashStartPosition;
    protected BoxCollider2D enemyCollider;
    protected int dashDirection;
>>>>>>> Stashed changes

    private Movement Movement { get => movement ?? core.GetCoreComponent(ref movement); }
    private CollisionSenses CollisionSenses { get => collisionSenses ?? core.GetCoreComponent(ref collisionSenses); }

    private Movement movement;
    private CollisionSenses collisionSenses;

    protected bool isDetectingLedge;
    protected bool isDetectingWall;

    public EnemyDashState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_EnemyDashState stateData): base(entity, stateMachine, animBoolName)
    {
        this.stateData = stateData;
    }

    public override void DoChecks()
    {
        base.DoChecks();
        isDetectingLedge = CollisionSenses.LedgeVertical;
        isDetectingWall = CollisionSenses.WallFront;
    }
    public override void Enter()
    {
        base.Enter();
        Debug.Log("Dash Melakukan dash");
        isDashOver = false;
<<<<<<< Updated upstream
=======
        dashStartPosition = entity.transform.position;

        if (!stateData.dashTowardPlayer)
        {
            Movement.Flip();
            Debug.Log("Dash menjauh dari player");
        }

        dashDirection = Movement.FacingDirection;

        enemyCollider = entity.GetComponent<BoxCollider2D>();
        if (enemyCollider != null)
        {
            enemyCollider.enabled = false;
        }
        if (isDetectingWall)
        {
            Movement.Flip();
            Debug.Log("Mendeteksi tembok, berbalik arah");
        }
>>>>>>> Stashed changes

        Movement?.SetVelocityX(stateData.dashSpeed * dashDirection);
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
<<<<<<< Updated upstream
        if (Time.time >= startTime + stateData.dashDuration)
=======
        DoChecks();
        if (!isDetectingLedge)
        {
            isDashOver = true;
            Debug.Log("Dash berhenti karena tidak mendeteksi ledge");
        }

        if (Mathf.Abs(entity.transform.position.x - dashStartPosition.x) >= stateData.dashDistance)
>>>>>>> Stashed changes
        {
            isDashOver = true;
            Debug.Log("Dash selesai");
        }

    }

    public override void Exit()
    {
        base.Exit();
    }
}