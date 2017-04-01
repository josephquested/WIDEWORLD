using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : Projectile {

	public int damage;

	public float knockback;

	public override void OnDamageableEnter (Damageable damageable)
	{
		damageable.ReceiveDamage(damage);
		Destroy(gameObject);
	}
}
