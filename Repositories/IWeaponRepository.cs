using Monster_Builder_Web_API.Models;

namespace Monster_Builder_Web_API.Repositories
{
    /// <summary>
    /// This Interface covers a Repository of Weapons (subclass of Items)
    /// </summary>
    public interface IWeaponRepository
    {
        /// <summary>
        /// There must be a method of getting a dictionary of Weapons contained within the repository
        /// </summary>
        Dictionary<string, Weapon> Weapons { get; }
        /// <summary>
        /// There must be a method of getting all weapons contained within the repository as a list
        /// </summary>
        /// <returns></returns>
        IEnumerable<Weapon> GetAllWeapons();
        /// <summary>
        /// Given a specific ID return a Weapon
        /// </summary>
        /// <param name="id">ID to find the weapon in the repository via</param>
        /// <returns>Weapon whose id matches the one provided</returns>
        Weapon GetWeapon(string id);
        /// <summary>
        /// Must be a way of updating the repository with a new weapon
        /// </summary>
        /// <param name="weapon">This is the weapon to be updated within the repository</param>
        /// <returns>Boolean dictating sucess</returns>
        bool UpdateWeapon(Weapon weapon);
        /// <summary>
        /// There must be a method of saving the Weapons after local updates have been made 
        /// </summary>
        void WriteWeapons();
    }
}