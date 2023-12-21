using Monster_Builder_Web_API.Models.Enum;
using Monster_Builder_Web_API.Models;
using Monster_Builder_Web_API.Repositories;

namespace Monster_Builder_Web_API.Services
{
    public class ArmouryService : IArmouryService
    {
        private ArmourRepository ArmourStore;
        private WeaponRepository WeaponStore;
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
        public Dictionary<string, List<string>> GetArmourNames()
        {
            var armorObject = new Dictionary<string, List<string>> { };
                foreach (var armour in ArmourStore.Armours)
                {
                    var armorTypeString = Enum.GetName(typeof(ArmourType), armour.Value.Type);
                    if (!armorObject.ContainsKey(armorTypeString))
                    {
                        armorObject[armorTypeString] = new List<string>();
                    }
                    armorObject[armorTypeString].Add(armour.Key);
                }
            return armorObject;
        }
    }
}