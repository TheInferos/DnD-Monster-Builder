using Monster_Builder_Web_API.Models;
using Monster_Builder_Web_API.Models.DTOs;
using System.ComponentModel.DataAnnotations;

namespace Armours
{
    public class Armour
    {
        public string Name { get; set; }
        public int AC { get; set; }
        public int? Cost { get; set; }
        public int? Weight { get; set; }
        public int? Strength { get; set; }
        public bool? Stealth { get; set; }
        public ArmourType Type { get; set; }

        public Armour(string name, int ac, int cost, int weight, int strength, bool stealth, ArmourType type) 
        { 
            Name = name;
            AC = ac;
            Cost = cost;
            Weight = weight;
            Strength = strength;
            Stealth = stealth;
            Type = type;
        }
        public Armour(ArmourDTO armour)
        {

        }
        public Armour() 
        {
            Name = "Padded";
            AC = 11;
            Cost = 200;
            Weight = 4;
            Strength = 0;
            Stealth = false;
            Type = ArmourType.Light;
        }
        public Armour(string name)
        {
            Name = name;
            AC = 11;
            Cost = 200;
            Weight = 4;
            Strength = 0;
            Stealth = false;
            Type = ArmourType.Light;
        }
        public override string ToString()
        {
            string message = "";
             message += $@"
                    Armour: {Name}
                    AC: {AC}
                    Type: {Type}
                    Cost: {Cost}
                    Weight: {Weight}
                    Strength Requirement: {Strength}
                    Stealth: {Stealth}";
            message += "\n";
            return message.Replace("\t", "").Replace("    ", "");
        }
        private static void Validate(string name, int ac, int cost, int? strength)
        {
            //Lots of validation 
            List<Exception> validationErrors = new();
            if (string.IsNullOrWhiteSpace(name)) validationErrors.Add(new ArgumentNullException("Name cannot be null"));
            if (ac < 10) validationErrors.Add(new ArgumentOutOfRangeException("Ac must be an integer above 10"));
            if (cost < 0) validationErrors.Add(new ArgumentOutOfRangeException("Cost must be an integer above 0"));
            if (strength != null && strength < 13) validationErrors.Add(new ArgumentOutOfRangeException("Strenght requirement must be above 12 or null"));

            if (validationErrors.Count > 0)
            {
                throw new ValidationException(string.Join("; ", validationErrors));
            }
        }
    }
    
}
