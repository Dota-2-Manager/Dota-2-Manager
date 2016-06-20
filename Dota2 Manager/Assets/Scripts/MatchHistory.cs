//using System.Collections ;
using System.Collections.Generic;
public static class MatchHistory
{
    private static readonly List<DotaGame> globalGameHistory = new List<DotaGame>();
    private static int dotaGameCount;

    public static void RecordGame(DotaGame g)
    {
        globalGameHistory.Add(g);
    }

    public static DotaGame GetGameDataFromID(int id)
    {
        DotaGame foundGame = globalGameHistory.Find(x => x.GetMatchID() == id);
        return foundGame; 
    }

    public static List<DotaGame> GetGlobalGameHistory()
    {
        return globalGameHistory;
    }

    public static int IncrementGameCount()
    {
        dotaGameCount++;
        return dotaGameCount;
    }



}
