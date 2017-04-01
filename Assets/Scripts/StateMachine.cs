using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public enum States { Idle, Moving, Attacking };
public enum Directions { North, East, South, West };

// 0: Idle
// 1: Moving

public class StateMachine : MonoBehaviour {

	public States state = States.Idle;
	public Directions direction = Directions.South;

	public float speed;
	public bool dirLock;

	public bool AttemptTransition (States newState)
	{
		if (CanTransition(newState))
		{
			state = newState;
			return true;
		}
		else
		{
			return false;
		}
	}

	public void AttemptTurn (Directions newDirection)
	{
		if (!dirLock)
		{
			direction = newDirection;
		}
	}

	public bool CanTransition (States newState)
	{
		switch (state)
		{
			case States.Idle:
				return new int[] { 1, 2 }.Contains((int)newState);

			case States.Moving:
				return new int[] { 0, 2 }.Contains((int)newState);

			case States.Attacking:
				return new int[] { 0, 1 }.Contains((int)newState);

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
