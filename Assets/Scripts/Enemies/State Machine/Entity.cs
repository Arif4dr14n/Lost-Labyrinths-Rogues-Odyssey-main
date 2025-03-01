using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour {
	public Movement Movement { get => movement ?? Core.GetCoreComponent(ref movement); }

	public Movement movement;

	public FiniteStateMachine stateMachine;

	public D_Entity entityData;

    public Animator anim { get; private set; }
	public AnimationToStatemachine atsm { get; private set; }
	public int lastDamageDirection { get; private set; }
	public Core Core { get; private set; }

	private float currentHealth;
	private float currentStunResistance;
	private float lastDamageTime;

	private Vector2 velocityWorkspace;

	protected bool isStunned;
	protected bool isDead;

	public virtual void Awake() {
		Core = GetComponentInChildren<Core>();

		currentHealth = entityData.maxHealth;
		currentStunResistance = entityData.stunResistance;

		anim = GetComponent<Animator>();
		atsm = GetComponent<AnimationToStatemachine>();

		stateMachine = new FiniteStateMachine();
        if (entityData == null)
        {
            Debug.LogError("EntityData is null on " + gameObject.name);
        }
        else
        {
            currentHealth = entityData.maxHealth;
        }
    }

	public virtual void Update() {
		Core.LogicUpdate();
		stateMachine.currentState.LogicUpdate();

		anim.SetFloat("yVelocity", Movement.RB.velocity.y);

		if (Time.time >= lastDamageTime + entityData.stunRecoveryTime) {
			ResetStunResistance();
		}
	}

	public virtual void FixedUpdate() {
		stateMachine.currentState.PhysicsUpdate();
	}

	public virtual void DamageHop(float velocity) {
		velocityWorkspace.Set(Movement.RB.velocity.x, velocity);
		Movement.RB.velocity = velocityWorkspace;
	}

	public virtual void ResetStunResistance() {
		isStunned = false;
		currentStunResistance = entityData.stunResistance;
	}

	public virtual void OnDrawGizmos() {
	}
}
