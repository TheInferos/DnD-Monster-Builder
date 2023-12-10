using Monster_Builder;
using System.Text.Json;


namespace Monster_Builder_Web_API.Services
{
    public class BeastiaryService
    {
        public Dictionary<string, Monster> _monsters;

        public BeastiaryService()
        {
            _monsters = new Dictionary<string, Monster>();
            LoadBaseMonsters();
        }

        public void AddMonster(Monster monster)
        {
            _monsters[monster.ID] = monster;
        }
        public void LoadBaseMonsters()
        {
            LoadMonstersFromFile("Data/Monsters.json");
        }

        public void LoadMonstersFromFile(string filePath)
        {
            string jsonData = File.ReadAllText(filePath);
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            _monsters = JsonSerializer.Deserialize<Dictionary<string, Monster>>(jsonData, options);
        }

        public void SaveMonsters(string filePath)
        {
            // Create JsonSerializerOptions
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            File.WriteAllText(filePath, JsonSerializer.Serialize(_monsters, options));
        }
        public Monster GetMonsterByID(string id)
        {
            return _monsters[id];
        }
    }
}
