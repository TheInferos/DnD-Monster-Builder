using System.Text.Json.Serialization;
using Monster_Builder_Web_API.Models.Enum;
using Monster_Builder_Web_API.Models.DTOs;
using Microsoft.AspNetCore.Mvc.Formatters;


namespace Monster_Builder_Web_API.Models

{
    /// <summary>
    /// This is the Class where Monsters are created there core information is held. This uses Armour, Weapon, Creature Actions, Statline
    /// TODO: Add in Creature Class and this can extend that class for NPC/ charecters that aren't intended to 
    /// Have the same level of detail as playable charecters
    /// </summary>
    public class Monster
    {
        /// <summary>
        /// This is the name of the monster to be stored
        /// </summary>
        public string Name { get; set; } = string.Empty;
        /// <summary>
        /// This is the ID that the monster is stored under
        /// </summary>
        public string ID { get; init; } = Guid.NewGuid().ToString();
        /// <summary>
        /// This contains the challenge rating of the monster. Typically this should be 0+ 
        /// (max expected is 30 but it can go higher)
        /// Change to Float to account for 1/2 and 1/4
        /// </summary>
        public int CR { get; set; } =  1;
        /// <summary>
        /// This is the monsters Size
        /// TODO: Switch to Enum
        /// </summary>
        public string Size { get; set; } = string.Empty;
        /// <summary>
        /// This is the monster Type 
        /// TODO: Switch to Enum containing the options
        /// </summary>
        public string Type { get; set; } = string.Empty;
        /// <summary>
        /// This is a list of actions  that the monster has indcluding ones imported from weapons and armour
        /// </summary>
        public List<CreatureAction> CreatureActions { get; set; } = [];
        /// <summary>
        /// This is a list of weapons that the monster has.
        /// </summary>
        public List<Weapon> Weapons { get; set; } = [];
        /// <summary>
        /// This is the armour that the monster has equipt. There can only be one.
        /// TODO: add item list for holding. That way more armours can be held even if not used
        /// </summary>
        public Armour Armour { get; set; } = new Armour();
        /// <summary>
        /// This is the statline for the Monster, This is self contained and can be accessed to get the relevant Stats
        /// </summary>
        public Statline Stats { get; set; } = new Statline();
        /// <summary>
        /// TODO, this is a work in progress, but this should be used to calculate stats
        /// </summary>
        private int Statpool { get; set; } = 0;

        /// <summary>
        /// This is the constructor for monster from the Webpage
        /// </summary>
        /// <param name="name">This is the name of the monster</param>
        /// <param name="cr">This is the Challenge rating of the monster. Also used to work out hitpoints</param>
        /// <param name="hd">This is the hid die size. Used to calculate hitpoints</param>
        public Monster(string name, int cr, int hd)
        {
            Name = name;
            CR = cr;
            Stats = new Statline(hd, cr);
            Size = "Medium";
            Type = "Humanoid";
            Statpool = 8 + 2 * CR;
            Weapons = [new Weapon("unarmed")];
            Armour = new Armour("None");
        }

        /// <summary>
        /// This is the constructor for the Monsters to use. 
        /// Update this when new values are added to add to storage on initial build
        /// </summary>
        [JsonConstructor]
        public Monster()
        {

        }

        /// <summary>
        /// For Debugging purposes this is a pretty print of some of the Core Monster Information
        /// </summary>
        /// <returns>a prettified string of the monster</returns>
        public override string ToString()
        {
            string message = "";
            message += $@"
                    Name: {Name}
                    CR: {CR}
                    Type: {Type}
                    Stats: {Stats}
                    Weapons: {Weapons[0]}
                    Armour: {Armour}";
            message += "\n";
            return message.Replace("\t", "").Replace("    ", "");
        }

        /// <summary>
        /// This will add a wepaon to the monster list
        /// </summary>
        /// <param name="weapon">This is the weapon to add to the monster</param>
        public void AddWeapon(Weapon weapon)
        {
            Weapons.Add(weapon); 
            CreatureActions.AddRange(weapon.GetItemActions());
        }

        /// <summary>
        /// This is the armour that the monster will wear. This overwrites previously worn armour.
        /// TODO: When implementing Actions on Armour hthis will need rto remove actions given. 
        /// </summary>
        /// <param name="armour"></param>
        public void ChangeArmour(Armour armour)
        {
            Armour = armour;
            CalculateAC();

        }
        /// <summary>
        /// This should overwrite the stats with newly provided stats and then recalculate the relevant stats
        /// </summary>
        /// <param name="data">This is the new statblock values for the monster</param>
        public void UpdateStats(StatblockDTO data)
        {
            Stats.ChangeStats(data);
            CalculateAC();
        }

        private void CalculateAC()
        {
            Stats.AC = Armour.AC;
            switch (Armour.Type)
            {
                case ArmourType.Heavy:
                    break;
                case ArmourType.Medium:
                    int dexMod = (Stats.Dexterity / 2) - 5;
                    if (dexMod > 2)
                    {
                        Stats.AC += 2;
                    }
                    else
                    {
                        Stats.AC += dexMod;
                    }
                    break;
                case ArmourType.Light:
                case ArmourType.Natural:
                case ArmourType.Spell:
                case ArmourType.Other:
                    Stats.AC += (Stats.Dexterity / 2) - 5;
                    break;
                default:
                    throw new NotImplementedException($"AC calculation for {Armour.Type} not implemented");
            }

        }

    }
}
