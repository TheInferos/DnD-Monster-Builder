using System.Text.Json;
using Monster_Builder_Web_API.Models;
using Armours;

namespace Monster_Builder
{
    public class ArmouryManager
    {
        public Dictionary<string, Armour> armours;
        public Dictionary<string, Weapon> weapons;
        public ArmouryManager()
        {
            LoadArmoursFromFile("Armours.json");
            LoadWeaponsFromFile("Weapons.json");
            //manager.PrintArmourDetails();
        }
        public void LoadArmoursFromFile(string filePath)
        {
            string jsonData = File.ReadAllText(filePath);
            armours = JsonSerializer.Deserialize<Dictionary<string, Armour>>(jsonData);
        }

        public void LoadWeaponsFromFile(string filePath)
        {
            string jsonData = File.ReadAllText(filePath);
            weapons = JsonSerializer.Deserialize<Dictionary<string, Weapon>>(jsonData);
        }

        public void PrintArmourDetails()
        {
            if (armours == null)
            {
                Console.WriteLine("Armours not loaded. Load armours first.");
                return;
            }
            string message = "";
            foreach (var armour in armours)
            {
                message += $@"
                    Armour: {armour.Key}
                    AC: {armour.Value.AC}
                    Type: {armour.Value.Type}
                    Cost: {armour.Value.Cost}
                    Weight: {armour.Value.Weight}
                    Strength Requirement: {armour.Value.Strength}
                    Stealth: {armour.Value.Stealth}";
                message += "\n";

            }
            Console.WriteLine(message.Replace("\t", "").Replace("    ", ""));
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