using Armours;
using System.Text.Json;
using Weapons;

namespace Monster_Builder_Web_API.Repositories
{
    public class WeaponRepository
    {
        private Dictionary<string, Weapon> Weapons;
    

        public WeaponRepository()
        {
            Weapons = GetWeaponsFromFile("Data/Weapons.json");
        }

        private Dictionary<string, Weapon> GetWeaponsFromFile(string filePath)
        {
            string jsonData = File.ReadAllText(filePath);
            var weapons = JsonSerializer.Deserialize<Dictionary<string, Weapon>>(jsonData);

            if (weapons == null || weapons.Count == 0)
            {
                throw new Exception($"No armours found in file {filePath}");
            }

            return weapons;
        }
        public Weapon GetWeapon(string id)
        {
            return Weapons[id];
        }


        public bool UpdateWeapon(Weapon weapon)
        {
            if (Weapons.ContainsKey(weapon.ID))
            {
                Weapons[weapon.ID] = weapon;
                return true;
            }
            throw new Exception($"Weapon {weapon.Name} not found, use create.");
        }

        public IEnumerable<Weapon> GetAllWeapons()
        {
            return Weapons.Values.ToList();
        }
    }
}
