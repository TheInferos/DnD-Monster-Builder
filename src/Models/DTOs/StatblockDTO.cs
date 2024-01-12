namespace Monster_Builder_Web_API.src.Models.DTOs
{
    /// <summary>
    /// This is a Data Object containing the core stats of a monster in 5e
    /// </summary>
    public class StatblockDTO
    {
        /// <summary>
        /// This is the monsters Strenth typically between 1 and 20, although can be higher than 20 cannot be lower than 0 
        /// </summary>
        public int Strength { get; set; }
        /// <summary>
        /// This is the monsters Dexterity typically between 1 and 20, although can be higher than 20 cannot be lower than 0 
        /// </summary>
        public int Dexterity { get; set; }
        /// <summary>
        /// This is the monsters Consitution typically between 1 and 20, although can be higher than 20 cannot be lower than 0 
        /// </summary>
        public int Consitution { get; set; }
        /// <summary>
        /// This is the monsters Intelligence typically between 1 and 20, although can be higher than 20 cannot be lower than 0 
        /// </summary>
        public int Intelligence { get; set; }
        /// <summary>
        /// This is the monsters Wisdom typically between 1 and 20, although can be higher than 20 cannot be lower than 0 
        /// </summary>
        public int Wisdom { get; set; }
        /// <summary>
        /// This is the monsters Charisma typically between 1 and 20, although can be higher than 20 cannot be lower than 0 
        /// </summary>
        public int Charisma { get; set; }
    }
}
