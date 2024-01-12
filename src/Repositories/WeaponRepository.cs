using System.Text.Json;
using Monster_Builder_Web_API.src.Models;

namespace Monster_Builder_Web_API.src.Repositories
{
    /// <summary>
    /// This is the Weapon Repository Class, this will handle the importing and exporting of default values
    /// Classes should import this class if they want to get the default data/ save to storage
    /// </summary>
    public class WeaponRepository : IWeaponRepository
    {
        private Dictionary<string, Weapon> weapons { get; set; }

        /// <summary>
        /// This is the public front of WeaponRepository getting will create a shallow copy 
        /// of the dictionary so that the dictionary itself cannot be ammended 
        /// but the weapons within it can be
        /// </summary>
        public Dictionary<string, Weapon> Weapons
        {
            get
            {
                var copiedWeapons = new Dictionary<string, Weapon>();
                foreach (var pair in weapons)
                {
                    copiedWeapons.Add(pair.Key, pair.Value);
                }
                return copiedWeapons;
            }
        }
        private readonly string filePath;
        /// <summary>
        /// This is the standard constructor for the classs where the default filepath is hardcoded and then weapons are loaded in 
        /// TODO: Move the filepath to be  brought in from settings.
        /// </summary>
        public WeaponRepository()
        {
            filePath = "src/Data/Weapons.json";
            weapons = GetWeaponsFromFile();
            WriteWeapons();
        }

        private Dictionary<string, Weapon> GetWeaponsFromFile()
        {
            string jsonData = File.ReadAllText(filePath);
            var weapons = JsonSerializer.Deserialize<Dictionary<string, Weapon>>(jsonData);
            if (weapons == null || weapons.Count == 0)
            {
                throw new Exception($"No armours found in file {filePath}");
            }
            RunFunctionsOnAllWeapons(weapons);
            WriteWeapons();
            return weapons;
        }
        /// <summary>
        /// The aim of this function is to return the weapon from the repository given the id
        /// </summary>
        /// <param name="id">Id for the weapon to be searched via</param>
        /// <returns>Weapon whos id matches the query</returns>
        public Weapon GetWeapon(string id)
        {
            return Weapons[id];
        }
        /// <summary>
        /// This will write the weapons to the chosen storage solution
        /// </summary>
        public void WriteWeapons()
        {
            //TODO: This function is called when weapons is null.
            if (weapons != null)
            {
                var options = new JsonSerializerOptions
                {
                    WriteIndented = true
                };
                File.WriteAllText(filePath, JsonSerializer.Serialize(weapons, options));
            }
        }
        /// <summary>
        /// This is a temporary function to update stored weapons with new functionality 
        /// </summary>
        public void RunFunctionsOnAllWeapons(Dictionary<string, Weapon> weapons)
        {
            //foreach (var weapon in weapons)
            //{
            //    weapon.Value.AddAction();
            //}
        }
        /// <summary>
        /// This will update the weapon in the Repository if it wasn't passed by refernece and then write all weapons to for storage
        /// </summary>
        /// <param name="weapon">Weapon that has been updated</param>
        /// <returns>boolean of sucess status or Exception
        /// TODO in sucess pass back a 200</returns>
        /// <exception cref="Exception">Returns an exception saying the weapon exists and needs creating</exception>
        public bool UpdateWeapon(Weapon weapon)
        {
            if (Weapons.ContainsKey(weapon.ID))
            {
                Weapons[weapon.ID] = weapon;
                WriteWeapons();
                return true;
            }
            throw new Exception($"Weapon {weapon.Name} not found, use create.");
        }

        /// <summary>
        /// Returns a list of all weapons that are stored within the repository
        /// TODO: should do a deep copy rather than pass by reference.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Weapon> GetAllWeapons()
        {
            return Weapons.Values.ToList();
        }
    }
}
