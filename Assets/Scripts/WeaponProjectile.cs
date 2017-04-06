using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponProjectile : Weapon {

  public float velocity;

  public float recoil;

  // INPUTS //

  public override void OnDown ()
	{
		if (down)
		{
			if (sm.AttemptTransition(States.Attacking))
			{
				FireStart();
			}
		}
	}

  // FIRE FUNCTIONS //

	public virtual void FireStart ()
	{
		GameObject hitObj = InstantiateHit();

    Recoil();
		audioSource.Play();
    StartCoroutine(FireRoutine(hitObj));
	}

  public virtual IEnumerator FireRoutine (GameObject hitObj)
  {
    sm.AttemptTransition(States.Break);
    Destroy(hitObj, 10f);
    yield return null;
  }

  GameObject InstantiateHit ()
  {
    GameObject hitObj = Instantiate(prefab, transform.position, transform.rotation);
    hitObj.GetComponent<Hit>().SetParent(transform.parent);
    hitObj.GetComponent<Hit>().attackDirection = GetDirection();
    hitObj.GetComponent<Rigidbody2D>().AddForce(GetDirection() * velocity);
    return hitObj;
  }

	public virtual void Recoil ()
	{
		rb.AddForce(-GetDirection() * recoil, ForceMode2D.Impulse);
	}
}
