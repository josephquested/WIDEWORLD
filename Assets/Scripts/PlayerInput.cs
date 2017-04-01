using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour {

	StateMachine sm;

	Movement movement;
	
	Facing facing;

	public Weapon weapon1;
	public Weapon weapon2;

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
		UpdateWeapon(weapon1, 1);
		UpdateWeapon(weapon2, 2);
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

	void UpdateWeapon (Weapon weapon, int which)
	{
		weapon.ReceiveInputs(
			Input.GetButtonDown("Fire" + which.ToString()),
			Input.GetButtonUp("Fire" + which.ToString()),
			Input.GetAxis("Fire" + which.ToString())
		);
	}
}
