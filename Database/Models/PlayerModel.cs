namespace NexiumFramework.Database.Models;

public class PlayerModel
{
    public string steamId {get; set;} = "Unknown";
    public int Money {get; set;} = 0;
    public int Level {get; set;} = 0;
    public int Xp {get; set;} = 0;
    public string UserName {get; set;} = "Unknown";
    public string Job {get; set;} = "None";
    public List<string> WhitelistedJobs {get; set;} = [];
}