using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour {

	Movement movement;
	StateMachine sm;
	Facing facing;

	void Start ()
	{
		sm = GetComponent<StateMachine>();
		movement = GetComponent<Movement>();
		facing = GetComponent<Facing>();
	}

	void Update ()
	{
		UpdateFacing();
		UpdateMovement();
		UpdateDirLock();
	}

	void UpdateDirLock ()
	{
		sm.dirLock = Input.GetButton("DirLock");
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
