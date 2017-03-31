using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour {

	Movement movement;
	Facing facing;

	void Start ()
	{
		movement = GetComponent<Movement>();
		facing = GetComponent<Facing>();
	}

	void Update ()
	{
		UpdateFacing();
		UpdateMovement();
	}

	void UpdateMovement ()
	{
		movement.ReceiveInput(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
	}

	void UpdateFacing ()
	{
		facing.ReceiveInput(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
	}
}
