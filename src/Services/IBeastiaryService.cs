using Monster_Builder_Web_API.src.Models;

namespace Monster_Builder_Web_API.src.Services
{
    /// <summary>
    /// This service should handle all monsters
    /// </summary>
    public interface IBeastiaryService
    {
        /// <summary>
        /// There must be a way of adding a monster to the beastiary
        /// </summary>
        /// <param name="monster">This is the monster to add</param>
        void AddMonster(Monster monster);
        /// <summary>
        /// There must be a way of returning a monster from thbe beastiary given an ID
        /// </summary>
        /// <param name="id">the ID to lookup the monster</param>
        /// <returns>A monster with the relevant id.</returns>
        Monster GetMonsterByID(string id);
    }
}