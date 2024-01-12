namespace Monster_Builder_Web_API.src.Models.DTOs
{
    /// <summary>
    /// This is a Data object for transfering the minimum data to create a Monster Base
    /// </summary>
    public class InitialMonsterRequestDTO
    {
        /// <summary>
        /// This is what the monster should be called
        /// </summary>
        public string Name { get; set; } = string.Empty;
        /// <summary>
        /// This is the Challenge Rating of the monster.
        /// Currently only 1-30 are expected. And it does not account for 1/2 and 1/4
        /// Whilst it does not prevent you going higher than 20/30 it does not stop you
        /// </summary>
        public int CR { get; set; } = 0;
        /// <summary>
        /// This is what the Hit Die  value should be. This will greatly affect the monsters Health (Typically between 6,8,10,12)
        /// </summary>
        public int hd { get; set; } = 0;
    }
}
