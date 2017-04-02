using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusActor : Status {

	void Update ()
	{
		if (hitpoints <= 0)
		{
			Die();
		}
	}

	public override void ReceiveDamage (int damage)
	{
		hitpoints -= damage;
	}

	void Die ()
	{
		Destroy(gameObject);
	}
}
