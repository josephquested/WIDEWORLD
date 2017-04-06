using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponMelee : Weapon {

  Rigidbody2D rb;

  public float thrust;

  public float attackDuration;

  void Start ()
  {
    rb = transform.parent.GetComponent<Rigidbody2D>();
  }

  // fire functions //

  public virtual void FireStart ()
  {
    GameObject hitObj = InstantiateHit();
    PlaceMeleeObject(hitObj);
    audioSource.Play();
    StartCoroutine(FireRoutine(hitObj));
  }

  public virtual IEnumerator FireRoutine (GameObject hitObj)
  {
    yield return new WaitForSeconds(attackDuration);
    Destroy(hitObj);
    sm.AttemptTransition(States.Break);
  }

  GameObject InstantiateHit ()
  {
    GameObject hitObj = Instantiate(prefab, transform.position, transform.rotation);
    hitObj.GetComponent<Hit>().SetParent(transform.parent);
    hitObj.transform.parent = transform.parent;
    return hitObj;
  }

	public virtual void Thrust ()
	{
		rb.AddForce(GetDirection() * thrust, ForceMode2D.Impulse);
	}

  // melee hit helper fuctions //

  public void PlaceMeleeObject (GameObject hitObj)
  {
    PositionMeleeObject(hitObj);
    RotateMeleeObject(hitObj);
    LayerMeleeObject(hitObj);
  }

  void PositionMeleeObject (GameObject hitObj)
  {
    Vector2 v2 = GetDirection() / 2;
    Vector3 direction = new Vector3(v2.x, v2.y, 0f);
    hitObj.transform.position += direction;
  }

  void RotateMeleeObject (GameObject hitObj)
  {
    switch (sm.direction)
  	{
  		case Directions.North:
  		  hitObj.transform.Rotate(new Vector3(0, 0, 90));
        return;

  		case Directions.East:
  			return;

  		case Directions.South:
  			hitObj.transform.Rotate(new Vector3(0, 0, -90));
        return;

  		case Directions.West:
  			hitObj.transform.Rotate(new Vector3(0, 0, -180));
        return;

  		default:
  			return;
  	}
  }

  void LayerMeleeObject (GameObject hitObj)
  {
    if (sm.direction == Directions.South)
    {
      hitObj.GetComponent<SpriteRenderer>().sortingOrder += 1;
    }
  }
}
