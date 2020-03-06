using System;
using System.Linq;
using CasaDeShow.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CasaDeShow.API
{
    [Route("api/v1/vendas")]
    [ApiController]
    public class VendaController:ControllerBase   
    {
        private readonly ApplicationDbContext database;
        public VendaController(ApplicationDbContext database){
            this.database = database;
        }
        [HttpGet]
        public IActionResult Get() {
            var vendas = database.Vendas.ToList();
            return Ok(vendas);
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var vendas = database.Vendas.Include(p => p.Categoria).Include (p => p.CasaShow).First(v => v.Id == id);
                return Ok(vendas);
            }catch(Exception){
                Response.StatusCode = 404;
                return new ObjectResult("");
            }
        }
    }
}