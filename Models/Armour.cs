using System.ComponentModel.DataAnnotations;
using Monster_Builder_Web_API.Models.DTOs;
using Monster_Builder_Web_API.Models.Enum;

namespace Monster_Builder_Web_API.Models
{
    public class Armour
    {
        private string _name;
        private int _ac;
        private int? _cost;
        private int? _weight;
        private int? _strength;

        public string ID { get; set; }
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

        public int? Cost
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

        public int? Weight
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

        public int? Strength
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
        public bool Stealth { get; set; }
 
        public ArmourType Type { get; set; }



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

        //TODO Remove 
        public Armour() 
        {
            ID = Guid.NewGuid().ToString();
            Name = "None";
            AC = 10;
            Cost = 0;
            Weight = 0;
            Strength = 0;
            Stealth = false;
            Type = ArmourType.Other;
        }
        //TODO Remove 
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
