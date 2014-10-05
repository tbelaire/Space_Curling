using UnityEngine;
using System.Collections;
using System;

public class CameraManScript : MonoBehaviour {

	Transform currentlyTracking;
	public Transform launchPlatform;
	public Transform goal;
	
	// Use this for initialization
	void Start () {
		this.updateLocation (launchPlatform.position);
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 pos = this.transform.position;
		pos.y = currentlyTracking.position.y;
		pos.y = Math.Max (launchPlatform.position.y, pos.y);
		pos.y = Math.Min (goal.position.y, pos.y);

		this.transform.position = pos;
	}

	void updateLocation(Vector3 pos){
		pos.z = this.transform.position.z;
		this.transform.position = pos;
	}

	public void Watch(Transform target) {
		this.currentlyTracking = target;
	}
}
