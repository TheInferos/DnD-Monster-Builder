// See https://aka.ms/new-console-template for more information
using Creator;
using System;

public class Monster
{
    public string Name { get; set; }
    public float CR { get; set; }
    public Monster (String name, float cr )
    {
        Name = name;
        CR = cr;
    }
}


namespace Creator
{
    public class userDefinedMonsters
    {
        public static void Creation()
        {
            Console.WriteLine("Test");
            Monster Guard = new Monster("Guard", 3);
            Console.WriteLine(Guard.Name);
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
