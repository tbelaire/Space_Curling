using UnityEngine;
using System.Collections;

public class StoneScript : MonoBehaviour 
{

	Vector3 startPosition;
	bool isGrabbed = false;
	bool isLaunched = false;
	bool isFlying = false;

	public bool IsFlying { get { return isFlying; } }
	public bool IsLaunched { get { return isLaunched; } }

	public float launchFactor = 1f;
	public string TeamName;

	// Use this for initialization
	void Start () 
	{
		// Prevent forces from acting on it until we launch it
		this.rigidbody2D.isKinematic = true;

		this.startPosition = this.transform.position;
		//print (this.transform.position);
	}
	
	// Update is called once per frame
	void Update () {
		if (isGrabbed) 
		{
			Vector3 mousePositionInWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			mousePositionInWorld.z = 0f;
			this.transform.position = mousePositionInWorld;
		}
		if(this.gameObject.rigidbody2D.velocity.sqrMagnitude < 0.15 && isFlying)
		{
			isFlying = false;
		}
	}

	void OnCollisionEnter2D(Collision2D collider){
		if(collider.gameObject.CompareTag("Dangerous")){
			this.RemoveFromPlay ();
		}
	}
	public void RemoveFromPlay(){
		StartCoroutine(this.StartRemovingFromPlay());
	}
	IEnumerator StartRemovingFromPlay(){
		yield return new WaitForSeconds(1f);
		this.isFlying = false;
	}

	void OnMouseDown()
	{
		if(!isFlying)
		{
			isGrabbed = true;
		}
	}
	
	void OnMouseUp()
	{
		if(isGrabbed)
		{
			isGrabbed = false;
			isFlying = true;
			isLaunched = true;
			this.rigidbody2D.isKinematic = false;  // Forces act on it.
			
			Vector3 difference = this.startPosition - this.transform.position;
			this.rigidbody2D.velocity = difference * this.launchFactor;
			//print ("Mouse is Up!");
		}
	}
}
