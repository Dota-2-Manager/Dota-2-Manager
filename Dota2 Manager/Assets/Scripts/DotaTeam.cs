using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DotaTeam {

    
    private string teamName;
    private NewPlayerGen gen;
    private List<DotaPlayer> players = new List<DotaPlayer>();
    private System.Random ran = new System.Random();

    private double TeamTotalValue;

    public DotaTeam(string PTeamName)
    {
        
        //if found existing team
        teamName = PTeamName;

        bool foundExistingTeam = false;
        foreach (DotaTeam existingTeam in GameCore.teamsInGame)
        {
            if (teamName == existingTeam.GetTeamName())
            {
                //Debug.Log("Found a match");
                foundExistingTeam = true;
                foreach (DotaPlayer player in GameCore.allPlayers)
                {
                    if(player.team == teamName)
                    {
                        players.Add(player);
                    }
                }
            }
        }

        // if no existing team found
        if (!foundExistingTeam)
        {
            gen = new NewPlayerGen();

            for (int i = 0; i < 5; i++)
            {
                // int to specify role
                players.Add(gen.MakeNewRandomPlayerWithSetRole(i+1));
            }
        }
        CalculateTeamTotalValue();
    }

    public List<DotaPlayer> getList()
    {
        return players;
    }

    public string GetTeamName()
    {
        return teamName;
    }

    public double GetTotalValue()
    {
        return TeamTotalValue;
    }

    public void CalculateTeamTotalValue()
    {
        foreach (DotaPlayer player in players)
        {
            TeamTotalValue += player.total;
        }
    }

}
