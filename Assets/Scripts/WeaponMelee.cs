using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponMelee : Weapon {

  public float thrust;

  public float attackDuration;

  public virtual void Fire ()
  {
    GameObject weaponObj = Instantiate(prefab, transform.position, transform.rotation);
    weaponObj.GetComponent<Hit>().SetParent(transform.parent);
    weaponObj.transform.parent = transform.parent;

    PlaceMeleePrefab(weaponObj);

    audioSource.Play();

    Destroy(weaponObj, attackDuration);
  }

  public void PlaceMeleePrefab (GameObject weaponObj)
  {
    PositionMeleePrefab(weaponObj);
    RotateMeleePrefab(weaponObj);
    LayerMeleePrefab(weaponObj);
  }

  void PositionMeleePrefab (GameObject weaponObj)
  {
    Vector2 v2 = GetDirection() / 2;
    Vector3 direction = new Vector3(v2.x, v2.y, 0f);
    weaponObj.transform.position += direction;
  }

  void RotateMeleePrefab (GameObject weaponObj)
  {
    switch (sm.direction)
  	{
  		case Directions.North:
  		  weaponObj.transform.Rotate(new Vector3(0, 0, 90));
        return;

  		case Directions.East:
  			return;

  		case Directions.South:
  			weaponObj.transform.Rotate(new Vector3(0, 0, -90));
        return;

  		case Directions.West:
  			weaponObj.transform.Rotate(new Vector3(0, 0, -180));
        return;

  		default:
  			return;
  	}
  }

  void LayerMeleePrefab (GameObject weaponObj)
  {
    if (sm.direction == Directions.South)
    {
      weaponObj.GetComponent<SpriteRenderer>().sortingOrder += 1;
    }
  }
}
