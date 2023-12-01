// See https://aka.ms/new-console-template for more information
using Creator;
using System;

public class Monster
{
    public string Name { get; set; }
    public float CR { get; set; }
    public string Size { get; set; }

    public Statline Stats { get; set; }
    public Monster(String name, float cr)
    {
        Name = name;
        CR = cr;
        Stats = new Statline();
    }
}

    public class Statline
    {
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Consitution { get; set; }
        public int Intelligence { get; set; }
        public int Wisdom { get; set; }
        public int Charisma { get; set; }
        public int Health { get; set; }
        public int AC { get; set; }
        public Dictionary<int, int>  HD { get; set; }
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
}



namespace Creator
{
    public class userDefinedMonsters
    {
        public static void Creation()
        {
            Console.WriteLine("What is the name of your Monster?");
            string name = Console.ReadLine();
            Console.WriteLine("Thank you, and what CR should we plan for this to be?");
            float cr = float.Parse(s: Console.ReadLine());
            Monster monster = new Monster(name, cr);
            Console.WriteLine($"Thank you. I have made the new monster:\n{monster.Name}\nChallenger Rating {monster.CR}");
        }
    }
    public class systemDefinedMonsters
    {
        public static void Creation()
        {
            Console.WriteLine("Test");
            Monster Guard = new Monster("Guard", 3);
            Console.WriteLine(Guard.Name);
        }
    }

}


namespace Execution
{
    class runProgram
    {
        static void Main()
        {
            int mode = 0;
            if(mode == 1)
            {
                userDefinedMonsters.Creation();
            }
            else
            {
                systemDefinedMonsters.Creation();
            }
        }

    }
}
