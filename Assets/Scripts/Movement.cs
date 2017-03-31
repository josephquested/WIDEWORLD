﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

	StateMachine sm;
	Animator animator;

	float horizontal;
	float vertical;

	void Start ()
	{
		sm = GetComponent<StateMachine>();
		animator = GetComponent<Animator>();
	}

	void Update ()
	{
		UpdateMovement();
		UpdateAnimator();
	}

	void UpdateMovement ()
	{
		if (sm.canMove)
		{
			Move(GetMovementVector());
		}
	}

	void Move (Vector2 movement)
	{
		transform.Translate(movement * sm.speed);
	}

	Vector2 GetMovementVector ()
	{
		if (horizontal != 0)
		{
			return new Vector2(horizontal, 0);
		}
		else
		{
			return new Vector2(0, vertical);
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
