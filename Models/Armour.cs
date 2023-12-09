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
        public string? Type { get; set; }

        public Armour(string name, int ac, int cost, int weight, int strength, bool stealth, string type) 
        { 
            Name = name;
            AC = ac;
            Cost = cost;
            Weight = weight;
            Strength = strength;
            Stealth = stealth;
            Type = type;
        }
        public Armour() 
        {
            Name = "Padded";
            AC = 11;
            Cost = 200;
            Weight = 4;
            Strength = 0;
            Stealth = false;
            Type = "Light";
        }
        public Armour(string name)
        {
            Name = name;
            AC = 11;
            Cost = 200;
            Weight = 4;
            Strength = 0;
            Stealth = false;
            Type = "Light";
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
    }
    
}
