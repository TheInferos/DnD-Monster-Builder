using Microsoft.AspNetCore.Mvc;
using Monster_Builder;
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

        [HttpPost("SaveMonster")]
        public void SaveMonster(string name)
        {
            Monster monster = new Monster(name, 3);
            _beastiaryService.AddMonster(monster);
            _beastiaryService.SaveMonsters("Data/Monsters.json");
        }

        [HttpGet("GetMonster")]
        public string GetMonster(string name)
        {
            return JsonSerializer.Serialize(_beastiaryService.GetMonsterByID(name));
        }
    }
}
