using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : Weapon {

	Rigidbody2D rb;

	public float recoil;

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
				Recoil();
			}
		}
	}

	void Fire ()
	{
		GameObject bullet = Instantiate(prefab, transform.position, transform.rotation);
		bullet.GetComponent<Bullet>().SetParent(transform.parent);
		bullet.GetComponent<Rigidbody2D>().AddForce(GetDirection() * velocity);
		audioSource.Play();
	}

	void Recoil ()
	{
		rb.AddForce(-GetDirection() * recoil, ForceMode2D.Impulse);
	}
}
