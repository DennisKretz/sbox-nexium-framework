namespace NexiumFramework.Components;

using NexiumFramework.Interfaces;

public sealed class GameNetworkManager : Component, Component.INetworkListener
{
    public void OnConnected(Connection connection)
    {
        IPlayerEvent.Post(x => x.OnPlayerConnected(connection));
    }
}