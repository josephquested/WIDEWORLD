using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageable : MonoBehaviour {

	bool invulnerable;

	public void ReceiveDamage (int damage)
	{
		print(gameObject.name + " recieved damage: " + damage);
	}
}
