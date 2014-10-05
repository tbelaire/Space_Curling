using UnityEngine;
using System.Collections;

public class ShipScript : MonoBehaviour {

	public float velocityCoefficient = 5f;
	public Rigidbody2D bulletType;

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
			if(bulletType == null){ print ("You forget to give me bullets");}
			Rigidbody2D bullet = (Rigidbody2D) Instantiate(bulletType, this.transform.position, Quaternion.identity);
			//bullet.AddForce(this.transform.forward.normalized * 10000);
			bullet.AddForce(new Vector2(0, 100));
		}
	}
	
}
