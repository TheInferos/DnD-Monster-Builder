using System.Text.Json;
using Armours;
using Monster_Builder;
using Monster_Builder_Web_API.Repositories;

namespace Monster_Builder_Web_API.Services
{
    public class ArmouryService
    {
        public Dictionary<string, Weapon> weapons;

        public ArmouryService(IArmourRepository armourRepository)
        {
            _armourRepository = armourRepository;
            weapons = new Dictionary<string, Weapon>();
            LoadBaseWeapons();
        }
        public void LoadBaseWeapons()
        {
            LoadWeaponsFromFile("Data/Weapons.json");
        }

        public Weapon GetWeaponByName(string name)
        {
            return weapons[name];
        }

        public void LoadWeaponsFromFile(string filePath)
        {
            string jsonData = File.ReadAllText(filePath);
            weapons = JsonSerializer.Deserialize<Dictionary<string, Weapon>>(jsonData);
        }

        public void PrintWeaponDetails()
        {
            if (weapons == null)
            {
                Console.WriteLine("Weapons not loaded. Load weapons first.");
                return;
            }
            string message = "";
            foreach (var weapon in weapons)
            {
                message += $@"
                    Weapon: {weapon.Key}
                    Type: {weapon.Value.Type}
                    Damage: {weapon.Value.Damage}
                    Properties: {string.Join(", ", weapon.Value.Properties)}
                    Cost: {weapon.Value.Cost}
                    Weight: {weapon.Value.Weight}
                    Martial: {weapon.Value.Martial}
                    Ranged: {weapon.Value.Ranged}";
                message += "\n";
            }
            Console.WriteLine(message.Replace("\t", "").Replace("    ", ""));
        }
    }
}