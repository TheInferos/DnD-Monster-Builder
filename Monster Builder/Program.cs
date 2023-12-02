// See https://aka.ms/new-console-template for more information

namespace Monster_Builder
{
    class runProgram
    {
        static void Main()
        {
            int mode = 0;
            Monster monster = BuildMonsterBase(mode);
            ArmouryManager manager  = GetArmoury();
            PrintValues(monster, manager);
        }

        static Monster BuildMonsterBase(int mode)
        {
            if (mode == 1)
            {
               return userDefinedMonsters.Creation();
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
        static void PrintValues (Monster monster,ArmouryManager manager)
        {
            monster.PrintDetails();
            manager.PrintArmourDetails();
            manager.PrintWeaponDetails();
        }
    }
}

