namespace NexiumFramework.Database;

using System.Text.Json;
using Models;
using Services;

public class ORM
{
    private static DatabaseService databaseService = new DatabaseService();

    public class Player : PlayerModel
    {
        private const string databaseName = "players.json";
        private PlayerModel playerModel = new PlayerModel();
        private Dictionary<string, PlayerModel> players = new();

        public Player()
        {
            if (databaseService.IsFileAvailable(databaseName) == false)
            {
                databaseService.CreateFile(databaseName, playerModel);
            } else {
                string jsonString = databaseService.ReadFile<Dictionary<string, PlayerModel>>(databaseName);
                players = JsonSerializer.Deserialize<Dictionary<string, PlayerModel>>(jsonString);
            }
        }

        public PlayerModel GetBySteamId(SteamId steamId)
        {   
            if (players.ContainsKey(steamId.ToString())) 
            {
                return players[steamId.ToString()];
            }
            return null;
        }

        public void ChangeUserName(SteamId steamId, string userName)
        {
            players[steamId.ToString()].UserName = userName;

            string jsonString = JsonSerializer.Serialize(players, new JsonSerializerOptions {WriteIndented = true});
            databaseService.WriteFile(databaseName, jsonString);
        }

        public string GetUserName(SteamId steamId)
        {
            return players[steamId.ToString()].UserName;
        }

        public void CreatePlayer(SteamId steamId)
        {
            var player = new PlayerModel {steamId=steamId.ToString()};
            players[player.steamId] = player;

            string jsonString = JsonSerializer.Serialize(players, new JsonSerializerOptions {WriteIndented = true});
            databaseService.WriteFile(databaseName, jsonString);
        }

        public void TakeCurrency(SteamId steamId, int amount)
        {
            var money = players[steamId.ToString()].Money;
            players[steamId.ToString()].Money = money - amount;

            string jsonString = JsonSerializer.Serialize(players, new JsonSerializerOptions {WriteIndented = true});
            databaseService.WriteFile(databaseName, jsonString);
        }

        public void GiveCurrency(SteamId steamId, int amount)
        {
            var money = players[steamId.ToString()].Money;
            players[steamId.ToString()].Money = money + amount;

            string jsonString = JsonSerializer.Serialize(players, new JsonSerializerOptions {WriteIndented = true});
            databaseService.WriteFile(databaseName, jsonString);
        }

        public int GetCurrency(SteamId steamId)
        {
            return players[steamId.ToString()].Money;
        }

        public List<string> GetJobWhitelists(SteamId steamId)
        {
            return players[steamId.ToString()].WhitelistedJobs;
        }

        public void JoinJob(SteamId steamId, string identifier)
        {
            players[steamId.ToString()].Job = identifier;

            string jsonString = JsonSerializer.Serialize(players, new JsonSerializerOptions {WriteIndented = true});
            databaseService.WriteFile(databaseName, jsonString);
        }

        public void LeaveJob(SteamId steamId)
        {
            players[steamId.ToString()].Job = "Unknown"; //add default or fallback job?

            string jsonString = JsonSerializer.Serialize(players, new JsonSerializerOptions {WriteIndented = true});
            databaseService.WriteFile(databaseName, jsonString);
        }

        public void GiveJobWhitelist(SteamId steamId, string identifier)
        {
            var i = players[steamId.ToString()].WhitelistedJobs.Count();
            
            players[steamId.ToString()].WhitelistedJobs[i+1] = identifier;

            string jsonString = JsonSerializer.Serialize(players, new JsonSerializerOptions {WriteIndented = true});
            databaseService.WriteFile(databaseName, jsonString);
        }

        public void RemoveJobWhitelist(SteamId steamId, string identifier)
        {
            int i = 0;
            foreach (var whitelist in WhitelistedJobs)
            {
                if (whitelist == identifier) 
                {
                    players[steamId.ToString()].WhitelistedJobs[i] = null;

                    string jsonString = JsonSerializer.Serialize(players, new JsonSerializerOptions {WriteIndented = true});
                    databaseService.WriteFile(databaseName, jsonString);

                    break;
                }
                i++;
            }
        }
    }

    public class Job : JobModel
    {
        private const string databaseName = "jobs.json";
        private JobModel jobModel = new JobModel();
        private Dictionary<string, JobModel> jobs = new();

        public Job()
        {
            if (databaseService.IsFileAvailable(databaseName) == false)
            {
                databaseService.CreateFile(databaseName, jobModel);
            } else {
                string jsonString = databaseService.ReadFile<Dictionary<string, JobModel>>(databaseName);
                jobs = JsonSerializer.Deserialize<Dictionary<string, JobModel>>(jsonString);
            }
        }

        public void CreateJob(string identifier, string name, int salary, bool isWhitelist)
        {
            var job = new JobModel {Identifier=identifier, Name=name, IsWhitelist=isWhitelist, Salary=salary};
            jobs[job.Identifier] = job;
            
            string jsonString = JsonSerializer.Serialize(jobs, new JsonSerializerOptions {WriteIndented = true});
            databaseService.WriteFile(databaseName, jsonString);
        }

        public void DeleteJob(string identifier)
        {
            jobs[identifier] = null;

            string jsonString = JsonSerializer.Serialize(jobs, new JsonSerializerOptions {WriteIndented = true});
            databaseService.WriteFile(databaseName, jsonString);
        }

        public JobModel GetJobByIdentifier(string identifier)
        {
            return jobs[identifier];
        }
    }
}