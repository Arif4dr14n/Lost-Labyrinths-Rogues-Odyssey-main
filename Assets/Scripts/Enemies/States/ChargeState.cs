using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeState : State {
	private Movement Movement { get => movement ?? core.GetCoreComponent(ref movement); }

	private Movement movement;
    private EnemySenses EnemySenses { get => enemySenses ?? core.GetCoreComponent(ref enemySenses); }

    private EnemySenses enemySenses;


    protected D_ChargeState stateData;

	protected bool isPlayerInMinAgroRange;
	protected bool isDetectingLedge;
	protected bool isDetectingWall;
	protected bool isChargeTimeOver;
	protected bool performCloseRangeAction;
	protected bool isJumpableGap;
	protected bool isJumpableObstacle;

    public ChargeState(Entity etity, FiniteStateMachine stateMachine, string animBoolName, D_ChargeState stateData) : base(etity, stateMachine, animBoolName) {
		this.stateData = stateData;
	}

	public override void DoChecks() {
		base.DoChecks();

		isPlayerInMinAgroRange = EnemySenses.IsSensorTriggered("M2_Player");
        isDetectingLedge = EnemySenses.IsSensorTriggered("B1_Ground");
        isDetectingWall = EnemySenses.IsSensorTriggered("M1_Ground");
		isJumpableGap = EnemySenses.IsSensorTriggered("B2_Ground");
        isJumpableObstacle = EnemySenses.IsSensorTriggered("T1_Ground");
        performCloseRangeAction = EnemySenses.IsSensorTriggered("M1_Player");
    }

	public override void Enter() {
		base.Enter();

		isChargeTimeOver = false;
		Movement?.SetVelocityX(stateData.chargeSpeed * Movement.FacingDirection);
	}

	public override void Exit() {
		base.Exit();
	}

	public override void LogicUpdate() {
		base.LogicUpdate();

		Movement?.SetVelocityX(stateData.chargeSpeed * Movement.FacingDirection);

		if (Time.time >= startTime + stateData.chargeTime) {
			isChargeTimeOver = true;
		}
	}

	public override void PhysicsUpdate() {
		base.PhysicsUpdate();
	}
    public virtual void Jump()
    {
        Vector2 jumpDirection = new Vector2(Movement.FacingDirection, 1).normalized;
        Movement.SetVelocity(stateData.jumpForce, jumpDirection);
        Debug.Log($"Jump Called - stateData.jumpForce: {stateData.jumpForce}");

    }



}
