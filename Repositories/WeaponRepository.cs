using Armours;
using System.Text.Json;
using Weapons;

namespace Monster_Builder_Web_API.Repositories
{
    public class WeaponRepository : IWeaponRepository
    {
        public Dictionary<string, Weapon> weapons { get; set; }
        public Dictionary<string, Weapon> Weapons { get { return weapons; } }
        private string filePath;

        public WeaponRepository()
        {
            filePath = "Data/Weapons.json";
            weapons = GetWeaponsFromFile();
            WriteWeapons();
        }

        private Dictionary<string, Weapon> GetWeaponsFromFile()
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
        public void WriteWeapons()
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            File.WriteAllText(filePath, JsonSerializer.Serialize(weapons, options));
        }


        public bool UpdateWeapon(Weapon weapon)
        {
            if (Weapons.ContainsKey(weapon.ID))
            {
                Weapons[weapon.ID] = weapon;
                WriteWeapons();
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
