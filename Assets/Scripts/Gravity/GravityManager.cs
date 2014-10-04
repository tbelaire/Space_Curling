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

	public void clear() {
		bodies.Clear();
	}
}
