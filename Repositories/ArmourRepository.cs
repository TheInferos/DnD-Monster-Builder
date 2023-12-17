using Armours;
using System.Text.Json;

namespace Monster_Builder_Web_API.Repositories
{
    public class ArmourRepository
    {
        private Dictionary<string, Armour> Armours;
        public ArmourRepository()
        {
            Armours = GetArmoursFromFile("Data/Armours.json");
        }
        private Dictionary<string, Armour> GetArmoursFromFile(string filePath)
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
            return Armours[id];
        }


        public bool UpdateArmour(Armour armour)
        {
            if (Armours.ContainsKey(armour.ID))
            {
                Armours[armour.ID] = armour;
                return true;
            }
            throw new Exception($"Armour {armour.Name} not found, use create.");
        }

        public IEnumerable<Armour> GetAllArmour()
        {
            return Armours.Values.ToList();
        }
    }
}
