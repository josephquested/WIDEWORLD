using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum States { Idle, Moving };

public class StateMachine : MonoBehaviour {

	public States state = States.Idle;
	public bool canMove = true;
	public float speed;
}
