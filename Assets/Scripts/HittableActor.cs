using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HittableActor : Hittable {

	Status status;

	void Start ()
	{
		status = GetComponent<Status>();
	}

	public override void ReceiveDamage (int damage)
	{
		status.ReceiveDamage(damage);
	}

	public override void ReceiveKnockback (Vector2 direction, float force)
	{
		GetComponent<Rigidbody2D>().AddForce(direction * force, ForceMode2D.Impulse);
	}
}
