using UnityEngine;
using System.Collections;

public class WallScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	void OnTriggerEnter2D(Collider2D other) {
		print ("Hit A wall");
		var s = other.GetComponent<StoneScript>();
		if(s != null){
			s.RemoveFromPlay();
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
