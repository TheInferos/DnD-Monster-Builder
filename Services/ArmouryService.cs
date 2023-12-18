using Armours;
using Weapons;
using Monster_Builder_Web_API.Repositories;

namespace Monster_Builder_Web_API.Services
{
    public class ArmouryService
    {
        public ArmourRepository ArmourStore;
        public WeaponRepository WeaponStore;
        public ArmouryService()
        {
            ArmourStore = new ArmourRepository();
            WeaponStore = new WeaponRepository();
        }

        public Armour GetArmourByName(string name)
        {
            return ArmourStore.Armours[name];
        }

        public Weapon GetWeaponByName(string name)
        {
            return WeaponStore.Weapons[name];
        }
    }
}