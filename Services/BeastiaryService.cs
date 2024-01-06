using System.Text.Json;
using Monster_Builder_Web_API.Models;


namespace Monster_Builder_Web_API.Services
{
    /// <summary>
    /// This is the Beastiary Service which handles adding monsters to the beastiary and loading Monsters from stroage
    /// </summary>
    public class BeastiaryService : IBeastiaryService
    {
        private Dictionary<string, Monster> _monsters;
        /// <summary>
        /// Basic Constructor creating the Dictionary on monsters
        /// </summary>
        public BeastiaryService()
        {
            _monsters = new Dictionary<string, Monster>();
            LoadBaseMonsters();
        }

        /// <summary>
        /// This adds a monster to the beasitary
        /// </summary>
        /// <param name="monster">This is the monster that you plan to add it needs an ID as that is what it is stored under</param>
        public void AddMonster(Monster monster)
        {
            _monsters[monster.ID] = monster;
        }
        private void LoadBaseMonsters()
        {
            LoadMonstersFromFile("Data/Monsters.json");
        }

        private void LoadMonstersFromFile(string filePath)
        {
            string jsonData = File.ReadAllText(filePath);
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            _monsters = JsonSerializer.Deserialize<Dictionary<string, Monster>>(jsonData, options);
        }
        //TODO look into IDisposable 
        private void SaveMonsters(string filePath)
        {
            // Create JsonSerializerOptions
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            File.WriteAllText(filePath, JsonSerializer.Serialize(_monsters, options));
        }

        /// <summary>
        /// This function is the main way of getting monsters from the dictionary. 
        /// It gets the monster via the id provided.
        /// TODO handle nulls
        /// </summary>
        /// <param name="id">This is the ID to look for the monster under</param>
        /// <returns>Monster object requested</returns>
        public Monster GetMonsterByID(string id)
        {
            return _monsters[id];
        }
    }
}
