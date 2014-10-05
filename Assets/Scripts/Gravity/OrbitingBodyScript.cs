using UnityEngine;
using System.Collections;


public class OrbitingBodyScript : MonoBehaviour {

	void Start () {
		if(!this.rigidbody2D) {
			print ("Warning, no mass, as there is no Rigidbody2D attached");
		}
		this.RegisterGravity();
	}
	public void RegisterGravity() {
		GravityManagerScript gravityManager;
		gravityManager = FindObjectOfType<GravityManagerScript>();
		if(gravityManager == null){
			print ("Warning, unable to find a gravity manager, floating freely");
		} else {
			gravityManager.registerBody(this.transform);
		}

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
