﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState : State {
	protected Movement Movement { get => movement ?? core.GetCoreComponent(ref movement); }
	protected EnemySenses EnemySenses { get => enemySenses ?? core.GetCoreComponent(ref enemySenses); }

	private Movement movement;
	private EnemySenses enemySenses;

	protected D_MoveState stateData;

	protected bool isDetectingWall;
	protected bool isDetectingLedge;
	protected bool isPlayerInMinAgroRange;

	public MoveState(Entity etity, FiniteStateMachine stateMachine, string animBoolName, D_MoveState stateData) : base(etity, stateMachine, animBoolName) {
		this.stateData = stateData;
	}

	public override void DoChecks() {
		base.DoChecks();

        isDetectingLedge = EnemySenses.IsSensorTriggered("B1_Ground");
        isDetectingWall = EnemySenses.IsSensorTriggered("M1_Ground");
        isPlayerInMinAgroRange = EnemySenses.IsSensorTriggered("M2_Player");
    }

	public override void Enter() {
		base.Enter();
		Movement?.SetVelocityX(stateData.movementSpeed * Movement.FacingDirection);

	}

	public override void Exit() {
		base.Exit();
	}

	public override void LogicUpdate() {
		base.LogicUpdate();
		Movement?.SetVelocityX(stateData.movementSpeed * Movement.FacingDirection);
	}

	public override void PhysicsUpdate() {
		base.PhysicsUpdate();
	}
}
