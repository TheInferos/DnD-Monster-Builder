namespace Armours;

public class Armour
{
    //You only need all this validation because armour can be modified after creation.
    //If armour could not be edited once created we could just use the validation in the constructor.
    //I don't know the design you had in mind but I can't think why the armour needs to be changeable. Just use a different armour
    private string _name;
    private int _ac;
    private int _cost;
    private int _weight;
    private int? _strength;

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
            ArgumentOutOfRangeException.ThrowIfLessThan(value, 11);
            _ac = value;
        }
    }

    public int Cost
    {
        get
        {
            return _cost;
        }
        set
        {
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(value);
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
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(value);
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
            if(value != null)
            {
                ArgumentOutOfRangeException.ThrowIfLessThan((int)value, 13);
            }
            _strength = value;
        }
    }

    public bool Stealth { get; set; }
    public ArmourType Type { get; set; }

    public Armour(string name, int ac, int cost, int weight, int? strength, bool stealth, ArmourType type)
    {
        //Lots of validation
        List<Exception> validationErrors = new();
        if (string.IsNullOrWhiteSpace(name)) validationErrors.Add(new ArgumentNullException("Name cannot be null"));
        if (ac < 10) validationErrors.Add(new ArgumentOutOfRangeException("Ac must be an integer above 10"));
        if (cost < 0) validationErrors.Add(new ArgumentOutOfRangeException("Cost must be an integer above 0"));
        if (strength != null && strength < 13) validationErrors.Add(new ArgumentOutOfRangeException("Strenght requirement must be above 12 or null"));

        if (validationErrors.Count > 0)
        {
            throw new AggregateException(validationErrors.ToArray());
        }

        Name = name;
        AC = ac;
        Cost = cost;
        Weight = weight;
        Strength = strength;
        Stealth = stealth;
        Type = type;
    }

    //I get that you want to populate basic armour but the armour class isnt the place for this.
    //It isn't really armours job to understand the idea that it needs dummy data. 
    public Armour()
    {
        _name = "Padded";
        _ac = 11;
        _cost = 200;
        _weight = 4;
        _strength = 0;
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
}
