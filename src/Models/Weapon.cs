using System.Collections.Generic;
using System.Text.Json.Serialization;
using Monster_Builder_Web_API.src.Models.DTOs;
using Monster_Builder_Web_API.src.Models.ENUM;

namespace Monster_Builder_Web_API.src.Models
{
    /// <summary>
    /// This Class contains all the methods of the Weapon Item.
    /// This inherets methods and properties from Item class as weapons are a type of item.
    /// </summary>
    public class Weapon : Item
    {
        private string damage { get; set; } = string.Empty;
        private List<string> properties { get; set; } = [];

        /// <summary>
        /// This is a string list of all the properties that the weapon has
        /// TODO if this turns into more these should do things but for now they do not do anything but describe
        /// </summary>
        public List<string> Properties
        {
            get => properties;
            init
            {
                properties = value;
            }
        }

        /// <summary>
        /// This is where the damage that the weapon does is stored. 
        /// TODO:
        /// For now it is a string however this should be a class even if curerntly all it does is return the string
        /// </summary>
        public string Damage
        {
            get { return damage; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException(nameof(value), "Damage must not be empty");
                damage = value;
            }
        }
        /// <summary>
        /// This is a boolean for wether the weapon is a Martial (true) or Simple (false)
        /// </summary>
        public bool Martial { get; set; }
        /// <summary>
        /// This defines wether the weapon is a Ranged (true) or Melee( false). Thrown weapons should be set to false.
        /// </summary>
        public bool Ranged { get; set; }

        /// <summary>
        /// This is the full constructor for a weapon where all attributes are defined.
        /// </summary>
        /// <param name="_weapon"> This is the DTO object to make things easier to use</param>
        public Weapon(WeaponDTO _weapon)
        {
            id = Guid.NewGuid().ToString();
            type = ItemType.Weapon;
            Name = _weapon.Name;
            Damage = _weapon.Damage;
            properties = _weapon.Properties;
            Martial = _weapon.Martial;
            Ranged = _weapon.Ranged;
            Cost = _weapon.Cost;
            Weight = _weapon.Weight;
            actions = [];
            AddAction();
        }
        /// <summary>
        /// This is a constructor for a weapon when just a name is provided. 
        /// TODO: Really this consturctor shouldn't exist and should be removed. However it is used as the Unarmed constructor and that needs ammending first
        /// </summary>
        /// <param name="name"></param>
        public Weapon(string name)
        {
            id = Guid.NewGuid().ToString();
            Name = name;
            type = ItemType.Weapon;
            Damage = "d4";
            properties = [];
            Martial = false;
            Ranged = false;
            Cost = 0;
            Weight = 0;
            actions = [];
            AddAction();
        }
        /// <summary>
        /// This is the constructor that the WeaponRepository uses when building the weapons.
        /// </summary>
        [JsonConstructor]
        public Weapon()
        {
        }
        /// <summary>
        /// This function is used to add a new Action to the Weapon.
        /// </summary>
        public void AddAction()
        {
            // ActionType type, RechargeType recharge, ActionEffect effect)

            string ActionName = Name + " Attack";
            string ActionDescription = "An attack with a " + name;
            ActionEffect effect = new(Damage);
            CreatureAction action = new(ActionName, ActionDescription, ActionType.Action, RechargeType.Round, effect);
            actions.Add(action);
        }

        /// <summary>
        /// For debugging purposes this can return a simple pretty output.
        /// TODO: update with new properties when needed.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string message = "";
            message += $@"
                    Weapon: {Name}
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
