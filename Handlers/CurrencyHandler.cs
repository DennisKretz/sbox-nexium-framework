using NexiumFramework.Database;
using NexiumFramework.Interfaces;

namespace NexiumFramework.Handlers;

public class CurrencyHandler
{
    private ORM.Player playerORM = new ORM.Player();

    public void TakeCurrency(SteamId steamId, int  amount)
    {
        playerORM.TakeCurrency(steamId, amount);
        IPlayerEvent.Post(x => x.OnMoneyTaken(steamId, amount));
    }

    public void GiveCurrency(SteamId steamId, int amount)
    {
        playerORM.GiveCurrency(steamId, amount);
        IPlayerEvent.Post(x => x.OnMoneyReceived(steamId, amount));
    }

    public int GetCurrency(SteamId steamId)
    {
        return playerORM.GetCurrency(steamId);
    }
}