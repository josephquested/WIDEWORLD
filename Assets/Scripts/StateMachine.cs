using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public enum States { Idle, Moving };

public class StateMachine : MonoBehaviour {

	public States state = States.Idle;

	public bool canMove = true;
	public float speed;

	void Start ()
	{
		print(CanTransition(States.Moving));
	}

	public bool CanTransition (States newState)
	{
		switch (state)
		{
			case States.Idle:
				int[] idleTransitions = new int[] { 1 };
				return idleTransitions.Contains((int)newState);
				break;

			default:
				return false;
		}
	}
}
