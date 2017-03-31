using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : Weapon {

	public override void OnDown ()
	{
		if (down && cool)
		{
			if (sm.AttemptTransition(States.Attacking))
			{
				Fire();
				StartCoroutine(Cooldown());
			}
		}
	}

	void Fire ()
	{
		GameObject bullet = Instantiate(prefab, transform.position, transform.rotation);
	}

	IEnumerator Cooldown ()
	{
		cool = false;
		yield return new WaitForSeconds(cooldown);
		cool = true;
	}
}
