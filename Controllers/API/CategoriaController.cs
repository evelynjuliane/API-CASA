using System;
using System.Linq;
using CasaDeShow.Data;
using CasaDeShow.DTO;
using CasaDeShow.Models;
using Microsoft.AspNetCore.Mvc;

namespace CasaDeShow.Controllers
{
    [Route("api/v1/categorias")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ApplicationDbContext database;
        public CategoriaController (ApplicationDbContext database){
            this.database = database;
        }
        //LIST
        [HttpGet]
        public IActionResult Get() {
            var category = database.Categorias.Where (cat => cat.Status == true).ToList ();
            return Ok(category);
        }
        
        [HttpGet("{id}")]
        public IActionResult Get(int id){
            try{
               var category = database.Categorias.First(cat => cat.Id == id);
                return Ok(category); 
            }catch(Exception){
                Response.StatusCode = 404;
                return new ObjectResult("");
            }
            
        }
        [HttpGet("nome/asc")]
        public IActionResult NomeAsc(){
               var category = database.Categorias.Where(cat => cat.Status == true).ToList().OrderBy(c => c.Nome);
                return Ok(category); 
        }
        [HttpGet("nome/desc")]
        public IActionResult NomeDesc(){
               var category = database.Categorias.Where(cat => cat.Status == true).ToList().OrderByDescending(c => c.Nome);
                return Ok(category); 
        }
        //SAVE
        [HttpPost]
        public IActionResult Post ([FromBody] CategoriaDTO categoryTemporary) {
            if(categoryTemporary.Nome.Length <= 1){
                Response.StatusCode = 400;
                return new ObjectResult(new { msg = "O Nome deve ter mais de  1 caracter." });
            }

            Categoria category = new Categoria ();
                
            category.Nome = categoryTemporary.Nome;
            category.Status = true;
            database.Categorias.Add (category);
            database.SaveChanges ();
              
            Response.StatusCode = 201;
            return new ObjectResult("");
        }

        //EDIT
        [HttpPut]
        public IActionResult Put ([FromBody] CategoriaDTO categoryTemporary) {
            if(categoryTemporary.Id > 0){ 
                try{ 
                    var category = database.Categorias.First (cat => cat.Id == categoryTemporary.Id);
                    if (categoryTemporary != null){
                        category.Nome = categoryTemporary.Nome;
                        database.SaveChanges();
                        return Ok();
                    }else{
                        Response.StatusCode = 400;
                        return new ObjectResult(new { msg = "Categoria não encontrada!" });
                    }
                }catch(Exception){
                    Response.StatusCode = 400;
                    return new ObjectResult(new { msg = "Categoria não encontrada!" });
                }
            }else{
                Response.StatusCode = 400;
                return new ObjectResult(new { msg = "Id de Categoria inválido!" });
            }
            

        }

        //DELETE
        [HttpDelete("{id}")]
        public IActionResult Delete (int id) {
            if (id > 0) {
                try{
                    var category = database.Categorias.First (cat => cat.Id == id);
                    category.Status = false;
                    database.SaveChanges ();
                    return Ok(); 
                }catch(Exception){
                    Response.StatusCode = 404;
                    return new ObjectResult(new { msg = "Categoria não encontrada!" });
                }
            }else{
                Response.StatusCode = 400;
                return new ObjectResult(new { msg = "Id de Categoria inválido!" });
            }   
                
        }
    }
}