using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : WeaponProjectile {

	public override void OnDown ()
	{
		if (down)
		{
			if (sm.AttemptTransition(States.Attacking))
			{
				FireInit();
			}
		}
	}
}
