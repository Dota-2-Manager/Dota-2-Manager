
public static class GameEvents
{

    public static void SimulateDrama()
    {
    }


    public static void ScanRecentMatches()
    {
        // based on recent match results, team rating will change
        // TODO: change timeticks to proper time implementation

        // timedate of today in game time
        int currentTimeTick = 500;
        
        int startfrom = MatchHistory.GetGlobalGameHistory().Count;
        
        // most recent 10 matches or 3 month period (temporary set to 90 timeticks)
        for (int i = startfrom; i > startfrom - 10; i--)
        {
            // if more recent than 90 timeticks (days)...
            DotaGame g = MatchHistory.GetGlobalGameHistory()[i];
            if (g.tempTimeTick > currentTimeTick)
            {
                // match eligible to influence stats
                UpdateTeamsByGame(g);
                UpdatePlayersByGame(g);
            }
        }
    }

    public static void UpdateTeamsByGame(DotaGame g)
    {
        // based on stats for that game, update team rating
    }


    public static void UpdatePlayersByGame(DotaGame g)
    {
        // based on stats for that game, update player stats
    }

    
    public static void UpdatePlayersByExternalFactors()
    {
        // based on external factors, update player stats such as happiness etc
    }


    // called after a set time period is passed, to simulate game events
    public static void TickForward()
    {
        // scan recent matches to update team rating and player stats
        ScanRecentMatches();
        UpdatePlayersByExternalFactors();

        SimulateDrama();
    }

}
