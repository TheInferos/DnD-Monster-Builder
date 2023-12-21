﻿using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Monster_Builder_Web_API.Models;
using Monster_Builder_Web_API.Services;
using Monster_Builder_Web_API.Models.DTOs;

namespace Monster_Builder_Web_API.Controllers
{
    [Route("api/[controller]")]
    public class MonsterController : ControllerBase
    {
        IBeastiaryService _beastiaryService;
        IArmouryService _armouryService;
        public MonsterController(IBeastiaryService beastiaryService, IArmouryService armouryService) 
        {
            _beastiaryService = beastiaryService;
            _armouryService = armouryService;
        }

        //TODO Change To Exception onm return error, change to Ok(monster)
        [HttpPost("MakeMonster")]
        public ActionResult<string> MakeMonster([FromBody] InitialMonsterRequestDTO formData)
        {
            if (string.IsNullOrEmpty(formData.Name) || formData.CR < 0)
            {
                return "{\"error\": \"Name and/ or challenge rating not provided\"}";
            }
            Monster monster = new Monster(formData.Name, formData.CR, formData.hd);
            _beastiaryService.AddMonster(monster);
            return JsonSerializer.Serialize(monster);
        }

        [HttpPost("{id}/GiveWeapon")]
        public ActionResult<string> AddWeapon(string weapon, string id)
        {
            Monster monster = _beastiaryService.GetMonsterByID(id);
            monster.AddWeapon(new Weapon(weapon));
            return JsonSerializer.Serialize(monster);
        }

        [HttpPost("{id}/SwitchArmour")]
        public ActionResult<string> ChangeArmour(string armourString,string id)
        {
            Monster monster = _beastiaryService.GetMonsterByID(id);
            Armour armour = _armouryService.GetArmourByName(armourString);
            monster.ChangeArmour(armour);
            return JsonSerializer.Serialize(monster);
        }

        [HttpPost("{id}/ChangeStats")]
        public ActionResult<string> SetStats([FromBody] StatblockDTO formData, string id)

        {
            Monster monster = _beastiaryService.GetMonsterByID(id);
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