using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hittable : MonoBehaviour {

	public virtual void ReceiveDamage (int damage)
	{
		// override
	}

	public virtual void ReceiveKnockback (Vector2 direction, float force)
	{
		// override
	}
}
