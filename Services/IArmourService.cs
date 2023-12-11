using Armours;
using Monster_Builder_Web_API.Models;

namespace Monster_Builder_Web_API.Services;

public interface IArmourService
{
    IEnumerable<Armour> GetAllArmour();
    bool AddNewArmour(ArmourDTO newArmour);
    Armour GetArmourByName(string name);
}