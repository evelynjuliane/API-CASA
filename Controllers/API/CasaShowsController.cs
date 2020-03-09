using System;
using System.Collections.Generic;
using System.Linq;
using CasaDeShow.Data;
using CasaDeShow.DTO;
using CasaDeShow.Models;
using Microsoft.AspNetCore.Mvc;

namespace CasaDeShow.Controllers
{
    [Route("api/v1/casas")]
    [ApiController]
    public class CasaShowsController : ControllerBase
    {
        private readonly ApplicationDbContext database;
        public CasaShowsController(ApplicationDbContext database){
            this.database = database;
        }
        //LIST
        [HttpGet]
        public IActionResult Get() {
            try{
                var casa = database.CasasShows.Where(c => c.Status == true).ToList ();
                return Ok(casa);
            }catch(Exception){
                Response.StatusCode = 404;
                return new ObjectResult("");
            }
        }
        
        [HttpGet("{id}")]
        public IActionResult Get(int id){
            try{
               var casa = database.CasasShows.First(c => c.Id == id);
                return Ok(casa); 
            }catch(Exception){
                Response.StatusCode = 404;
                return new ObjectResult("");
            }
            
        }
        //Ordem Crescente 
        [HttpGet("asc")]
        public IActionResult asc(){
            var casa = database.CasasShows.Where(c => c.Status == true).ToList ().OrderBy(c => c.Nome);
            return Ok(casa);
        }
        //Ordem Decrescente
        [HttpGet("desc")]
        public IActionResult desc(){
           var casa = database.CasasShows.Where(c => c.Status == true).ToList ().OrderByDescending(c => c.Nome);
           return Ok(casa);
            
        }
            
        
        // busca por Nome
        [HttpGet("nome/{nome}")]
        public IActionResult nome(string nome){
            try
            {
                var casa = database.CasasShows.First(c => c.Nome == nome);
                return Ok(casa);
            }catch(Exception){
                Response.StatusCode = 404;
                return new ObjectResult(new {msg = "O Nome não existe na lista."});
            }
            

        }
        //SAVE
        [HttpPost]
        public IActionResult Post([FromBody] CasaShowDTO clubTemporary){
            if(clubTemporary.Nome.Length <= 1){
                Response.StatusCode = 400;
                return new ObjectResult(new { msg = "O Nome deve ter mais de  1 caracter." });
            }
            if(clubTemporary.Local.Length <= 1){
                Response.StatusCode = 400;
                return new ObjectResult(new { msg = "O Local deve ter mais de  1 caracter." });
            }
                CasaShow club = new CasaShow();
                
                club.Nome = clubTemporary.Nome;
                club.Local = clubTemporary.Local;
                club.Status = true;
                
                database.CasasShows.Add(club);
                database.SaveChanges();
                
                Response.StatusCode = 201;
                return new ObjectResult("");
           
        }
        
        [HttpPut]
        public IActionResult Put ([FromBody] CasaShowDTO clubTemporary) {
           if(clubTemporary.Id > 0){
                try
                {
                    var club = database.CasasShows.First(cat => cat.Id == clubTemporary.Id);
                    if (clubTemporary != null){
                        club.Nome = clubTemporary.Nome;
                        club.Local = clubTemporary.Local;
                        database.SaveChanges ();
                        return Ok();
                    }else{
                        Response.StatusCode = 400;
                        return new ObjectResult(new { msg = "Casa De Show não encontrada!" });
                    }
                }catch (Exception)
                {
                    Response.StatusCode = 400;
                    return new ObjectResult(new { msg = "Casa De Show não encontrada!" });
                }
            }else{
                Response.StatusCode = 400;
                return new ObjectResult(new { msg = "Id da Casa De Show inválido!" });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete (int id) {
            if (id > 0) {
                try{
                    var club = database.CasasShows.First(cat => cat.Id == id);
                    club.Status = false;
                    database.SaveChanges();
                    return Ok();
                }catch(Exception){
                    Response.StatusCode = 404;
                    return new ObjectResult(new { msg = "Casa De Show não encontrada!" });
                }
            }else{
                Response.StatusCode = 400;
                return new ObjectResult(new { msg = "Id de Casa De Show inválido!" });
            }   
        }
    }
}