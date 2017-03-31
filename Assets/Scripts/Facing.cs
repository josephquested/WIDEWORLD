using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Facing : MonoBehaviour {

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
		UpdateAnimator();
		UpdateDirection();
	}

	void UpdateDirection ()
	{
		sm.AttemptTurn(GetFacingDirection());
	}

	Directions GetFacingDirection ()
	{
		if (vertical == 1)
		{
			return Directions.North;
		}
		if (vertical == -1)
		{
			return Directions.South;
		}
		if (horizontal == 1)
		{
			return Directions.East;
		}
		if (horizontal == -1)
		{
			return Directions.West;
		}
		else
		{
			return sm.direction;
		}
	}

	void UpdateAnimator ()
	{
		animator.SetInteger("direction", (int)sm.direction);
	}

	public void ReceiveInput (float h, float v)
	{
		horizontal = h;
		vertical = v;
	}
}
