using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

	Transform parent;

	public void SetParent (Transform _parent)
	{
		parent = _parent;
	}

	void OnTriggerEnter2D (Collider2D collider)
	{
		if (collider.GetComponent<Damageable>() != null && collider.transform != parent)
		{
			OnDamageableEnter(collider.GetComponent<Damageable>());
		}
	}

	public virtual void OnDamageableEnter (Damageable damageable)
	{
		// override
	}
}
