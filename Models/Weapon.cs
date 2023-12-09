using System.Collections.Generic;

namespace Monster_Builder
{

    public class Weapon
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Damage { get; set; }
        public List<string> Properties { get; set; }
        public bool Martial { get; set; }
        public bool Ranged { get; set; }
        public int Cost { get; set; }
        public int Weight { get; set; }
    
        public Weapon(string name, string type, string damage, List<string> properties, bool martial, bool ranged, int cost, int weight) 
        {
            Name = name;
            Type = type;
            Damage = damage;
            Properties = properties;
            Martial = martial;
            Ranged = ranged;
            Cost = cost;
            Weight = weight;
        }
        public Weapon(string name)
        {
            Name = name;
            Type = "";
            Damage = "d4";
            Properties = [];
            Martial = false;
            Ranged = false;
            Cost = 0;
            Weight =01;
        }

        public override string ToString()
        {
            string message = "";
            message += $@"
                    Weapon: {Name}
                    Type: {Type}
                    Damage: {Damage}
                    Properties: {string.Join(", ", Properties)}
                    Cost: {Cost}
                    Weight: {Weight}
                    Martial: {Martial}
                    Ranged: {Ranged}";
            return message.Replace("\t", "").Replace("    ", "");
        }
    }
}
