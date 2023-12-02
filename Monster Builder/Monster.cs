using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monster_Builder
{
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
        public void PrintDetails()
        {
            Console.WriteLine($"Thank you. I have made the new monster:\n{Name}\nChallenger Rating {CR}\n");
        }
    }

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
