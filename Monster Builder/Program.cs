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
        Console.WriteLine("Test");
        Monster Guard = new Monster("Guard", 3);
        Console.WriteLine(Guard.Name);
    }

}

