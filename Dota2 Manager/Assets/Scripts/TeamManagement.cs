using UnityEngine;

public static class TeamManagement
{


    public static DotaTeam FindTeamByName(string teamname)
    {
        return GameCore.teamsInGame.Find(i => i.GetTeamName() == teamname);

    }

    public static int FindTeamIndexByName(string teamname)
    {
        return GameCore.teamsInGame.IndexOf(GameCore.teamsInGame.Find(i => i.GetTeamName() == teamname));

    }

    public static void RemovePlayerFromTeam(string playername, string teamname)
    {
        DotaTeam foundteam = GameCore.teamsInGame.Find(i => i.GetTeamName() == teamname);
        if (foundteam != null)
        {
            DotaPlayer foundplayer = foundteam.getList().Find(p => p.name == playername);
            if (foundplayer != null)
            {
                 foundteam.getList().Remove(foundplayer);
                Debug.Log("removed " + foundplayer.name + " from team " + foundteam.GetTeamName());
            }
            else
            {
            Debug.Log("player/team combination not found. Nothing happened");
            }

        }
        else
        {
            Debug.Log("player/team combination not found. Nothing happened");
        }
    }

    public static void RemovePlayerFromTeam(string playername, DotaTeam team)
    {
        DotaTeam foundteam = GameCore.teamsInGame.Find(i => i == team) ;
        if (foundteam != null)
        {
            DotaPlayer foundplayer = foundteam.getList().Find(p => p.name == playername);
            if (foundplayer != null)
            {
                 foundteam.getList().Remove(foundplayer);
                Debug.Log("removed " + foundplayer.name + " from team " + team.GetTeamName());
            }
            else
            {
            Debug.Log("player/team combination not found. Nothing happened");
            }

        }
        else
        {
            Debug.Log("player/team combination not found. Nothing happened");
        }

    }

    public static void RemovePlayerFromTeam(DotaPlayer player, string teamname)
    {
        DotaTeam foundteam = GameCore.teamsInGame.Find(i => i.GetTeamName() == teamname);
        if (foundteam != null)
        {
            DotaPlayer foundplayer = foundteam.getList().Find(p => p == player);
            if (foundplayer != null)
            {
                 foundteam.getList().Remove(foundplayer);
                Debug.Log("removed " + foundplayer.name + " from team " + foundteam.GetTeamName());
            }
            else
            {
            Debug.Log("player/team combination not found. Nothing happened");
            }

        }
        else
        {
            Debug.Log("player/team combination not found. Nothing happened");
        }

    }

    public static void RemovePlayerFromTeam(DotaPlayer player, DotaTeam team)
    {
        DotaTeam foundteam = GameCore.teamsInGame.Find(i => i == team) ;
        if (foundteam != null)
        {
            DotaPlayer foundplayer = foundteam.getList().Find(p => p == player);
            if (foundplayer != null)
            {
                 foundteam.getList().Remove(foundplayer);
                Debug.Log("removed " + foundplayer.name + " from team " + team.GetTeamName());
            }
            else
            {
            Debug.Log("player/team combination not found. Nothing happened");
            }

        }
        else
        {
            Debug.Log("player/team combination not found. Nothing happened");
        }

    }

    public static void SwapPlayersTeams(DotaPlayer playerA, DotaPlayer playerB)
    {
        DotaTeam playerAteam = GameCore.teamsInGame.Find(i => i.GetTeamName() == playerA.team);
        playerAteam.RemovePlayer(playerA);
        DotaTeam playerBteam = GameCore.teamsInGame.Find(i => i.GetTeamName() == playerB.team);
        playerBteam.RemovePlayer(playerB);

        playerAteam.AddPlayer(playerB);
        playerBteam.AddPlayer(playerA);
    }

    public static void SwapPlayersTeams(string playerAname, string playerBname)
    {
        DotaPlayer playerA = GameCore.allPlayers.Find(i => i.name == playerAname);
        DotaPlayer playerB = GameCore.allPlayers.Find(i => i.name == playerBname);
        DotaTeam playerAteam = GameCore.teamsInGame.Find(i => i.GetTeamName() == playerA.team);
        playerAteam.RemovePlayer(playerA);
        DotaTeam playerBteam = GameCore.teamsInGame.Find(i => i.GetTeamName() == playerB.team);
        playerBteam.RemovePlayer(playerB);

        playerAteam.AddPlayer(playerB);
        playerBteam.AddPlayer(playerA);
    }
}
