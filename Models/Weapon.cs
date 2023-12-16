using Monster_Builder_Web_API.Models;
using System.Text.Json.Serialization;

namespace Monster_Builder
{

    public class Weapon
    {
        private string _name { get; set; }
        private string _damage { get; set; }
        public List<string> Properties { get; set; }
        private int _cost { get; set; }
        private int _weight { get; set; }


        public string Name
        {
            get { return _name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException("Name must not be empty");
                _name = value;
            }
        }
        public WeaponType Type { get; set; }
        public string Damage {
            get { return _damage; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException("Damage must not be empty");
                _damage = value;
            }
        }
        //public List<string> Properties { { return _} set; }
        public bool Martial { get; set; }
        public bool Ranged { get; set; }
        public int Cost {
            get
            {
                return _cost;
            }
            set
            {
                ArgumentOutOfRangeException.ThrowIfNegative(value);
                _cost = value;
            }
        }
        public int Weight {
            get
            {
                return _weight;
            }
            set
            {
                ArgumentOutOfRangeException.ThrowIfNegative((int)value);
                _weight = value;
            }
        }

        public Weapon(string name, WeaponType type, string damage, List<string> properties, bool martial, bool ranged, int cost, int weight) 
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
