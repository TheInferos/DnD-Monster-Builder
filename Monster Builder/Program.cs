// See https://aka.ms/new-console-template for more information

namespace Monster_Builder
{
    class runProgram
    {
        static void Main()
        {
            UI ui = new UI();
            int mode = 1;
            Monster monster = BuildMonsterBase(mode, ui);
            ArmouryManager manager = GetArmoury();
            ui.PrintValues(monster, manager);
        }

        static Monster BuildMonsterBase(int mode, UI ui)
        {
            if (mode == 1)
            {
                return userDefinedMonsters.Creation(ui);
            }
            else
            {
                return systemDefinedMonsters.Creation();
            }
        }

        static ArmouryManager GetArmoury()
        {
            ArmouryManager manager = new ArmouryManager();

            return manager;
        }
        
        
    }
    public class UI
    {
        public string GetUserInput(string input)
        {
            Console.WriteLine(input);
            return Console.ReadLine();
        }

        public void WriteToUI(string message) 
        {
            Console.WriteLine(message);
        }
        public void PrintValues(Monster monster, ArmouryManager manager)
        {
            monster.PrintDetails();
            manager.PrintArmourDetails();
            manager.PrintWeaponDetails();
        }
    }
}

