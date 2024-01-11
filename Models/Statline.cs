using Monster_Builder_Web_API.Models.DTOs;

namespace Monster_Builder_Web_API.Models
{
    /// <summary>
    /// This is the 5e Statline. This also includes key details such as AC, Health, Hit Die
    /// </summary>
    public class Statline
    {
        // change to Private and setable via function
        /// <summary>
        /// This is the Creatures Strenth typically between 1 and 20, although can be higher than 20 cannot be lower than 0 
        /// </summary>
        public int Strength { get;  set; }
        /// <summary>
        /// This is the Creatures Dexterity typically between 1 and 20, although can be higher than 20 cannot be lower than 0 
        /// </summary>
        public int Dexterity { get; set; }
        /// <summary>
        /// This is the Creatures Consitution typically between 1 and 20, although can be higher than 20 cannot be lower than 0 
        /// </summary>
        public int Consitution { get; set; }
        /// <summary>
        /// This is the Creatures Intelligence typically between 1 and 20, although can be higher than 20 cannot be lower than 0 
        /// </summary>
        public int Intelligence { get; set; }
        /// <summary>
        /// This is the Creatures Wisdom typically between 1 and 20, although can be higher than 20 cannot be lower than 0 
        /// </summary>
        public int Wisdom { get; set; }
        /// <summary>
        /// This is the Creatures Charisma typically between 1 and 20, although can be higher than 20 cannot be lower than 0 
        /// </summary>
        public int Charisma { get; set; }
        /// <summary>
        /// This is the total creatures health Typically worked out from the Hit Die
        /// </summary>
        public int Health { get; set; }
        /// <summary>
        /// This is the Creatures Armour Class.
        /// </summary>
        public int AC { get; set; }
        /// <summary>
        /// This is a dictionary of Hit die, Where the key is the Hit Die Size and the Value in the count of the hit die
        /// </summary>
        public Dictionary<int, int> HD { get; set; }
        /// <summary>
        /// This is the base constructor for the statline. If no stats are provided that it produces an empty statline.
        /// </summary>
        public Statline()
        {
            Strength = 10;
            Dexterity = 10;
            Consitution = 10;
            Intelligence = 10;
            Wisdom = 10;
            Charisma = 10;
            Health = 0;
            AC = 10;
            HD = new Dictionary<int, int>()
            {
                { 0, 0 }
            };
        }
        /// <summary>
        /// This is the constructor used from the webpage.
        /// It uses the CR and Hit die to calculate an approximate health to start this is an initial total
        /// TODO: handle updating this later
        /// </summary>
        /// <param name="hd">This is the Hit Die size. This is the base for size to be multiplied for health</param>
        /// <param name="cr">This is the Challenge Rating. This is used as the count of hit die currently for a health calulcation</param>
        public Statline(int hd, int cr)
        {
            Strength = 10;
            Dexterity = 10;
            Consitution = 10;
            Intelligence = 10;
            Wisdom = 10;
            Charisma = 10;
            Health = 0;
            AC = 10;
            HD = new Dictionary<int, int>()
            {
                { hd, cr }
            };
             CalculateHeath();
        }
        /// <summary>
        /// This is the full constructor for a statline taking in the DTO
        /// </summary>
        /// <param name="stats">This is the core 6 stats to be used</param>
        /// <param name="ac">This is the Armour Class that should be set</param>
        /// <param name="hd">This is the Dictionary of Hit Die and Quanitity to be used</param>
        public Statline(StatblockDTO stats, int ac, Dictionary<int, int> hd)
        {
            Strength = stats.Strength;
            Dexterity = stats.Dexterity;
            Consitution = stats.Consitution;
            Intelligence = stats.Intelligence;
            Wisdom = stats.Wisdom;
            Charisma = stats.Charisma;
            AC = ac;
            HD = hd;
            CalculateHeath();
        }

        private void CalculateHeath()
        {
            Health = 0;
            foreach (var kvp in HD)
            {
                Health += kvp.Value * kvp.Key;
            }
        }
        /// <summary>
        /// Given a new Statblock this function will update the statblock then recalculate the health
        /// </summary>
        /// <param name="data">The new statblock DTO  which the stats should mirror</param>
        public void ChangeStats(StatblockDTO data)
        {
            Strength = data.Strength;
            Dexterity = data.Dexterity;
            Consitution = data.Consitution;
            Intelligence = data.Intelligence;
            Wisdom = data.Wisdom;
            Charisma = data.Charisma;
            CalculateHeath();
        }

        /// <summary>
        /// For Debugging, a pretty print of the statblock
        /// </summary>
        /// <returns>pretty string of stats, hp and AC for an easy read</returns>
        public override string ToString()
        {
            string message = "";
            message += $@"
                    HP: {Health}
                    AC: {AC}
                    Strength: {Strength}
                    Dexterity: {Dexterity}
                    Consitution: {Consitution}
                    Intelligence: {Intelligence}
                    Wisdom: {Wisdom}
                    Charisma: {Charisma}";
            message += "\n";
            return message.Replace("\t", "").Replace("    ", "");
        }
    }
}
