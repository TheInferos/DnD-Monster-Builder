using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Monster_Builder_Web_API.Models.DTOs;
using Monster_Builder_Web_API.Models.ENUM;

namespace Monster_Builder_Web_API.Models
{
    /// <summary>
    /// This is the base for a class for armours to be stated and used
    /// The core information is contained within the armour.
    /// </summary>
    public class Armour : Item
    {
        private int ac = 0;
        private int strength = 0;
        /// <summary>
        /// This is the Armour class for the armour giving the baseline armour value
        /// </summary>
        public int AC
        {
            get
            {
                return ac;
            }
            set
            {
                ArgumentOutOfRangeException.ThrowIfNegativeOrZero(value);
                ac = value;
            }
        }
        /// <summary>
        /// This is the minimum strength required to wear the armour without affecing profficency
        /// </summary>
        public int Strength
        {
            get
            {
                return strength;
            }
            set
            {
                ArgumentOutOfRangeException.ThrowIfNegative(value);
                strength = value;
            }
        }
        /// <summary>
        /// This is a boolean of the default position if stealth is normal (true) or disadvantaged (false)
        /// </summary>
        public bool Stealth { get; set; }
        /// <summary>
        /// This defines what the type of armour is as an Enum which can be used by monsters
        /// When working out their AC
        /// </summary>
        public ArmourType Type { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_name"></param>
        /// <param name="_ac"></param>
        /// <param name="_cost"></param>
        /// <param name="_weight"></param>
        /// <param name="_strength"></param>
        /// <param name="_stealth"></param>
        /// <param name="_type"></param>
        public Armour(string _name, int _ac, int _cost, int _weight, int _strength, bool _stealth, ArmourType _type)
        {
            id = Guid.NewGuid().ToString();
            type = ItemType.Armour;
            Name = _name;
            AC = _ac;
            cost = _cost;
            weight = _weight;
            Strength = _strength;
            Stealth = _stealth;
            Type = _type;
        }
        /// <summary>
        /// This is the constructor from the webpage using the ArmourDTO to define the stats
        /// </summary>
        /// <param name="armour"></param>
        public Armour(ArmourDTO armour)
        {
            id = Guid.NewGuid().ToString();
            Validate(armour.Name, armour.AC, armour.Cost, armour.Strength);
            name = armour.Name;
            AC = armour.AC;
            Cost = armour.Cost;
            weight = armour.Weight;
            Strength = armour.Strength;
            Stealth = armour.Stealth;
            Type = armour.Type;
        }

        /// <summary>
        /// This is the constructor that ArmourRepository uses when importing. 
        /// </summary>
        [JsonConstructor]
        public Armour()
        {
        }
        /// <summary>
        /// TODO Remove
        /// This is a constructor for an armour where just a name is defined and is classified as natural. Used in the Monster Constructor class.
        /// </summary>
        /// <param name="name"></param>
        public Armour(string name)
        {
            id = Guid.NewGuid().ToString();
            Name = name;
            AC = 10;
            Cost = 0;
            weight = 0;
            Strength = 0;
            Stealth = false;
            Type = ArmourType.Natural;
        }
        /// <summary>
        /// Creates a string version of the Armour ( not a object)
        /// </summary>
        /// <returns>string\n</returns>
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
            List<Exception> validationErrors = [];
            if (string.IsNullOrWhiteSpace(name))
                validationErrors.Add(new ArgumentNullException(nameof(name), "Name cannot be null"));
            if (ac < 10)
                validationErrors.Add(new ArgumentOutOfRangeException(nameof(ac), "Ac must be an integer above 10"));
            if (cost < 0)
                validationErrors.Add(new ArgumentOutOfRangeException(nameof(cost), "Cost must be an integer above 0"));
            if (strength != null && strength < 13)
                validationErrors.Add(new ArgumentOutOfRangeException(nameof(strength), "Strength requirement must be above 12 or null"));

            if (validationErrors.Count > 0)
                throw new ValidationException(string.Join("; ", validationErrors));
        }
    }

}
