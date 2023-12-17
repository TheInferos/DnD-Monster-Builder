using Armours;
using Weapons;
using System.Text.Json;
using Monster_Builder_Web_API.Repositories;

namespace Monster_Builder_Web_API.Services
{
    public class ArmouryService
    {
        public ArmourRepository Armoury;
        public Dictionary<string, Weapons.Weapon> weapons;

        public ArmouryService()
        {
            armours = new Dictionary<string, Armour>();
            weapons = new Dictionary<string, Weapons.Weapon>();
            LoadBaseArmours();
            LoadBaseWeapons();
        }

        public void LoadBaseArmours()
        {
            LoadArmoursFromFile("Data/Armours.json");
        }
        public void LoadBaseWeapons()
        {
            LoadWeaponsFromFile("Data/Weapons.json");
        }
        public Armour GetArmourByName(string name)
        {
            return armours[name];
        }

        public Weapons.Weapon GetWeaponByName(string name)
        {
            return weapons[name];
        }

        private void LoadArmoursFromFile(string filePath)
        {
            string jsonData = File.ReadAllText(filePath);
            armours = JsonSerializer.Deserialize<Dictionary<string, Armour>>(jsonData);
        }

        private void LoadWeaponsFromFile(string filePath)
        {
            string jsonData = File.ReadAllText(filePath);
            weapons = JsonSerializer.Deserialize<Dictionary<string, Weapons>>(jsonData);
        }
    }
}