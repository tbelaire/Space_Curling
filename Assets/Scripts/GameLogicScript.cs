using UnityEngine;
using System.Collections;

public class GameLogicScript : MonoBehaviour {
	
	public StoneScript rock1;
	public StoneScript rock2;
	
	int NumberOfTeams = 2;
	int NumberOfTurns = 4;
	int NextRock;
	StoneScript currentStone;
	Vector3 PlatformCentre = new Vector3(0,0,0);
	
	// Use this for initialization
	void Start () {
		NextRock = 1;
		PlaceNewRock();
	}
	
	// Update is called once per frame
	void Update () {
		if(currentStone.IsLaunched && !currentStone.IsFlying)
		{
			PlaceNewRock();
		}
	}
	
	public void PlaceNewRock()
	{
		if(NextRock == 1)
		{
			currentStone = (StoneScript)Instantiate (rock1, PlatformCentre, new Quaternion());
			NextRock = 2;
		}
		else if(NextRock == 2)
		{
			currentStone = (StoneScript)Instantiate (rock2, PlatformCentre, new Quaternion());
			NextRock = 1;
		}
	}
}
