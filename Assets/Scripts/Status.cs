using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status : MonoBehaviour {

	public int hitpoints;

	public bool invulnerable;

	public virtual void ReceiveDamage (int damage)
	{
		// override
	}
}
