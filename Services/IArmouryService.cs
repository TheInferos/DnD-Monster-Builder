using Armours;
using Weapons;

namespace Monster_Builder_Web_API.Services
{
    public interface IArmouryService
    {
        Armour GetArmourByName(string name);
        Weapon GetWeaponByName(string name);
        Dictionary<string, List<string>> GetArmourNames();
    }
}