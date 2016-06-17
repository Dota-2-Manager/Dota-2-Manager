using UnityEngine;
using System.Collections;

public class DotaGame
{
    private DotaTeam teamA, teamB;
    private System.Random ran = new System.Random();
    private DotaTeam winner;
    private DotaTeam loser;
    // other stats like score, kda, duration, etc...

    public DotaGame(DotaTeam a, DotaTeam b)
    {
        teamA = a;
        teamB = b;
        //SimulateGame();
    }

    public DotaTeam SimulateGame()
    {
        // win/lose simulation for a game of dota between two teams
        // sets winner and loser variables, and returns winner
        // mostly copied from GameCore.VsRandomTeam(), I don't know much about the math here - ivandaho
        double x;
        DotaTeam betterTeam;
        DotaTeam worseTeam;
        if (teamB.GetTotalValue() < teamA.GetTotalValue())
        {
            x = teamA.GetTotalValue() * (100 / teamB.GetTotalValue()) / 100;
        }
        else
        {
            x = teamB.GetTotalValue() * (100 / teamA.GetTotalValue()) / 100;
        }
        double percentage = 0.5d + (x - 1);

        if (ran.NextDouble() >= percentage)
        {
            betterTeam = teamB;
            worseTeam = teamA;
        }
        else
        {
            betterTeam = teamA;
            worseTeam = teamB;
        }
        Debug.Log("teamA total = " + teamA.GetTotalValue() + " teamB total = " + teamB.GetTotalValue());
        Debug.Log("x = " + x.ToString() + " percentage = " + percentage.ToString());

        winner = betterTeam;
        loser = worseTeam;

        return winner;
    }

    public DotaTeam GetWinner()
    {
        return winner;
    }

    public DotaTeam GetLoser()
    {
        return loser;
    }
}

