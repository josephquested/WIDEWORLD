using System.Collections;
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
		if (sm.state == States.Idle)
		{
			print("I am idle");
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
