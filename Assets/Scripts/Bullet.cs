using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : Projectile {

	public int damage;

	public float knockback;

	public override void OnHittableEnter (Hittable hittable)
	{
		hittable.ReceiveDamage(damage);
		hittable.ReceiveKnockback(GetComponent<Rigidbody2D>().velocity, knockback);
		Destroy(gameObject);
	}
}
