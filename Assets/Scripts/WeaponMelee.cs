using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponMelee : Weapon {

  public float thrust;

  public void PlaceMeleePrefab (GameObject prefab)
  {
    PositionMeleePrefab(prefab);
    RotateMeleePrefab(prefab);
    LayerMeleePrefab(prefab);
  }

  public void PositionMeleePrefab (GameObject prefab)
  {
    Vector2 v2 = GetDirection() / 2;
    Vector3 direction = new Vector3(v2.x, v2.y, 0f);
    prefab.transform.position += direction;
  }

  public void RotateMeleePrefab (GameObject prefab)
  {
    switch (sm.direction)
  	{
  		case Directions.North:
  		  prefab.transform.Rotate(new Vector3(0, 0, 90));
        return;

  		case Directions.East:
  			return;

  		case Directions.South:
  			prefab.transform.Rotate(new Vector3(0, 0, -90));
        return;

  		case Directions.West:
  			prefab.transform.Rotate(new Vector3(0, 0, 180));
        return;

  		default:
  			return;
  	}
  }

  public void LayerMeleePrefab (GameObject prefab)
  {
    // switch (sm.direction)
  	// {
  	// 	case Directions.North:
  	// 	  prefab.transform.Rotate(new Vector3(0, 0, 90));
    //     return;
    //
  	// 	case Directions.East:
  	// 		return;
    //
  	// 	case Directions.South:
  	// 		prefab.transform.Rotate(new Vector3(0, 0, -90));
    //     return;
    //
  	// 	case Directions.West:
  	// 		prefab.transform.Rotate(new Vector3(0, 0, 180));
    //     return;
    //
  	// 	default:
  	// 		return;
  	// }
  }
}
