namespace Monster_Builder_Web_API.Models.DTOs
{
    public class WeaponDTO
    {
        public required string Name { get; set; }
        public string Type { get; set; }
        public string Damage { get; set; }
        public List<string> Properties { get; set; }
        public bool Martial { get; set; }
        public bool Ranged { get; set; }
        public int Cost { get; set; }
        public int Weight { get; set; }
    }
}
