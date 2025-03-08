using NexiumFramework.Database;

namespace NexiumFramework.Handlers;

public class UserNameHandler
{   
    protected ORM.Player playerORM = new ORM.Player();

    public virtual string GetUserName(SteamId steamId)
    {   
        return playerORM.GetUserName(steamId);
    }

    public virtual void SetUserName(SteamId steamId, string userName)
    {
        playerORM.ChangeUserName(steamId, userName);
    }
}