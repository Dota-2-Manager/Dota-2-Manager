
using System;
using System.Collections.Generic;
using System.IO;
using LitJson;
using UnityEngine;

public class GameData : MonoBehaviour
{
    private static string jsonString;
    private static JsonData playerData;
    public static List<DotaPlayer> _allPlayers = new List<DotaPlayer>();
    private static List<string> playersInTeam = new List<string>();
    public static List<DotaTeam>  _teamsInGame = new List<DotaTeam>();
    //private JsonData test;

    public static DotaTeam _team = new DotaTeam("newteam");
    public static int _currentmember;


    private static System.Random ran = new System.Random();

    void Start()
    {
        InitJson();

        // populate list of DotaPlayer type with existing players
        PopulatePlayerList();
        // pull team list from player list
        GetTeams();
    }

    public static void InitJson()
    {
        jsonString = File.ReadAllText(Application.dataPath + "/Resources/playersInfo.json");
        playerData = JsonMapper.ToObject (jsonString);
    }

    // for team selection, traverses list of players and grabs players that match team name (after selecting team)
    public static JsonData GetPlayer(string team, string type)
    {
        playersInTeam.Clear ();
        for(int i = 0; i< playerData["players"].Count; i++)
        {
            if(playerData["players"][i]["team"].ToString() == team)
            {
                playersInTeam.Add (Convert.ToString(playerData["players"][i][type]));
            }
        }

        //Return the first position as returning null seems to pause unity
        return playerData["players"][0];
    }

    // fills allPlayers with data
    public static void PopulatePlayerList()
    {
        for(int i = 0; i< playerData["players"].Count; i++)
        {
            DotaPlayer p = new DotaPlayer();
            p.SetPos((Int32.Parse(Convert.ToString(playerData["players"][i]["CurrentRole"]))));

            int a_ = Int32.Parse(Convert.ToString(playerData["players"][i]["Carry"]));
            int b_ = Int32.Parse(Convert.ToString(playerData["players"][i]["Consistency"]));
            int c_ = Int32.Parse(Convert.ToString(playerData["players"][i]["decisionMakeing"]));
            int d_ = Int32.Parse(Convert.ToString(playerData["players"][i]["farming"]));
            int e_ = Int32.Parse(Convert.ToString(playerData["players"][i]["fighting"]));
            int f_ = Int32.Parse(Convert.ToString(playerData["players"][i]["flair"]));
            int g_ = Int32.Parse(Convert.ToString(playerData["players"][i]["laneControl"]));
            int h_ = Int32.Parse(Convert.ToString(playerData["players"][i]["Leadership"]));
            int i_ = Int32.Parse(Convert.ToString(playerData["players"][i]["mapAwareness"]));
            int j_ = Int32.Parse(Convert.ToString(playerData["players"][i]["Mid"]));
            int k_ = Int32.Parse(Convert.ToString(playerData["players"][i]["Offlane"]));
            int l_ = Int32.Parse(Convert.ToString(playerData["players"][i]["Positioning"]));
            int m_ = Int32.Parse(Convert.ToString(playerData["players"][i]["pushing"]));
            int n_ = Int32.Parse(Convert.ToString(playerData["players"][i]["riskTakeing"]));
            int o_ = Int32.Parse(Convert.ToString(playerData["players"][i]["roaming"]));
            int p_ = Int32.Parse(Convert.ToString(playerData["players"][i]["Support"]));
            int q_ = Int32.Parse(Convert.ToString(playerData["players"][i]["teamWork"]));
            int r_ = Int32.Parse(Convert.ToString(playerData["players"][i]["warding"]));

            string s_ = Convert.ToString(playerData["players"][i]["team"]);
            string t_ = Convert.ToString(playerData["players"][i]["name"]);
            
            p.setAll(a_, b_, c_, d_, e_, f_, g_, h_, i_, j_, k_, l_, m_, n_, o_, p_, q_, r_);
            p.SetTeam(s_);
            p.SetName(t_);
            p.CalculateTotal();
            _allPlayers.Add(p);
        }
    }

    public static void GetTeams()
    {
        _teamsInGame.Clear();

        List<string> foundTeams = new List<string>();

        foreach (DotaPlayer player in _allPlayers)
        {
            string discoveredTeamName = player.team;
            if (!foundTeams.Contains(discoveredTeamName))
            {
                // add to team list if not yet added
                foundTeams.Add(discoveredTeamName);
                _teamsInGame.Add(new DotaTeam(discoveredTeamName, 0));
            }

            _teamsInGame.Find(i => i.GetTeamName() == discoveredTeamName).AddPlayer(player);
        }
    }

}
