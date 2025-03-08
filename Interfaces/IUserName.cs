namespace NexiumFramework.Interfaces;

interface IUserName
{
    public void Set(SteamId steamId, string userName);
    public string Get(SteamId steamId);
}