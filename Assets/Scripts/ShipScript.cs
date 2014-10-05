using UnityEngine;
using System.Collections;

public class ShipScript : MonoBehaviour {

	public float velocityCoefficient = 5f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		this.rigidbody2D.velocity = velocityCoefficient *
			new Vector2(Input.GetAxis("HorizontalShip1"),Input.GetAxis ("VerticalShip1"));
	
		if(Input.GetButtonDown("FireShip1")){
			this.audio.Play ();
			print ("Fireing");
		}
	}
	
}
