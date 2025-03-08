namespace NexiumFramework.Handlers;

using NexiumFramework.Database;

public class PlayerHandler
{
    private ORM.Player playerORM = new ORM.Player();
    public void CreateNewPlayer(SteamId steamId)
    {   
        Log.Info("[NEXIUM] -> CREATING NEW PLAYER");
        playerORM.CreatePlayer(steamId);
    }

    public object GetPlayerObject(SteamId steamId)
    {
        Log.Info("[NEXIUM] -> GETTING PLAYER OBJECT");
        return playerORM.GetBySteamId(steamId);
    }
}