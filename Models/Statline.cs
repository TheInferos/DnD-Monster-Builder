
﻿using Weapons;
using Monster_Builder_Web_API.Models.DTOs;

namespace Statlines
{
    public class Statline
    {
        // change to Private and setable via function
        public int Strength { get;  set; }
        public int Dexterity { get; set; }
        public int Consitution { get; set; }
        public int Intelligence { get; set; }
        public int Wisdom { get; set; }
        public int Charisma { get; set; }
        public int Health { get; set; }
        public int AC { get; set; }
        public Dictionary<int, int> HD { get; set; }
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
        public Statline(int cr)
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
                { 8, cr }
            };
        }
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

        public void CalculateHeath()
        {
            Health = 0;
            foreach (var kvp in HD)
            {
                Health += kvp.Value * kvp.Key;
            }
        }

        // Change to request class
        public void ChangeStats(StatblockDTO data)
        {
            Strength = data.Strength;
            Dexterity = data.Dexterity;
            Consitution = data.Consitution;
            Intelligence = data.Intelligence;
            Wisdom = data.Wisdom;
            Charisma = data.Charisma;
        }

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

        public void GenerateStatsFromPriority(string priority, Monster monster)
        {
            int loopCount = 1;
            int addedStats = 0;
            string[] PriorityStrings = priority.Split(" ");
            List<int> PriorityList = new List<int>();
            string[] StatLookup;
            foreach (var prioritySring in PriorityStrings)
            {
                int parsedValue;
                bool parseSuccess = int.TryParse(prioritySring, out parsedValue);

                if (parseSuccess)
                {
                    PriorityList.Add(parsedValue);
                }

            }
            while (monster.Statpool < addedStats)
            {
                foreach (int Priority in PriorityList)
                {

                    if (loopCount > (int)Priority)
                    {

                    }
                }

            }
        }

    }

}
