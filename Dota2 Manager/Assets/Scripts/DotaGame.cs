using UnityEngine;
using System;
using System.Threading;

public class DotaGame
{
    private DotaTeam teamA, teamB;
    private DotaTeam winner;
    private DotaTeam loser;
    // other stats like score, kda, duration, etc...

    private readonly int matchID;

    //TODO: change to proper time implementation
    public int tempTimeTick;

    public DotaGame(DotaTeam a, DotaTeam b)
    {
        teamA = a;
        teamB = b;
        matchID = MatchHistory.IncrementGameCount();
        //SimulateGame();
    }

    public DotaTeam SimulateGame()
    {
        // win/lose simulation for a game of dota between two teams
        // sets winner and loser variables, and returns winner

        DotaTeam betterTeam;
        DotaTeam worseTeam;

        if (teamA.GetTotalValue() > teamB.GetTotalValue())
        {
            betterTeam = teamA;
            worseTeam = teamB;
        }
        else
        {
            betterTeam = teamB;
            worseTeam = teamA;
        }
        double x = Math.Abs(teamA.GetTotalValue() - teamB.GetTotalValue());
        Debug.Log ("difference = " + x + " | better team: " + betterTeam.GetTeamName());

        const double pow = 1.5;
        double probability = Math.Log(x + 1, 21) + ((Math.Pow((1 - (Math.Log((x + 1), 21))), pow))/2d);

        var ran = new System.Random ();

        // sleep to avoid same random number. 5ms still has repeated values, 10 seems ok
        Thread.Sleep (10);
        double rng = ran.NextDouble ();
        Debug.Log ("probability: " + probability + " | " + rng);

        if (rng < probability) {
            //better team wins a wins
            winner = betterTeam;
            loser = worseTeam;
        }
        else
        {
            winner = worseTeam;
            loser = betterTeam;
        }

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

    public int GetMatchID()
    {
        return matchID;
    }

    public override string ToString()
    {
        return "matchID " + matchID + " " + teamA + " vs " + teamB + " | winner: " + winner;
    }


}
