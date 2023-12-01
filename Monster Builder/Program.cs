// See https://aka.ms/new-console-template for more information
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
class Builder
{
    static void Main()
    {

        Console.WriteLine("What is the name of your Monster?");
        string name = Console.ReadLine();
        Console.WriteLine("Thank you, and what CR should we plan for this to be?");
        float cr = float.Parse(s: Console.ReadLine());
        Monster monster = new Monster(name, cr);
        Console.WriteLine($"Thank you. I have made the new monster:\n{monster.Name}\nChallenger Rating {monster.CR}");
    }

}

