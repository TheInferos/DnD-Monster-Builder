using System.Collections.Generic;
using System.Text.Json.Serialization;
using Monster_Builder_Web_API.Models.Enum;

namespace Monster_Builder_Web_API.Models
{

    public class Weapon
    {
        private string name { get; set; }
        private string damage { get; set; }
        public List<string> Properties { get; set; }
        private int cost { get; set; }

        private List<MonsterAction> actions { get; set; }
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
            actions = new List<MonsterAction>();
            AddAction();
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
            Weight =0;
            actions = new List<MonsterAction>();
            AddAction();
        }

        [JsonConstructor]
        public Weapon()
        {
            actions = new List<MonsterAction>();
            AddAction();
            // Default constructor without parameters
        }
        
        public void AddAction()
        {
            // ActionType type, RechargeType recharge, ActionEffect effect)

            string ActionName = name + "Attack";
            string ActionDescription = "An attack with a " + name;
            ActionEffect effect = new ActionEffect(damage);
            MonsterAction action = new MonsterAction(ActionName, ActionDescription, ActionType.Action, RechargeType.Round, effect);
            actions.Add(action);
        }
        public List<MonsterAction> GetMonsterActions()
        {
            return actions;
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
