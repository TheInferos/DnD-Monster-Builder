using Monster_Builder_Web_API.Models.Enum;
using Monster_Builder_Web_API.Models;
using Monster_Builder_Web_API.Repositories;

namespace Monster_Builder_Web_API.Services
{
    /// <summary>
    /// This is the Armoury Service which handels Weapons and Armours jointly. 
    /// This contians lists of the items held and then methods for getting them.
    /// </summary>
    public class ArmouryService : IArmouryService
    {
        private readonly ArmourRepository ArmourStore;
        private readonly WeaponRepository WeaponStore;
        /// <summary>
        /// This is the Contructor which loads the repositories.
        /// </summary>
        public ArmouryService()
        {
            ArmourStore = new ArmourRepository();
            WeaponStore = new WeaponRepository();
        }

        /// <summary>
        /// This uses the name to lookup an Armour.
        /// TODO modify this function to handle situation where multiple armours have the same name
        /// As they are not forced to be unique
        /// </summary>
        /// <param name="name">This is the search term used to find the armour</param>
        /// <returns></returns>
        public Armour GetArmourByName(string name)
        {
            return ArmourStore.Armours[name];
        }

        /// <summary>
        /// This uses the name to lookup an Weapon.
        /// TODO modify this function to handle situation where multiple armours have the same name
        /// As they are not forced to be unique
        /// </summary>
        /// <param name="name">This is the search term used to find the armour</param>
        /// <returns></returns>
        public Weapon GetWeaponByName(string name)
        {
            return WeaponStore.Weapons[name];
        }
        /// <summary>
        /// This method will get the names the armours split by the armour type. 
        /// </summary>
        /// <returns>A dictionary of lists split by each Armour Type</returns>
        public Dictionary<string, List<string>> GetArmourNames()
        {
            var armorObject = new Dictionary<string, List<string>> { };
                foreach (var armour in ArmourStore.Armours)
                {
                    var armorTypeString = Enum.GetName(typeof(ArmourType), armour.Value.Type);
                //TODO review Suppresions and decide best way forward.
#pragma warning disable CS8604 // Possible null reference argument.
#pragma warning disable CA1854 // Prefer the 'IDictionary.TryGetValue(TKey, out TValue)' method
                    if (!armorObject.ContainsKey(armorTypeString))
                    {
                        armorObject[armorTypeString] = [];
                    }
#pragma warning restore CA1854 // Prefer the 'IDictionary.TryGetValue(TKey, out TValue)' method
#pragma warning restore CS8604 // Possible null reference argument.
                    armorObject[armorTypeString].Add(armour.Key);
                }
            return armorObject;
        }
    }
}