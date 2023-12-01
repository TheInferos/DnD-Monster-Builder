using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Monster_Builder;

namespace Monster_Builder
{
    public class ArmouryManager
    {
        public Dictionary<string, Armour> armours;

        public void LoadArmoursFromFile(string filePath)
        {
            string jsonData = File.ReadAllText(filePath);
            armours = JsonSerializer.Deserialize<Dictionary<string, Armour>>(jsonData);
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
                Console.WriteLine($"Name: {armour.Key}");
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
        public int AC { get; set; }
        public string Name { get; set; }
        public int? Cost { get; set; }
        public int? Weight { get; set; }
        public int? Strength { get; set; }
        public string Stealth { get; set; }
        public string Type { get; set; }
    }
}

public class Program
{
    static void Main()
    {
        ArmouryManager manager = new ArmouryManager();
        manager.LoadArmoursFromFile("Armour.json");
        //manager.PrintArmourDetails();
    }
}