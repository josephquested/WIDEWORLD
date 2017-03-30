using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour {

	Movement movement;

	void Start ()
	{
		movement = GetComponent<Movement>();
	}

	void Update ()
	{
		UpdateMovement();
	}

	void UpdateMovement ()
	{
		movement.ReceiveInput(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
	}
}
