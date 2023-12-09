using Monster_Builder_Web_API.Models;
using Monster_Builder;

internal  class userDefinedMonstersHelpers
{
    public Monster MonsterCreation()
    {
        Console.WriteLine("What is the name of your Monster?");
        string name = Console.ReadLine();
        Console.WriteLine("Thank you, and what CR should we plan for this to be?");
        float cr = float.Parse(s: Console.ReadLine());
        Monster monster = new Monster(name, cr);
        return monster;
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