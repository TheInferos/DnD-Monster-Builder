using Armours;
using Monster_Builder_Web_API.Models.Exceptions;
using System.Text.Json;

namespace Monster_Builder_Web_API.Repositories;

/// <summary>
/// Could later replace the file store with another data source
/// Changes are not persisted. If you want them to persist I would
/// save changes to the file as they are made rather than add a save method
/// it would be closer to how things would work with an external datastore. 
/// 
/// Logic in here should be confined to data access, handling errors around that, and retrying access calls
/// Most validation should be on the constructor of the armour.
/// </summary>
public class ArmourRepository : IArmourRepository
{
    private Dictionary<string, Armour> armourCache;

    public ArmourRepository()
    {
        armourCache = GetArmoursFromFile("Data/Armours.json");
    }

    private Dictionary<string, Armour> GetArmoursFromFile(string filePath)
    {
        string jsonData = File.ReadAllText(filePath);
        var armours = JsonSerializer.Deserialize<Dictionary<string, Armour>>(jsonData);

        if( armours == null || armours.Count == 0)
        {
            throw new Exception($"No armours found in file {filePath}");
        }

        return armours;
    }

    /// <summary>
    /// Returns the first armour matching the provided name
    /// Throws an exception if none exist
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public Armour GetArmour(string name)
    {
        return armourCache[name];
    }

    /// <summary>
    /// Adds a new armour
    /// </summary>
    /// <param name="armour"></param>
    /// <returns>True if the armour was sucessfully added</returns>
    /// <exception cref="Exception">Throws if a conflict was found</exception>
    public bool CreateArmour(Armour armour) {

        if(armourCache.ContainsKey(armour.Name))
        {
            //Could change for logging and return false or return status enums but its easy enough to handle the exception.
            throw new ConflictException($"Conflict armour {armour.Name} already exists, use update.");
        }

        armourCache.Add(armour.Name, armour);    

        return true;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="armour"></param>
    /// <returns></returns>
    public bool UpdateArmour(Armour armour)
    {
        if(armourCache.ContainsKey(armour.Name))
        {
            armourCache[armour.Name] = armour;
            return true;
        }
        throw new Exception($"Armour {armour.Name} not found, use create.");
    }

    /// <summary>
    /// Deletes armour from the repository if it exits
    /// </summary>
    /// <param name="name"></param>
    /// <returns>True if the item was removed
    /// False if nothing was found to delete</returns>
    public bool DeleteArmour(string name)
    {
        return armourCache.Remove(name);
    }

    public IEnumerable<Armour> GetAllArmour()
    {
        return armourCache.Values.ToList();
    }
}
