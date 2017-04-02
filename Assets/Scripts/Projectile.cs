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
		if (collider.GetComponent<Hittable>() != null && collider.transform != parent)
		{
			OnHittableEnter(collider.GetComponent<Hittable>());
		}
	}

	public virtual void OnHittableEnter (Hittable hittable)
	{
		// override
	}
}
