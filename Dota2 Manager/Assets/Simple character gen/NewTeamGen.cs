using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NewTeamGen : MonoBehaviour {

	public List<DotaTeam> teams;
	public DotaTeam a;

	// Use this for initialization
	void Start () 
	{
		teams = new List<DotaTeam> ();
		MakeNewTeam();

		foreach (DotaTeam team in teams)
		{
			Debug.Log(team.teamTotal);
		}


	}
	
	void MakeNewTeam()
	{
		DotaTeam a = gameObject.AddComponent<DotaTeam> () as DotaTeam;
		a.teamName = "OG";
		a.synergy = Random.Range(10,25);
		a.tactics = Random.Range(10,25);
		a.hidenStrats = Random.Range(10,25);
		a.teamStress = 0;
		a.CalculateTeamTotal();
		teams.Add(a);
	}
}
