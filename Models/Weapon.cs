using Monster_Builder_Web_API.Models;
using System.Text.Json.Serialization;

namespace Weapons
{

    public class Weapon
    {
        private string name { get; set; }
        private string damage { get; set; }
        public List<string> Properties { get; set; }
        private int cost { get; set; }
        private int weight { get; set; }

        public string ID { get; set; }
        public string Name
        {
            get { return name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException("Name must not be empty");
                name = value;
            }
        }
        public WeaponType Type { get; set; }
        public string Damage {
            get { return damage; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException("Damage must not be empty");
                damage = value;
            }
        }
        //public List<string> Properties { { return _} set; }
        public bool Martial { get; set; }
        public bool Ranged { get; set; }
        public int Cost {
            get
            {
                return cost;
            }
            set
            {
                ArgumentOutOfRangeException.ThrowIfNegative(value);
                cost = value;
            }
        }
        public int Weight {
            get
            {
                return weight;
            }
            set
            {
                ArgumentOutOfRangeException.ThrowIfNegative((int)value);
                weight = value;
            }
        }

        public Weapon(string name, WeaponType type, string damage, List<string> properties, bool martial, bool ranged, int cost, int weight) 
        {
            ID = Guid.NewGuid().ToString();
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
            ID = Guid.NewGuid().ToString();
            Name = name;
            Type = WeaponType.Melee;
            Damage = "d4";
            Properties = [];
            Martial = false;
            Ranged = false;
            Cost = 0;
            Weight =01;
        }

        [JsonConstructor]
        public Weapon()
        {
            // Default constructor without parameters
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
