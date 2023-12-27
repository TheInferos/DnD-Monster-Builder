using System.ComponentModel.DataAnnotations;
using Monster_Builder_Web_API.Models.DTOs;
using Monster_Builder_Web_API.Models.Enum;

namespace Monster_Builder_Web_API.Models
{
    /// <summary>
    /// This is the base for a class for armours to be stated and used
    /// The core information is contained within the armour.
    /// </summary>
    public class Armour
    {
        private string _name;
        private int _ac;
        private int _cost;
        private int _weight;
        private int _strength;
        /// <summary>
        /// This is the key that is used to access the armour in the future
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// This is the name of the armour. 
        /// </summary>
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
        /// <summary>
        /// This is the Armour class for the armour giving the baseline armour value
        /// </summary>
        public int AC
        {
            get
            {
                return _ac;
            }
            set
            {
                ArgumentOutOfRangeException.ThrowIfNegativeOrZero((int)value);
                _ac = value;
            }
        }
        /// <summary>
        /// This is the number of copper pieces that the armour costs.
        /// </summary>
        public int Cost
        {
            get
            {
                return _cost;
            }
            set
            {
                if (value != null)
                    ArgumentOutOfRangeException.ThrowIfNegative((int)value);
                _cost = value;
            }
        }
        /// <summary>
        /// This is the weight in lbs of the armour. 0 is a valid value for armour
        /// </summary>
        public int Weight
        {
            get
            {
                return _weight;
            }
            set
            {
                if (value != null)
                    ArgumentOutOfRangeException.ThrowIfNegative((int)value);
                _weight = value;
            }
        }
        /// <summary>
        /// This is the minimum strength required to wear the armour without affecing profficency
        /// </summary>
        public int Strength
        {
            get
            {
                return _strength;
            }
            set
            {
                if (value != null)
                    ArgumentOutOfRangeException.ThrowIfNegative((int)value);
                _strength = value;
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
        /// <param name="name"></param>
        /// <param name="ac"></param>
        /// <param name="cost"></param>
        /// <param name="weight"></param>
        /// <param name="strength"></param>
        /// <param name="stealth"></param>
        /// <param name="type"></param>
        public Armour(string name, int ac, int cost, int weight, int strength, bool stealth, ArmourType type) 
        {
            ID = Guid.NewGuid().ToString();
            Name = name;
            AC = ac;
            Cost = cost;
            Weight = weight;
            Strength = strength;
            Stealth = stealth;
            Type = type;
        }
        /// <summary>
        /// This is the constructor from the webpage using the ArmourDTO to define the stats
        /// </summary>
        /// <param name="armour"></param>
        public Armour(ArmourDTO armour)
        {
            ID = Guid.NewGuid().ToString();
            Validate(armour.Name, armour.AC, armour.Cost, armour.Strength);
            _name = armour.Name;
            AC = armour.AC;
            Cost = armour.Cost;
            Weight = armour.Weight;
            Strength = armour.Strength;
            Stealth = armour.Stealth;
            Type = armour.Type;
        }

        /// <summary>
        /// This is here to create a default Armour value.
        /// This should be deleted
        /// </summary>
        public Armour() 
        {
            ID = Guid.NewGuid().ToString();
            Name = "None";
            AC = 10;
            Cost = 0;
            Weight = 0;
            Strength = 0;
            Stealth = false;
            Type = ArmourType.Natural;
        }
        /// <summary>
        /// TODO Remove
        /// This is a constructor for an armour where just a name is defined for a light armour
        /// </summary>
        /// <param name="name"></param>
        public Armour(string name)
        {
            ID = Guid.NewGuid().ToString();
            Name = name;
            AC = 11;
            Cost = 200;
            Weight = 4;
            Strength = 0;
            Stealth = false;
            Type = ArmourType.Light;
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
            List<Exception> validationErrors = new();
            if (string.IsNullOrWhiteSpace(name))
                validationErrors.Add(new ArgumentNullException("Name cannot be null"));
            if (ac < 10) 
                validationErrors.Add(new ArgumentOutOfRangeException("Ac must be an integer above 10"));
            if (cost < 0)
                validationErrors.Add(new ArgumentOutOfRangeException("Cost must be an integer above 0"));
            if (strength != null && strength < 13)
                validationErrors.Add(new ArgumentOutOfRangeException("Strenght requirement must be above 12 or null"));

            if (validationErrors.Count > 0)
                throw new ValidationException(string.Join("; ", validationErrors));
        }
    }
    
}
