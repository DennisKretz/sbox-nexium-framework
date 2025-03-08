using System;

namespace NexiumFramework.Services;

public class DatabaseService //TODO: save to OrganizationData instead of Data
{
    public void CreateFile<T>(string fileName, T dbModel)
    {
        if (IsFileAvailable(fileName))
        {   
            throw new Exception("Cannot create file:" + fileName + " already exists");
        }

        FileSystem.Data.WriteJson(fileName, dbModel); // delete the default values in the json file or else it will error
    }

    public string ReadFile<T>(string fileName)
    {
        return FileSystem.Data.ReadAllText(fileName);
    }

    public void WriteFile(string fileName, string data)
    {
        FileSystem.Data.WriteAllText(fileName, data);
    }

    public bool IsFileAvailable(string fileName)
    {
        return FileSystem.Data.FileExists(fileName);
    }
}