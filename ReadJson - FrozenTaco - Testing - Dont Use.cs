using UnityEngine;
using System.Collections;
using System.IO;
using LitJson;
using System.Collections.Generic;
using System;

public class ReadJson : MonoBehaviour {

	private string jsonString;
	private JsonData playerData;
	private List<string> playersInTeam = new List<string>();
	private string test;

	// Use this for initialization
	void Start () 
	{
		jsonString = File.ReadAllText(Application.dataPath + "/Resources/playersInfo.json");
		playerData = JsonMapper.ToObject (jsonString);
		GetPlayer ("OG", "players");
		for (int i = 0; i < 5; i++) 
		{
			Debug.Log(playersInTeam[i]);
		}

	}

	JsonData GetPlayer(string team, string type)
	{

		for(int i = 0; i< playerData[type].Count; i++)
		{
			if(playerData[type][i]["team"].ToString() == team)
			{
				playersInTeam.Add (Convert.ToString(playerData[type][i]["name"]));
			}
		}

		//Return the first position as returning null seems to pause unity
		return playerData[type][0];
	}



}
