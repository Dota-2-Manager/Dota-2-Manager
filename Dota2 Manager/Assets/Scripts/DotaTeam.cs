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
        
        teamName = PTeamName;
        gen = new NewPlayerGen();
        for (int i = 0; i < 5; i++)
        {
            // int to specify role
            players.Add(gen.MakeNewRandomPlayerWithSetRole(i+1));
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
