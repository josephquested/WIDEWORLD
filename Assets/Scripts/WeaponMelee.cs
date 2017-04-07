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
    StartCoroutine(PositionHitRoutine(hitObj));
    RotateMeleeObject(hitObj);
    LayerMeleeObject(hitObj);
  }

  public IEnumerator PositionHitRoutine (GameObject hitObj)
  {
    Vector2 basePos = GetDirection() / 2;
    Vector3 start = GetHitStartPosition(basePos);
    Vector3 max = GetHitEndPosition(basePos);
    float t = 0f;
    while (t < 1)
    {
      t += Time.deltaTime / attackDuration * 2;
      hitObj.transform.position = Vector3.Lerp(transform.parent.position + start, transform.parent.position + max, t);
      yield return null;
    }
  }

  Vector3 GetHitStartPosition (Vector2 basePos)
  {
    switch (sm.direction)
    {
      case Directions.North:
        return new Vector3(basePos.x, basePos.y, 0f) / 2;

      case Directions.East:
        return new Vector3(basePos.x, basePos.y, 0f) / 2.5f;

      case Directions.South:
        return new Vector3(basePos.x, basePos.y, 0f);

      case Directions.West:
        return new Vector3(basePos.x, basePos.y, 0f) / 2.5f;

      default:
        return new Vector3(basePos.x, basePos.y, 0f) / 1.5f;
    }
  }

  Vector3 GetHitEndPosition (Vector2 basePos)
  {
    switch (sm.direction)
    {
      case Directions.North:
        return new Vector3(basePos.x, basePos.y, 0f) * 1.25f;

      case Directions.East:
        return new Vector3(basePos.x, basePos.y, 0f);

      case Directions.South:
        return new Vector3(basePos.x, basePos.y, 0f) * 1.3f;

      case Directions.West:
        return new Vector3(basePos.x, basePos.y, 0f);

      default:
        return new Vector3(basePos.x, basePos.y, 0f);
    }
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
