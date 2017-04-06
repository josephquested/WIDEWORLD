using System.Collections;
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

	void Thrust ()
	{
		rb.AddForce(GetDirection() * thrust, ForceMode2D.Impulse);
	}
}
