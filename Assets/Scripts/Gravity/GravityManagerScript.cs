using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GravityManagerScript : MonoBehaviour {

	private HashSet<Transform> bodies = new HashSet<Transform>();
	public float gravityConstant = 111f;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		tickBodies();
	}
	void OnGUI() {
		GUI.Label( new Rect(0,0,Screen.width, Screen.height), string.Format("Num Bodies: {0}", this.bodies.Count));
	}
    public void registerBody(Transform transform) {
		bodies.Add(transform);
    }
	public void removeBody(Transform body) {
		bodies.Remove (body);
	}
	public void tickBodies() {
		bodies.RemoveWhere(item => item == null);

		foreach (Transform target in bodies) {
			foreach(Transform other in bodies) {
				if(target != other){
					Vector2 distance = target.position - other.position;
					target.rigidbody2D.AddForce(
						other.rigidbody2D.mass * target.rigidbody2D.mass *
						(-gravityConstant/distance.sqrMagnitude)
						* distance.normalized);
				}
			}
		}

	}

	public void clear() {
		bodies.Clear();
	}
}
