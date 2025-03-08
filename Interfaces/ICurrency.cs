namespace NexiumFramework.Interfaces;

interface ICurrency
{
    void Give(SteamId steamId, int amount);
    void Take(SteamId steamId, int amount);
    int Get(SteamId steamId);
}