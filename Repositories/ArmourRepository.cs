using System.Text.Json;
using Monster_Builder_Web_API.Models;

namespace Monster_Builder_Web_API.Repositories
{
    public class ArmourRepository : IArmourRepository
    {
        private Dictionary<string, Armour> armours;
        public Dictionary<string, Armour> Armours { get { return armours; } }
        private string filePath { get; set; }
        public ArmourRepository()
        {
            filePath = "Data/Armours.json";
            armours = GetArmoursFromFile();
        }
        private Dictionary<string, Armour> GetArmoursFromFile()
        {
            string jsonData = File.ReadAllText(filePath);
            var armours = JsonSerializer.Deserialize<Dictionary<string, Armour>>(jsonData);

            if (armours == null || armours.Count == 0)
            {
                throw new Exception($"No armours found in file {filePath}");
            }

            return armours;
        }
        /// <summary>
        /// Returns the armour against the UUID
        /// Throws an exception if none exist
        /// </summary>
        /// <param id="id"></param>
        /// <returns>Armour</returns>
        /// 
        public Armour GetArmour(string id)
        {
            return armours[id];
        }


        public bool UpdateArmour(Armour armour)
        {
            if (armours.ContainsKey(armour.ID))
            {
                armours[armour.ID] = armour;
                WriteArmours();
                return true;
            }
            throw new Exception($"Armour {armour.Name} not found, use create.");
        }

        private void WriteArmours()
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            File.WriteAllText(filePath, JsonSerializer.Serialize(armours, options));
        }

        public IEnumerable<Armour> GetAllArmour()
        {
            return armours.Values.ToList();
        }
    }
}
