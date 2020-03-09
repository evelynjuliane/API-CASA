using System;
using System.Collections.Generic;
using System.Linq;
using CasaDeShow.Data;
using Microsoft.AspNetCore.Mvc;

namespace CasaDeShow.API
{
    [Route("api/v1/users")]
    [ApiController]
    public class UsersController:ControllerBase
    {
        private readonly ApplicationDbContext database;
        public UsersController(ApplicationDbContext database){
            this.database = database;
        }
        [HttpGet]
        public IActionResult Get() {
            var users = database.Users.Select(u => u.UserName).ToList();
            return Ok(users);
        }
        [HttpGet("{email}")]
        public IActionResult Get(string email)
        {
            try
            {
                var users = database.Users.First(s => s.UserName == email);
                var aux = users.UserName;
                return Ok(aux);
            }catch(Exception){
                Response.StatusCode = 404;
                return new ObjectResult("");
            }
        }
    }
}