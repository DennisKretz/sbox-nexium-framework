namespace NexiumFramework.Interfaces;

interface IJob
{
    void Join(SteamId steamId, string identifier);
    void Leave(SteamId steamId);

    void Create(string identifier, string name, int salary, bool isWhitelist);
    void Delete(string identifier);
}