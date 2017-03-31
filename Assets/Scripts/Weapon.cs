using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

	public StateMachine sm;

	public AudioSource audioSource;

	public GameObject prefab;

	public bool down;
	public bool up;
	public float axis;

	public bool cool;

	public float cooldown;
	public float velocity;

	void Awake ()
	{
		sm = transform.parent.gameObject.GetComponent<StateMachine>();
		audioSource = GetComponent<AudioSource>();
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

	public Vector2 GetDirection ()
	{
		switch (sm.direction)
		{
			case Directions.North:
				return Vector2.up;

			case Directions.East:
				return Vector2.right;

			case Directions.South:
				return -Vector2.up;

			case Directions.West:
				return -Vector2.right;

			default:
				return Vector2.zero;
		}
	}
}
