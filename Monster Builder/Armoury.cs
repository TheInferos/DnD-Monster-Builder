using System.Text.Json;


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

            foreach (var armour in armours)
            {
                Console.WriteLine($"Name: {armour.Value.Name}");
                Console.WriteLine($"AC: {armour.Value.AC}");
                Console.WriteLine($"Cost: {armour.Value.Cost}");
                Console.WriteLine($"Weight: {armour.Value.Weight}");
                Console.WriteLine($"Strength: {armour.Value.Strength}");
                Console.WriteLine($"Stealth: {armour.Value.Stealth}");
                Console.WriteLine($"Type: {armour.Value.Type}");
                Console.WriteLine();
            }
        }
    }

    public class Armour
    {
        public string Name { get; set; }
        public int AC { get; set; }
        public int? Cost { get; set; }
        public int? Weight { get; set; }
        public int? Strength { get; set; }
        public string? Stealth { get; set; }
        public string? Type { get; set; }

    }

    public class Weapon
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Damage { get; set; }
        public string[] Properties { get; set; }
        public bool Martial { get; set; }
        public bool Ranged { get; set; }
        public int Cost { get; set; }
        public int Weight { get; set; }
    }

}