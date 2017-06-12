using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPosition : MonoBehaviour 
{
    public bool inThreeDimensions;
    public int minDistance;
    public int maxDistance;

	void OnEnable ()
    {
        // assign random distances
        int x = Random.Range(-minDistance, maxDistance);
        int y = Random.Range(-minDistance, maxDistance);
        int z = Random.Range(-minDistance, maxDistance);

        // there is a 50/50 chance any value could be negative
        if (Random.Range(0, 2) == 0)
        {
            x = -x;
        }
        if (Random.Range(0, 2) == 0)
        {
            y = -y;
        }
        if (Random.Range(0, 2) == 0)
        {
            z = -z;
        }

        // if random in 3 dimensions
        if (inThreeDimensions)
        {
            transform.position = new Vector3(x, y, z);
        }
        // otherwise in 2 dimensions
        else
        {
            transform.position = new Vector2(x, y);
        }
    }	
}
