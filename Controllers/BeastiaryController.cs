using Microsoft.AspNetCore.Mvc;
using Monster_Builder_Web_API.Models;
using Monster_Builder_Web_API.Services;

namespace Monster_Builder_Web_API.Controllers
{
    /// <summary>
    /// This is the Beastiary Controller Setup. The aim of this is to ammend the Beastiary.
    /// Currently this is mostly a placeholder for planned future functionality
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class BeastiaryController : ControllerBase
    {
       private IBeastiaryService _beastiaryService { get; init; }

        /// <summary>
        /// This is the constructor for the Beastiary Controller
        /// </summary>
        /// <param name="beastiaryService">This takes in a Beasitary which will hold the monsters</param>
        public BeastiaryController(IBeastiaryService beastiaryService)
        {
            _beastiaryService = beastiaryService;
        }
        /// <summary>
        /// This will get a monster based on the ID and return it.
        /// Long term this is the plan for how all calls should be made with An OK.
        /// </summary>
        /// <param name="id">The monster ID</param>
        /// <returns>OK object which contains the monster in the body.</returns>
        [HttpGet("GetMonster/{id}")]
        public ActionResult GetMonster(string id)
        {
            return Ok(_beastiaryService.GetMonsterByID(id));
        }
    }
}
