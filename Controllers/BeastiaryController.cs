using Microsoft.AspNetCore.Mvc;
using Monster_Builder_Web_API.Models;
using Monster_Builder_Web_API.Services;

namespace Monster_Builder_Web_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BeastiaryController : ControllerBase
    {
        IBeastiaryService _beastiaryService;

        public BeastiaryController(IBeastiaryService beastiaryService)
        {
            _beastiaryService = beastiaryService;
        }

        [HttpGet("GetMonster/{id}")]
        public ActionResult GetMonster(string id)
        {
            return Ok(_beastiaryService.GetMonsterByID(id));
        }
    }
}
