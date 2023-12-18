using Weapons;

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
        public Statline(int strength, int dexterity, int consitution, int intelligence, int wisdom, int charisma, int ac, Dictionary<int, int> hd)
        {
            Strength = strength;
            Dexterity = dexterity;
            Consitution = consitution;
            Intelligence = intelligence;
            Wisdom = wisdom;
            Charisma = charisma;
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
        public void changeStats(int strength, int dexterity, int consitution, int intelligence, int wisdom, int charisma)
        {
            Strength = strength;
            Dexterity = dexterity;
            Consitution = consitution;
            Intelligence = intelligence;
            Wisdom = wisdom;
            Charisma = charisma;
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
