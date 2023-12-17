using Microsoft.AspNetCore.Mvc;
using Weapons;
using Monster_Builder_Web_API.Services;
using System.Text.Json;

namespace Monster_Builder_Web_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BeastiaryController : ControllerBase
    {
        BeastiaryService _beastiaryService;

        public BeastiaryController(BeastiaryService beastiaryService)
        {
            _beastiaryService = beastiaryService;
        }

        //TODO Actually Save
        [HttpPost("SaveMonsters")]
        public void SaveMonsters()
        {
            _beastiaryService.SaveMonsters("Data/Monsters.json");
        }

        [HttpGet("GetMonster/{id}")]
        public ActionResult GetMonster(string id)
        {
            return Ok(_beastiaryService.GetMonsterByID(id));
        }
    }
}
