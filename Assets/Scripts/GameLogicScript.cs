using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class GameLogicScript : MonoBehaviour {
	
	public StoneScript rock1;
	public StoneScript rock2;
	public Transform Goal;
	
	List<StoneScript> rockPrefabs;
	int NumberOfTeams = 2;
	int NumberOfTurns = 2;
	int NextRock;
	StoneScript currentStone;
	List<List<Transform>> teamStones;
	Vector3 PlatformCentre = new Vector3(0,0,0);
	
	// Use this for initialization
	void Start () {
		NextRock = 0;
		teamStones = new List<List<Transform>>();
		rockPrefabs = new List<StoneScript>();
		for(int i = 0; i < NumberOfTeams; i++)
		{
			teamStones.Add(new List<Transform>());
		}
		rockPrefabs.Add(rock1);
		rockPrefabs.Add(rock2);
		//To add more teams you must add the corresponding prefabs here
		
		PlaceNewRock();
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
		currentStone = (StoneScript)Instantiate (rockPrefabs[NextRock], PlatformCentre, new Quaternion());
		teamStones[NextRock].Add(currentStone.GetComponent<Transform>());
		
		NextRock++;
		if(NextRock == NumberOfTeams)
		{
			NextRock = 0;
		}							
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
		int winner = 0;
		for(int i = 0; i < NumberOfTeams; i++)
		{
			if(bestDistances[i] < bestDistances[winner])
			{
				winner = i;
			}
		}
		print ("Team " + winner + " Wins!!!");
	}
}


