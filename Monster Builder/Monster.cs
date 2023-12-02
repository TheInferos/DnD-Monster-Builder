namespace Monster_Builder
{
    public class Monster
    {
        public string Name { get; set; }
        public float CR { get; set; }
        public string Size { get; set; }
        public string Type { get; set; }

        public Statline Stats { get; set; }
        public Monster(String name, float cr)
        {
            Name = name;
            CR = cr;
            Stats = new Statline();
            Size = "Medium";
            Type = "Humanoid";
        }
        public void PrintDetails()
        {
            Console.WriteLine($"Thank you. I have made the new monster:\n{Name}\nChallenger Rating {CR}\n");
        }
    }

    public class userDefinedMonsters
    {
        public static Monster Creation(UI ui)
        {
            
            string name =  ui.GetUserInput("What is the name of your Monster?");
            float cr = float.Parse(s: ui.GetUserInput("Thank you, and what CR should we plan for this to be?"));
            Monster monster = new Monster(name, cr);
            return monster;
        }

        public Monster DefineStats (Monster monster)
        {

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
