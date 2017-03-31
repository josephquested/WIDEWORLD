using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

	public StateMachine sm;

	public GameObject prefab;

	public bool down;
	public bool up;
	public float axis;

	public bool cool;

	public float cooldown;

	void Awake ()
	{
		sm = transform.parent.gameObject.GetComponent<StateMachine>();
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
