using Microsoft.AspNetCore.Mvc;
using Monster_Builder_Web_API.Services;


namespace Monster_Builder_Web_API.Controllers
{
    [Route("api/[controller]")]
    public class ArmouryController : ControllerBase
    {
        ArmouryService _armouryService;
        public ArmouryController(ArmouryService armouryService)
        {
            _armouryService = armouryService;
        }

        [HttpGet("GetArmours")]
        public Dictionary<string, List<string>> GetArmours()
        {

            

            return _armouryService.GetArmourNames();
        }
    }
}
