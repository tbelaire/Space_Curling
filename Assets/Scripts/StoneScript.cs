using UnityEngine;
using System.Collections;

public class StoneScript : MonoBehaviour 
{

	Vector3 startPosition;
	bool isGrabbed = false;
	bool isFlying = false;

	public float launchFactor = 1f;

	// Use this for initialization
	void Start () 
	{
		this.startPosition = this.transform.position;
		print (this.transform.position);
	}
	
	// Update is called once per frame
	void Update () {
		if (isGrabbed) 
		{
			Vector3 mousePositionInWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			mousePositionInWorld.z = 0f;
			this.transform.position = mousePositionInWorld;
		}
		if(isFlying)
		{
			float cameraHeight = Camera.main.transform.position.z; 
			Camera.main.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, cameraHeight);
		}
		if(this.gameObject.rigidbody2D.velocity == Vector2.zero && isFlying)
		{
			isFlying = false;
			returnCamera();
		}
		
		if(Input.GetKeyDown(KeyCode.Space))
		{
			isGrabbed = false;
			isFlying = false;
			this.transform.position = this.startPosition;
			this.rigidbody2D.velocity = Vector2.zero;
			returnCamera();
		}
	}
	
	void OnMouseDown()
	{
		if(!isFlying)
		{
			isGrabbed = true;
			print (startPosition);
			//print ("Mouse is Down!");
		}
	}
	
	void OnMouseUp()
	{
		if(isGrabbed)
		{
			isGrabbed = false;
			isFlying = true;
			
			Vector3 difference = this.startPosition - this.transform.position;
			this.rigidbody2D.velocity = difference * this.launchFactor;
			//print ("Mouse is Up!");
		}
	}
	
	void returnCamera()
	{
		float cameraHeight = Camera.main.transform.position.z;
		Camera.main.transform.position = new Vector3(this.startPosition.x, this.startPosition.y, cameraHeight);
	}
}
