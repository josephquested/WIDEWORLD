using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

	StateMachine sm;

	public GameObject prefab;

	bool down;
	bool up;

	float axis;

	void Awake ()
	{
		sm = GetComponent<StateMachine>();
	}

	void Update ()
	{
		OnDown();
		OnUp();
		OnAxis();
	}

	public virtual void OnDown ()
	{
		// override
	}

	public virtual void OnUp ()
	{
		// override
	}

	public virtual void OnAxis ()
	{
		// override
	}

	public void ReceiveInputs (bool _down, bool _up, float _axis)
	{
		down = _down;
		up = _up;
		axis = _axis;
	}
}
