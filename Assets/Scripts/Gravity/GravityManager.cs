using UnityEngine;
using System.Collections.Generic;

public class GravityManager {
    private static GravityManager instanceInternal;
	public List<Transform> bodies = new List<Transform>();
    public static GravityManager instance
    {
        get
        {
            if (instanceInternal == null)
            {
                instanceInternal = new GravityManager();
            }
            
            return instanceInternal;
        }
    }

    public void registerBody(Transform transform) {
		bodies.Add(transform);
    }
	public void tickBodies() {
		foreach (Transform target in bodies) {
			foreach(Transform other in bodies) {
				if(target != other){
					Vector2 distance = target.position - other.position;
					target.rigidbody2D.AddForce((-111f/distance.sqrMagnitude) * distance.normalized);
				}
			}
		}

	}

	public void clear() {
		bodies.Clear();
	}
}
