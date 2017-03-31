using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum States { Idle, Moving };

public class StateMachine : MonoBehaviour {

	public States state = States.Idle;
	public bool canMove = true;
	public float speed;

	// public bool CanTransition (States newState)
	// {
	// 	switch (state)
	// 	{
	// 		case States.Idle:
	// 			// declare an IdleTransitions enum or array
	// 			// if newState is in IdleTransition enum/array, return true,
	// 			// else, return false
	// 			break;
	// 	}
	// }
}
