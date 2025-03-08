using NexiumFramework.Interfaces;

namespace NexiumFramework.Core;

public class NexiumCore : Component, IPlayerEvent
{
    public virtual Player GetPlayer(SteamId steamId)
    {
        return new Player(steamId);
    }

    public virtual string GetUserName(SteamId steamId)
    {
        return new Player(steamId).GetUserName();
    }

    public virtual void SetUserName(SteamId steamId, string username)
    {
        new Player(steamId).SetUserName(username);
    }

	void IPlayerEvent.OnPlayerConnected(Connection connection)
	{   
        Player newPlayer = new Player(connection.SteamId);

        if (newPlayer.Get() is null) { newPlayer.Create(); }
	}

	void IPlayerEvent.OnMoneyReceived( SteamId steamId, int amount )
	{
		
	}

	void IPlayerEvent.OnMoneyTaken( SteamId steamId, int amount )
	{
		
	}

	public virtual void GiveCurrency(SteamId steamId, int amount)
    {
        new Player(steamId).GiveCurrency(amount);
    }

    public virtual void TakeCurrency(SteamId steamId, int amount)
    {
        new Player(steamId).TakeCurrency(amount);
    }

    public virtual int GetCurrency(SteamId steamId)
    {
        return new Player(steamId).GetCurrency();
    }

    public virtual void CreateJob(string identifier, string name, int salary, bool isWhitelist)
    {
        new Job().Create(identifier, name, salary, isWhitelist);
    }

    public virtual void DeleteJob(string identifier)
    {
        new Job().Delete(identifier);
    }

    public virtual void JoinJob(SteamId steamId, string identifier)
    {
        new Job().Join(steamId, identifier);
    }

    public virtual void LeaveJob(SteamId steamId)
    {
        new Job().Leave(steamId);
    }

    public virtual void GiveJobWhitelist(SteamId steamId, string identifier)
    {
        new Player(steamId).GiveJobWhitelist(identifier);
    }

    public virtual void RemoveJobWhitelist(SteamId steamId, string identifier)
    {
        new Player(steamId).GiveJobWhitelist(identifier);
    }
}