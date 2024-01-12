using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Monster_Builder_Web_API.Models;
using Monster_Builder_Web_API.Services;
using Monster_Builder_Web_API.Models.DTOs;

namespace Monster_Builder_Web_API.Controllers
{
    /// <summary>
    /// This is the Monster Controller this handles creating a new monster and 
    /// Modifying is attributes
    /// </summary>
    [Route("api/[controller]")]
    public class MonsterController : ControllerBase
    {
        private IBeastiaryService BeastiaryService { get; init; }
        private IArmouryService ArmouryService { get; init; }
        /// <summary>
        /// This is the constructor for the Monster Building API. It will handle adding items from the armour and weapons to the changing of monster stats
        /// </summary>
        /// <param name="beastiaryService">This is for the storage of Monsters</param>
        /// <param name="armouryService">This is for the storage of Items (Armour and Weapons)</param>
        public MonsterController(IBeastiaryService beastiaryService, IArmouryService armouryService)
        {
            BeastiaryService = beastiaryService;
            ArmouryService = armouryService;
        }

        /// <summary>
        /// This is the creation of monsters.
        /// TODO Change To Exception on return error, change to Ok(monster)
        /// </summary>
        /// <param name="formData">This requires a JSON containing the core details of a monster
        /// Defined in the monster Request DTO. (Name, CR and Hit Die)
        /// </param>
        /// <returns></returns>
        [HttpPost("MakeMonster")]
        public ActionResult<string> MakeMonster([FromBody] InitialMonsterRequestDTO formData)
        {
            if (string.IsNullOrEmpty(formData.Name) || formData.CR < 0)
            {
                return "{\"error\": \"Name and/ or challenge rating not provided\"}";
            }
            Monster monster = new(formData.Name, formData.CR, formData.hd);
            BeastiaryService.AddMonster(monster);
            return JsonSerializer.Serialize(monster);
        }

        /// <summary>
        /// This function assigns a weapon to the Monster
        /// TODO switch the weapon to take a weapon ID
        /// </summary>
        /// <param name="weapon">Currently a string for the weapon name, to be switched to a weapon ID</param>
        /// <param name="id">This is the ID of the monster you wish to assign the weapon to.</param>
        /// <returns>This returns the monster after the weapon has been added</returns>
        [HttpPost("{id}/GiveWeapon")]
        public ActionResult<string> AddWeapon(string weapon, string id)
        {
            Monster monster = BeastiaryService.GetMonsterByID(id);
            monster.AddWeapon(new Weapon(weapon));
            return JsonSerializer.Serialize(monster);
        }

        /// <summary>
        /// The intention of this function is to switch the armour that the monster is wearing to another and update details accordingly
        /// </summary>
        /// <param name="armourString"> This is the Name of the armour the monster will switch into</param>
        /// <param name="id"> This is the ID of the monster to switch the armour of</param>
        /// <returns></returns>
        [HttpPost("{id}/SwitchArmour")]
        public ActionResult<string> ChangeArmour(string armourString, string id)
        {
            Monster monster = BeastiaryService.GetMonsterByID(id);
            Armour armour = ArmouryService.GetArmourByName(armourString);
            monster.ChangeArmour(armour);
            return JsonSerializer.Serialize(monster);
        }
        /// <summary>
        /// This takes in a new statline and then ammeds the stats accordingly. After updating the statline it will
        /// Recalculate the relevenat fields that are ammended by the statchanges
        /// </summary>
        /// <param name="formData"> This is the list of stats Strength, Dexterity, 
        /// Consitution, Intellegence, Wisdom and Charisma</param>
        /// <param name="id">The monster ID to change</param>
        /// <returns>This returns the monster after the weapon has been added</returns>
        [HttpPost("{id}/ChangeStats")]
        public ActionResult<string> SetStats([FromBody] StatblockDTO formData, string id)

        {
            Monster monster = BeastiaryService.GetMonsterByID(id);
            monster.UpdateStats(formData);
            return JsonSerializer.Serialize(monster);
        }


        //// GET api/monsters/{id}
        //[HttpGet("{id}")]
        //public ActionResult GetMonster(int id)
        //{
        //    // Implementation for getting a specific monster by id
        //}

        //// POST api/monsters
        //[HttpPost]
        //public ActionResult CreateMonster([FromBody] Monster monster)
        //{
        //    // Implementation for creating a new monster
        //}

        //// Other actions for updating, deleting, etc.
    }
}