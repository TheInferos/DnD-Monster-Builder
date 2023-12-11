using Armours;

namespace Monster_Builder_Web_API.Repositories;


public interface IArmourRepository
{
    public Armour GetArmour(string name);
    public bool CreateArmour(Armour armour);
    public bool UpdateArmour(Armour armour);
    public bool DeleteArmour(string name);
    public IEnumerable<Armour> GetAllArmour();
}
