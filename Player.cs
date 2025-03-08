using NexiumFramework.Handlers;
using NexiumFramework.Interfaces;

namespace NexiumFramework.Core;
// dont ask wtf i did here, i also dont know why
public class Player
{   
    readonly UserName userName;
    readonly Currency currency;
    readonly Job job;
    readonly PlayerHandler playerHandler = new PlayerHandler();
    public SteamId steamId {get; set;}

    public Player(SteamId steamId)
    {
        this.steamId = steamId;

        userName = new UserName();
        currency = new Currency();
        job = new Job();
    }

    public virtual string GetUserName()
    {
        return userName.Get(steamId);
    }

    public virtual void SetUserName(string username)
    {   
        userName.Set(steamId, username);
    }

    public virtual void Create()
    {
        playerHandler.CreateNewPlayer(steamId);
    }

    public virtual object Get()
    {
        return playerHandler.GetPlayerObject(steamId);
    }

    public virtual void GiveCurrency(int amount)
    {
        currency.Give(steamId, amount);
    }

    public virtual void TakeCurrency(int amount)
    {
        currency.Take(steamId, amount);
    }

    public virtual int GetCurrency()
    {
        return currency.Get(steamId);
    }

    public virtual void JoinJob(string identifier)
    {
        job.Join(steamId, identifier);
    }

    public virtual void GiveJobWhitelist(string identifier)
    {
        job.GiveWhitelist(steamId, identifier);
    }

    public virtual void RemoveJobWhitelist(string identifier)
    {
        job.RemoveWhitelist(steamId, identifier);
    }
}

public class UserName : IUserName
{
    private UserNameHandler userNameHandler = new UserNameHandler();
    public virtual void Set(SteamId steamId, string userName)
    {
        userNameHandler.SetUserName(steamId, userName);
    }

    public virtual string Get(SteamId steamId)
    {
        return userNameHandler.GetUserName(steamId);
    }
}

public class Currency : ICurrency
{
    private CurrencyHandler currencyHandler = new CurrencyHandler();
    public virtual void Take(SteamId steamId, int amount)
    {
        currencyHandler.TakeCurrency(steamId, amount);
    }

    public virtual void Give(SteamId steamId, int amount)
    {
        currencyHandler.GiveCurrency(steamId, amount);
    }

    public virtual int Get(SteamId steamId)
    {
        return currencyHandler.GetCurrency(steamId);
    }
}

public class Job : IJob
{
    private JobHandler jobHandler = new JobHandler();
    public virtual void Join(SteamId steamId, string identifier)
    {
        jobHandler.JoinJob(steamId, identifier);
    }

    public virtual void Leave(SteamId steamId)
    {
        jobHandler.LeaveJob(steamId);
    }

    public virtual void Create(string identifier, string name, int salary, bool isWhitelist)
    {
        jobHandler.CreateJob(identifier, name, salary, isWhitelist);
    }

    public virtual void Delete(string identifier)
    {
        jobHandler.DeleteJob(identifier);
    }

    public virtual void GiveWhitelist(SteamId steamId, string identifier)
    {
        jobHandler.GiveJobWhitelist(steamId, identifier);
    }

    public virtual void RemoveWhitelist(SteamId steamId, string identifier)
    {
        jobHandler.RemoveJobWhitelist(steamId, identifier);
    }
}