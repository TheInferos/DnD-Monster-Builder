// See https://aka.ms/new-console-template for more information
using Creator;
using System;
using System.Threading;

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
        Size = "Medium";
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
        public static Monster Creation()
        {
            Console.WriteLine("What is the name of your Monster?");
            string name = Console.ReadLine();
            Console.WriteLine("Thank you, and what CR should we plan for this to be?");
            float cr = float.Parse(s: Console.ReadLine());
            Monster monster = new Monster(name, cr);
            return monster;
        }
    }
    public class systemDefinedMonsters
    {
        public static Monster Creation()
        {
            Monster Guard = new Monster("Guard", 3);
            return Guard;
        }
    }

    
}


namespace Monster_Builder
{
    class runProgram
    {
        static void Main()
        {
            int mode = 0;
            Monster monster;
            ArmouryManager manager;
            if(mode == 1)
            {
                monster = userDefinedMonsters.Creation();
            }
            else
            {
                monster = systemDefinedMonsters.Creation();
            }
            PrintDetails(monster);
            manager = GetArmoury();
            manager.PrintArmourDetails();
        }

        static void PrintDetails(Monster monster)
        {
            Console.WriteLine($"Thank you. I have made the new monster:\n{monster.Name}\nChallenger Rating {monster.CR}\n");
        }

        static ArmouryManager GetArmoury() 
        {
            ArmouryManager manager = new ArmouryManager();
            
            return manager;
        }

    }
}
