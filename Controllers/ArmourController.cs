using Microsoft.AspNetCore.Mvc;
using Monster_Builder_Web_API.Models;

namespace Monster_Builder_Web_API.Controllers
{
        [Route("api/[controller]")]
        public class ArmourController
    {
        [HttpGet("BasicArmour")]
        public ActionResult<string> getArmour()
        {
            Armour armour = new Armour();
            return armour.ToString();
        }

        [HttpPost("MakeArmour")]
        public ActionResult<string> MakeArmour(string name, int ac, int cost, int strength, int weight, bool stealth, string type)
        {
            Armour armour = new Armour(name, ac, cost, weight, strength, stealth, type);
            return armour.ToString();
        }

    }
}
