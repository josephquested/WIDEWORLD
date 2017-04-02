using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HittableActor : Hittable {

	int hitpoints;

	public override void ReceiveDamage (int damage)
	{
		// override
	}

	public override void ReceiveKnockback (Vector2 direction, float force)
	{
		GetComponent<Rigidbody2D>().AddForce(direction * force, ForceMode2D.Impulse);
	}
}
