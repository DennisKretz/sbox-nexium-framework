namespace NexiumFramework.Interfaces;

public interface IPlayerEvent : ISceneEvent<IPlayerEvent>
{
    void OnPlayerConnected(Connection connection);
    void OnMoneyReceived(SteamId steamId, int amount);
    void OnMoneyTaken(SteamId steamId, int amount);
}