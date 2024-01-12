using Monster_Builder_Web_API.src.Models;

namespace Monster_Builder_Web_API.src.Services
{
    /// <summary>
    /// This service is where all Items are stored (Weapons and Armours)
    /// </summary>
    public interface IArmouryService
    {
        /// <summary>
        /// This function should return an Armour from the service given a name
        /// </summary>
        /// <param name="name">the name to lookup the armour</param>
        /// <returns></returns>
        Armour GetArmourByName(string name);
        /// <summary>
        /// This function should return an Weapon from the service given a name
        /// </summary>
        /// <param name="name">the name to lookup the Weapon</param>
        /// <returns></returns>
        Weapon GetWeaponByName(string name);
        /// <summary>
        /// This function should returns a dictionary of armours split by type, then a string list of each name
        /// </summary>
        /// <returns></returns>
        Dictionary<string, List<string>> GetArmourNames();
    }
}