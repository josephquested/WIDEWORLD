using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitProjectile : Hit {

	public int damage;

	public float knockback;

	public override void OnHittableEnter (Hittable hittable)
	{
		hittable.ReceiveDamage(damage);
		hittable.ReceiveKnockback(attackDirection, knockback);
		Destroy(gameObject);
	}
}
