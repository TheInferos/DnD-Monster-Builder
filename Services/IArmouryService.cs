using Monster_Builder_Web_API.Models;

namespace Monster_Builder_Web_API.Services
{
    public interface IArmouryService
    {
        Armour GetArmourByName(string name);
        Weapon GetWeaponByName(string name);
        Dictionary<string, List<string>> GetArmourNames();
    }
}