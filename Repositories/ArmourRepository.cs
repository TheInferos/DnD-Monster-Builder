using System.Text.Json;
using Monster_Builder_Web_API.Models;

namespace Monster_Builder_Web_API.Repositories
{
    /// <summary>
    /// This is the Repository for all the Armours.
    /// This handels the setting up and saving the Armours
    /// TODO switch the information from being stored in JSONS to be stored in a Database.
    /// </summary>
    public class ArmourRepository : IArmourRepository
    {
        private Dictionary<string, Armour> armours;

        /// <summary>
        /// This is the public front of ArmourRepository getting will create a shallow copy 
        /// of the dictionary so that the dictionary itself cannot be ammended 
        /// but the armours within it can be
        /// </summary>
        public Dictionary<string, Armour> Armours
        {
            get
            {
                var copiedArmours = new Dictionary<string, Armour>();
                foreach (var pair in armours)
                {
                    copiedArmours.Add(pair.Key, pair.Value);
                }
                return copiedArmours;
            } 
        }
        private string filePath { get; set; }
        /// <summary>
        /// This contructor assigns where the armour is stored by its filepath and then will build the list of armours from the stored data.
        /// </summary>
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

        /// <summary>
        /// This function updates the dictionary and then saves the list ensuring retention
        /// </summary>
        /// <param name="armour">Armour to be updated</param>
        /// <returns>true or an exception</returns>
        /// <exception cref="Exception"></exception>
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
        /// <summary>
        /// This produces a list of items that can iterated through of the armours
        /// </summary>
        /// <returns>List of Armours</returns>
        public IEnumerable<Armour> GetAllArmour()
        {
            return armours.Values.ToList();
        }
    }
}
