﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : WeaponMelee {

	Rigidbody2D rb;

	void Start ()
	{
		rb = transform.parent.GetComponent<Rigidbody2D>();
	}

	public override void OnDown ()
	{
		if (down)
		{
			if (sm.AttemptTransition(States.Attacking))
			{
				Fire();
				Thrust();
			}
		}
	}

	void Fire ()
	{
		GameObject blade = Instantiate(prefab, transform.position, transform.rotation);
		blade.GetComponent<Blade>().SetParent(transform.parent);
		PlaceMeleePrefab(blade);
		audioSource.Play();
	}

	void Thrust ()
	{
		rb.AddForce(GetDirection() * thrust, ForceMode2D.Impulse);
	}
}
