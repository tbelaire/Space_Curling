using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class GameLogicScript : MonoBehaviour {
	
	public StoneScript rock1;
	public StoneScript rock2;
	public Transform Goal;
	public Transform RockSpawnPoint;
	public GUIStyle victoryStyle;

	List<StoneScript> rockPrefabs;
	int NumberOfTeams = 2;
	int NumberOfTurns = 1;
	int NextRock;
	bool gameOver;
	int winningTeam;
	StoneScript currentStone;
	List<List<Transform>> teamStones;
	CameraManScript cameraMan;


	// Use this for initialization
	void Start () {
	
		teamStones = new List<List<Transform>>();
		Reset();
		rockPrefabs = new List<StoneScript>();
		rockPrefabs.Add(rock1);
		rockPrefabs.Add(rock2);
		//To add more teams you must add the corresponding prefabs here
		
		PlaceNewRock();
	}
	
	void Reset()
	{
		foreach(List<Transform> team in teamStones)
		{
			foreach(Transform stone in team)
			{
				Destroy(stone.gameObject);
			}
		}
		gameOver = false;
		NextRock = 0;
		teamStones = new List<List<Transform>>();
		for(int i = 0; i < NumberOfTeams; i++)
		{
			teamStones.Add(new List<Transform>());
		}
		cameraMan = FindObjectOfType<CameraManScript>();
		if(cameraMan == null){print ("Can't find a camera man");}
	}
	
	// Update is called once per frame
	void Update () {
		if(currentStone.IsLaunched && !currentStone.IsFlying)
		{
			if(teamStones[NumberOfTeams - 1].Count == NumberOfTurns)
			{
				//We have launched all of the stones for this game
				CalculateVictor();
			}
			else
			{
				PlaceNewRock();
			}
		}
	}
	
	private void PlaceNewRock()
	{
		currentStone = (StoneScript)Instantiate (rockPrefabs[NextRock], RockSpawnPoint.transform.position, new Quaternion());
		teamStones[NextRock].Add(currentStone.GetComponent<Transform>());
		
		NextRock++;
		if(NextRock == NumberOfTeams)
		{
			NextRock = 0;
		}							
		cameraMan.Watch(currentStone.transform);
	}
	
	private void CalculateVictor()
	{
		List<double> bestDistances = new List<double>();
		for(int i = 0; i < NumberOfTeams; i++)
		{
			bestDistances.Add(int.MaxValue);
			for(int j = 0; j < NumberOfTurns; j++)
			{
				double distance = Math.Sqrt((teamStones[i][j].position.x - Goal.position.x) * (teamStones[i][j].position.x - Goal.position.x)
				                            + (teamStones[i][j].position.y - Goal.position.y) * (teamStones[i][j].position.y - Goal.position.y));
				if(distance < bestDistances[i])
				{
					bestDistances[i] = distance;
				}
			}
		}
		winningTeam = 0;
		for(int i = 0; i < NumberOfTeams; i++)
		{
			if(bestDistances[i] < bestDistances[winningTeam])
			{
				winningTeam = i;
			}
		}
		gameOver = true;
	}
	
	void OnGUI() {
		if(gameOver)
		{
			GUI.Label( new Rect(320,220,Screen.width, Screen.height), string.Format("Team {0} Wins!!!", rockPrefabs[winningTeam].TeamName), victoryStyle);
			if (GUI.Button(new Rect(480,330,100,25),"Play Again?"))
			{
				Reset();
			}
		}
	}
}


