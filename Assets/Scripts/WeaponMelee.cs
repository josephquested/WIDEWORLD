using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponMelee : Weapon {

  public float thrust;

  public float attackDuration;

  // INPUTS //

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

  // FIRE FUNCTIONS //

  public virtual void FireStart ()
  {
    GameObject hitObj = InstantiateHit();
    PlaceMeleeObject(hitObj);

    Thrust();
    audioSource.Play();
    StartCoroutine(FireRoutine(hitObj));
  }

  public virtual IEnumerator FireRoutine (GameObject hitObj)
  {
    yield return new WaitForSeconds(attackDuration);
    sm.AttemptTransition(States.Break);
    Destroy(hitObj);
  }

  GameObject InstantiateHit ()
  {
    GameObject hitObj = Instantiate(prefab, transform.position, transform.rotation);
    hitObj.GetComponent<Hit>().SetParent(transform.parent);
    hitObj.GetComponent<Hit>().attackDirection = GetDirection();
    hitObj.transform.parent = transform.parent;
    return hitObj;
  }

	public virtual void Thrust ()
	{
		rb.AddForce(GetDirection() * thrust, ForceMode2D.Impulse);
	}

  // HIT HELPERS //

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
