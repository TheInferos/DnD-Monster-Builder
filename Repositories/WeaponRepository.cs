using System.Text.Json;
using Monster_Builder_Web_API.Models;

namespace Monster_Builder_Web_API.Repositories
{
    public class WeaponRepository : IWeaponRepository
    {
        private Dictionary<string, Weapon> weapons { get; set; }

        /// <summary>
        /// This is the public front of WeaponRepository getting will create a shallow copy 
        /// of the dictionary so that the dictionary itself cannot be ammended 
        /// but the weapons within it can be
        /// </summary>
        public Dictionary<string, Weapon> Weapons {
                get
            {
                    var copiedWeapons = new Dictionary<string, Weapon>();
                    foreach (var pair in weapons)
                    {
                        copiedWeapons.Add(pair.Key, pair.Value);
                    }
                    return copiedWeapons;
                }
            }
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
