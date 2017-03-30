using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

	StateMachine sm;
	Rigidbody rb;

	float horizontal;
	float vertical;

	void Start ()
	{
		sm = GetComponent<StateMachine>();
		rb = GetComponent<Rigidbody>();
	}

	void Update ()
	{
		UpdateMovement();
	}

	void UpdateMovement ()
	{
		if (sm.canMove)
		{
			Move();
		}
	}

	void Move ()
	{
		Vector3 force = new Vector3(horizontal, 0, vertical) * sm.speed;
		rb.AddForce(force);
	}

	public void ReceiveInput (float h, float v)
	{
		horizontal = h;
		vertical = v;
	}
}
