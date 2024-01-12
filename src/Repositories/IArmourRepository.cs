using Monster_Builder_Web_API.Models;

namespace Monster_Builder_Web_API.Repositories
{
    /// <summary>
    /// This is the repository Interface it defines the setup of the repositiories ready for unit testing
    /// </summary>
    public interface IArmourRepository
    {
        /// <summary>
        /// This is the list of armours that are contained within the repository
        /// </summary>
        Dictionary<string, Armour> Armours { get; }
        /// <summary>
        /// This method is required to get a list of armours
        /// </summary>
        /// <returns>a list of Armours</returns>
        IEnumerable<Armour> GetAllArmour();
        /// <summary>
        /// This should contain a method for returning an armour based on an ID
        /// </summary>
        /// <param name="id">ID for the armour to be looked up on </param>
        /// <returns></returns>
        Armour GetArmour(string id);
        /// <summary>
        /// Updates the armour in the dictionary
        /// </summary>
        /// <param name="armour">The armour to be updated</param>
        /// <returns>boolean of wether the update was sucessful</returns>
        bool UpdateArmour(Armour armour);
    }
}