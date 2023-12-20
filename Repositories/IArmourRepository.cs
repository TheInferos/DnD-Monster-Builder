using Armours;

namespace Monster_Builder_Web_API.Repositories
{
    public interface IArmourRepository
    {
        Dictionary<string, Armour> Armours { get; }

        IEnumerable<Armour> GetAllArmour();
        Armour GetArmour(string id);
        bool UpdateArmour(Armour armour);
    }
}