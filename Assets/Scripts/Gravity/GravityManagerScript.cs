using UnityEngine;
using System.Collections;

public class GravityManagerScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	}
	void OnGUI() {
		GUI.Label( new Rect(0,0,Screen.width, Screen.height), string.Format("Score: {0}", GravityManager.instance.bodies.Count));
	}
}
