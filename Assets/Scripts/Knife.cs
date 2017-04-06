using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : WeaponMelee {

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
}
