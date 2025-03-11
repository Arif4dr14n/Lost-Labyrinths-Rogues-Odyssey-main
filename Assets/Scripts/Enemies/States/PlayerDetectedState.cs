using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetectedState : State {
	protected Movement Movement { get => movement ?? core.GetCoreComponent(ref movement); }

	private Movement movement;
    protected EnemySenses EnemySenses { get => enemySenses ?? core.GetCoreComponent(ref enemySenses); }

    private EnemySenses enemySenses;

    protected D_PlayerDetected stateData;

	protected bool isPlayerInMinAgroRange;
	protected bool isPlayerInMaxAgroRange;
	protected bool performLongRangeAction;
	protected bool performCloseRangeAction;
	protected bool isDetectingLedge;

	public PlayerDetectedState(Entity etity, FiniteStateMachine stateMachine, string animBoolName, D_PlayerDetected stateData) : base(etity, stateMachine, animBoolName) {
		this.stateData = stateData;
	}

	public override void DoChecks() {
		base.DoChecks();

		isPlayerInMinAgroRange = EnemySenses.IsSensorTriggered("M2_Player");
		isPlayerInMaxAgroRange = EnemySenses.IsSensorTriggered("M3_Player");
		isDetectingLedge = EnemySenses.IsSensorTriggered("B1_Ground");
		performCloseRangeAction = EnemySenses.IsSensorTriggered("M1_Player");
    }

	public override void Enter() {
		base.Enter();

		performLongRangeAction = false;
		Movement?.SetVelocityX(0f);
	}

	public override void Exit() {
		base.Exit();
	}

	public override void LogicUpdate() {
		base.LogicUpdate();

		Movement?.SetVelocityX(0f);

		if (Time.time >= startTime + stateData.longRangeActionTime) {
			performLongRangeAction = true;
		}
	}

	public override void PhysicsUpdate() {
		base.PhysicsUpdate();
	}
}
