using Armours;
using Statlines;
using Monster_Builder_Web_API.Models;


namespace Weapons

{
    public class Monster
    {
        public string Name { get; set; }
        public string ID { get; set; }
        public float CR { get; set; }
        public string Size { get; set; }
        public string Type { get; set; }
        public List<Weapon> Weapons { get; set; }
        public Armour Armour { get; set; }

        public Statline Stats { get; set; }

        public int Statpool { get; set; }

        public Monster(string name, float cr)
        {
            ID = Guid.NewGuid().ToString();
            Name = name;
            CR = cr;
            Stats = new Statline();
            Size = "Medium";
            Type = "Humanoid";
            Statpool = (int)(8 + 2 * CR);
            Weapons = [new Weapon("unarmed")];
            Armour = new Armour();
        }

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

        public void AddWeapon(Weapon weapon)
        {
            Weapons.Add(weapon);
        }

        public void ChangeArmour(Armour armour)
        {
            Armour = armour;
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
                    Stats.AC += (Stats.Dexterity / 2) - 5;
                    break;
                default:
                    throw new NotImplementedException($"AC calculation for {Armour.Type} not implemented");
            }

        }

    }
}
