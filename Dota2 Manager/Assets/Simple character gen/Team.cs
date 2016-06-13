using UnityEngine;
using System.Collections;

public class DotaTeam : MonoBehaviour {

	public string teamName;

	//postive
	public double synergy;
	public double tactics;
	public double hidenStrats;

	//negative
	public double teamStress;

	//total
	public double teamTotal;

	// Use this for initialization
	void Start () 
	{
		CalculateTeamTotal();
	}

	public void CalculateTeamTotal()
	{
		teamTotal = synergy * 0.145 + tactics * 0.145 + hidenStrats * 0.145 - teamStress * 0.145;
	}
}
