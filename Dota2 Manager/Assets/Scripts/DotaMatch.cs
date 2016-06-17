using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DotaMatch
{
    private DotaTeam teamA, teamB;
    private int bestOf;
    private List<DotaGame> games = new List<DotaGame>();
    private int scoreA = 0;
    private int scoreB = 0;
    private int maxScore = 0;
    private bool finished = false;

    // inits with team A, team B, bestOf
    public DotaMatch(DotaTeam a, DotaTeam b, int bo)
    {
        teamA = a;
        teamB = b;
        // calculate max possible score for a team
        // there might be a more efficient way to calculate this later
        
        bestOf = bo;
        if (bestOf == 3)
        {
            maxScore = 2;
        }
        else if (bestOf == 1)
        {
            maxScore = 1;
        }
        else if (bestOf == 5)
        {
            maxScore = 3;
        }
        // need else default case
    }

    // returns winning team of specific game
    public DotaTeam GetGameWinner(int game)
    {
        //TODO: catch index error if game does not exist (e.g. game 4 of a bo3)
        return games[game].GetWinner();
    }

    public void SimulateMatch()
    {
        Debug.Log("Simulating best of " + bestOf.ToString());
        int gamesPlayed = 0;
        // simulates a game if the winner is not determined yet
        while ((scoreA < maxScore) && (scoreB < maxScore))
        {
            games.Add(new DotaGame(teamA, teamB));
            if (games[gamesPlayed].SimulateGame() == teamA)
            {
                scoreA += 1;
            }
            else
            {
                scoreB += 1;
            }

            gamesPlayed += 1;
        }
        finished = true;
    }

    // returns string value of score e.g. 3:2
    public string GetScore()
    {
        string scoreString = "";
        if (!finished)
        {
            return null;
        }
        else
        {
            scoreString = teamA.GetTeamName() + " " + scoreA.ToString() + ":"
                           + scoreB.ToString() + " " + teamB.GetTeamName();
            return scoreString;
        }

    }
    
    // returns winning team of series
    public DotaTeam GetResult()
    {
        if (!finished)
        {
            return null;
        }
        else
        {
            if (scoreA > scoreB)
            {
                return teamA;
            }
            else
            {
                return teamB;
            }
        }
    }

    // return number of games played
    public int GetGameCount()
    {
        return games.Count;
    }

}

/* example to simulate match between two teams
 

        // initiate two teams
        DotaTeam tta = new DotaTeam("Alliance");
        DotaTeam ttb = new DotaTeam("OG");

        // creates match but doesn't simulate yet
        DotaMatch ndm = new DotaMatch(tta, ttb, 5); 
        
        // simulates match
        ndm.SimulateMatch();
        string MatchResult = ndm.GetScore();

        for (int x = 0; x < ndm.GetGameCount(); x++)
        {
            // gets winner for each game played
            Debug.Log(ndm.GetGameWinner(x).GetTeamName().ToString());
        }

        // displays final match score
        Debug.Log("test match score: " + MatchResult);
   
        */
