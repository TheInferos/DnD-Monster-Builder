using Monster_Builder_Web_API.Models;

namespace Monster_Builder_Web_API.Repositories
{
    public interface IWeaponRepository
    {
        Dictionary<string, Weapon> weapons { get; set; }
        Dictionary<string, Weapon> Weapons { get; }

        IEnumerable<Weapon> GetAllWeapons();
        Weapon GetWeapon(string id);
        bool UpdateWeapon(Weapon weapon);
        void WriteWeapons();
    }
}