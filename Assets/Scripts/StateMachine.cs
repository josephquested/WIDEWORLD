using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public enum States { Idle, Moving };

// 0: Idle
// 1: Moving

public class StateMachine : MonoBehaviour {

	public States state = States.Idle;

	public float speed;

	public void AttemptTransition (States newState)
	{
		if (CanTransition(newState))
		{
			state = newState;
		}
	}

	bool CanTransition (States newState)
	{
		switch (state)
		{
			case States.Idle:
				int[] idleTransitions = new int[] { 1 };
				return idleTransitions.Contains((int)newState);
				break;

			case States.Moving:
				int[] movingTransitions = new int[] { 0 };
				return movingTransitions.Contains((int)newState);
				break;

			default:
				return false;
		}
	}

	public bool CanMove ()
	{
		int[] moveableStates = new int[] { 1 };
		return moveableStates.Contains((int)state);
	}
}
