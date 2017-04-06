using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponProjectile : Weapon {

  Rigidbody2D rb;

  public float velocity;

  public float recoil;

  void Start ()
  {
    rb = transform.parent.GetComponent<Rigidbody2D>();
  }

	public virtual void FireInit ()
	{
		GameObject projectileObj = Instantiate(prefab, transform.position, transform.rotation);
		projectileObj.GetComponent<Hit>().SetParent(transform.parent);
		projectileObj.GetComponent<Rigidbody2D>().AddForce(GetDirection() * velocity);

		audioSource.Play();

  	Recoil();

		sm.AttemptTransition(States.Break);
	}

	public virtual void Recoil ()
	{
		rb.AddForce(-GetDirection() * recoil, ForceMode2D.Impulse);
	}
}
