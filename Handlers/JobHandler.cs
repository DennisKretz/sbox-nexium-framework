using NexiumFramework.Database;
using NexiumFramework.Database.Models;
using System;

namespace NexiumFramework.Handlers;

public class JobHandler
{
    private ORM.Player playerORM = new ORM.Player();
    private ORM.Job jobORM = new ORM.Job();

    public void CreateJob(string identifier, string name, int salary, bool isWhitelist) // prevent creating job with a already existing identifier
    {
        jobORM.CreateJob(identifier, name, salary, isWhitelist);
    }

    public void DeleteJob(string identifier)
    {
        jobORM.DeleteJob(identifier);
    }

    public void JoinJob(SteamId steamId, string identifier)
    {
        JobModel job = jobORM.GetJobByIdentifier(identifier);
        PlayerModel player = playerORM.GetBySteamId(steamId);

        if (job is null) { throw new Exception("Cannot find job with identifier: " + identifier); }
        if (player.Job == identifier) { return; }
        if (job.IsWhitelist && HasWhitelist(identifier, player) == false) { return; }
        
        playerORM.JoinJob(steamId, job.Identifier);
    }

    public void LeaveJob(SteamId steamId)
    {
        playerORM.LeaveJob(steamId);
    }

    public void GiveJobWhitelist(SteamId steamId, string identifier)
    {
        JobModel job = jobORM.GetJobByIdentifier(identifier);
        PlayerModel player = playerORM.GetBySteamId(steamId);

        if (job is null) { throw new Exception("Cannot find job with identifier: " + identifier); }
        if (HasWhitelist(identifier, player)) { return; }

        playerORM.GiveJobWhitelist(steamId, identifier);
    }

    public void RemoveJobWhitelist(SteamId steamId, string identifier)
    {
        JobModel job = jobORM.GetJobByIdentifier(identifier);
        PlayerModel player = playerORM.GetBySteamId(steamId);

        if (job is null) { throw new Exception("Cannot find job with identifier: " + identifier); }
        if (HasWhitelist(identifier, player) == false) { return; }

        playerORM.RemoveJobWhitelist(steamId, identifier);
    }

    private bool HasWhitelist(string identifier, PlayerModel player)
    {
        foreach (var whitelist in player.WhitelistedJobs) {
            if (identifier == whitelist) { return true; }
        }
        return false;
    }
}