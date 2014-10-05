using UnityEngine;
using System.Collections;


public class OrbitingBodyScript : MonoBehaviour {


	void Start () {
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
