using Monster_Builder;

internal static class userDefinedMonstersHelpers
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