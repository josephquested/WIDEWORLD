using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

	StateMachine sm;

	Animator animator;

	public float speed;

	float horizontal;
	float vertical;

	void Start ()
	{
		sm = GetComponent<StateMachine>();
		animator = GetComponent<Animator>();
	}

	void Update ()
	{
		UpdateState();
		UpdateMovement();
		UpdateAnimator();
	}

	void UpdateState ()
	{
		if (horizontal != 0 || vertical != 0)
		{
			sm.AttemptTransition(States.Moving);
		}
		else
		{
			sm.AttemptTransition(States.Idle);
		}
	}

	void UpdateMovement ()
	{
		if (sm.CanMove())
		{
			Move(GetMovementVector());
		}
	}

	void Move (Vector2 movement)
	{
		transform.Translate(movement * speed);
	}

	Vector2 GetMovementVector ()
	{
		if (vertical != 0)
		{
			return new Vector2(0, vertical);
		}
		else
		{
			return new Vector2(horizontal, 0);
		}
	}

	void UpdateAnimator ()
	{
		animator.SetBool("moving", sm.state == States.Moving);
	}

	public void ReceiveInput (float h, float v)
	{
		horizontal = h;
		vertical = v;
	}
}
