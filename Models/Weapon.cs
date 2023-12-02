namespace Monster_Builder
{

    public class Weapon
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Damage { get; set; }
        public string[] Properties { get; set; }
        public bool Martial { get; set; }
        public bool Ranged { get; set; }
        public int Cost { get; set; }
        public int Weight { get; set; }
    
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
