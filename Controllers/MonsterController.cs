﻿using Microsoft.AspNetCore.Mvc;
using Monster_Builder;

namespace Monster_Builder_Web_API.Controllers
{
    [Route("api/[controller]")]
    public class MonstersController : ControllerBase
    {
        // GET api/monsters
        [HttpGet]
        public ActionResult<string> GetSystemMonster()
        {
            Monster Guard = new Monster("Guard", 3);
            return Guard.toString();
        }

        [HttpPost("giveWeapon")]
        public ActionResult<string> AddWeapon(string weapon)
        {
            Monster Guard = new Monster("Guard", 3);
            Guard.addWeapon(new Weapon("Dagger"));
            return Guard.toString();
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