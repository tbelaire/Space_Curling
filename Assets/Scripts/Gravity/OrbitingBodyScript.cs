using UnityEngine;
using System.Collections;


public class OrbitingBodyScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GravityManager.instance.registerBody(this.transform);
	
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
