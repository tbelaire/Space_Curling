using UnityEngine;
using System.Collections;

public class AntiGravityFieldScript : MonoBehaviour {

	private GravityManagerScript gravityManager;

	// Use this for initialization
	void Start () {
		gravityManager = FindObjectOfType<GravityManagerScript>();
		if(gravityManager == null){
			print ("Warning, unable to find a gravity manager, everything is antigravity");
		} 
	}

	
	void OnTriggerEnter2D(Collider2D other) {
		gravityManager.removeBody(other.transform);
	}
	// Update is called once per frame
	void Update () {
	
	}
}
