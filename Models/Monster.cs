using System;
using System.Collections.Generic;
using System.Text.Json;
using Armours;
using Microsoft.Extensions.Hosting;
using Statlines;


namespace Monster_Builder

{
    public class Monster
    {
        public string Name { get; set; }
        public float CR { get; set; }
        public string Size { get; set; }
        public string Type { get; set; }
        public List<Weapon> Weapons { get; set; }
        public Armour Armour { get; set; }

        public Statline Stats { get; set; }

        public int Statpool { get; set; }

        public Monster(String name, float cr)
        {
            Name = name;
            CR = cr;
            Stats = new Statline();
            Size = "Medium";
            Type = "Humanoid";
            Statpool = (int) (8+2 * CR);
            Weapons = [new Weapon("unarmed")];
            Armour = new Armour();

        }

        public override string ToString()
        {
            string message = "";
            message += $@"
                    Name: {Name}
                    CR: {CR}
                    Type: {Type}
                    Stats: {Stats}
                    Weapons: {Weapons[0].ToString()}
                    Armour: {Armour}";
            message += "\n";
            return message.Replace("\t", "").Replace("    ", "");
        }

        public void addWeapon(Weapon weapon)
        {
            Weapons.Add(weapon);
        }

        public void changeArmour(Armour armour)
        {
            Armour = armour;
        }


    }

    public class userDefinedMonsters
    {
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
            string statPriority = "1 2 2 3 4 5";
            
            return Guard;
        }
    }
    public class InitialMonsterRequest
    {
        public string Name { get; set; }
        public int CR { get; set; }
    }
    // TODO
    //public void GenerateStatsFromPriority(string priority, Monster monster)
    //{
    //    int loopCount = 1;
    //    int addedStats = 0;
    //    string[] PriorityStrings = priority.Split(" ");
    //    List<int> PriorityList = new List<int>();
    //    string[] StatLookup;
    //    foreach (var prioritySring in PriorityStrings)
    //    {
    //        int parsedValue;
    //        bool parseSuccess = int.TryParse(prioritySring, out parsedValue);

    //        if (parseSuccess)
    //        {
    //            PriorityList.Add(parsedValue);
    //        }

    //    }
    //    while (monster.Statpool < addedStats)
    //    {
    //        foreach (int Priority in PriorityList)
    //        {

    //            if (loopCount > (int)Priority)
    //            {

    //            }
    //        }

    //    }
    //}
}
