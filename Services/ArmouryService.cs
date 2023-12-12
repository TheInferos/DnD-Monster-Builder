using Armours;
using Monster_Builder;
using System.Text.Json;

namespace Monster_Builder_Web_API.Services
{
    public class ArmouryService
    {
        public Dictionary<string, Armour> armours;
        public Dictionary<string, Weapon> weapons;

        public ArmouryService()
        {
            armours = new Dictionary<string, Armour>();
            weapons = new Dictionary<string, Weapon>();
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

        public Weapon GetWeaponByName(string name)
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
            weapons = JsonSerializer.Deserialize<Dictionary<string, Weapon>>(jsonData);
        }
    }
}