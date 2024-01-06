namespace Monster_Builder_Web_API.Models.DTOs
{
    /// <summary>
    /// This is the Data Transfer Object of Weapons where all values are manually set
    /// </summary>
    public class WeaponDTO
    {
        /// <summary>
        /// This should be the name given to the object
        /// </summary>
        public required string Name { get; set; }
        /// <summary>
        /// This should contain the damage that the weapon deals
        /// </summary>
        public string Damage { get; set; }
        /// <summary>
        /// This is a string list of the properties that the weapon has. Thrown, Finesse and Versatile should all go here
        /// </summary>
        public List<string> Properties { get; set; }
        /// <summary>
        /// This is a boolean for wether the weapon is a Martial (true) or a Simple (false) Weapon
        /// </summary>
        public bool Martial { get; set; }
        /// <summary>
        /// This defines wether the weapon is a Ranged (true) or Melee( false). Thrown weapons should be set to false.
        /// </summary>
        public bool Ranged { get; set; }
        /// <summary>
        /// This will be the cost of the Weapon in Copper peices. Whilst this can be 0 it should never be negative.
        /// </summary>
        public int Cost { get; set; }
        /// <summary>
        /// This will be the weight of the Weapon in lbs. Whilst this can be 0 it should never be negative.
        /// </summary>
        public int Weight { get; set; }
    }
}
