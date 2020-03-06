using System;
using System.IO;
using System.Linq;
using CasaDeShow.Data;
using CasaDeShow.DTO;
using CasaDeShow.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
namespace CasaDeShow.Controllers {
    [Authorize(Policy="Admin")]
        public class CategoriasController : Controller {
        private readonly ApplicationDbContext database;
        private IWebHostEnvironment _hostingEnvironment;
        public CategoriasController (ApplicationDbContext database, IWebHostEnvironment host) {
            this.database = database;
            _hostingEnvironment = host;
        }

        [HttpPost]
        public IActionResult Salvar (CategoriaDTO categoriaTemporaria, IFormFile files) {
            if (ModelState.IsValid) {

                Categoria categoria = new Categoria ();
                
                database.Categorias.Add (categoria);
                database.SaveChanges ();

                var uploads = Path.Combine (_hostingEnvironment.WebRootPath, "uploads");

                if (files.Length > 0) {

                    var extensao = Path.GetExtension (files.FileName).ToLower ();

                    if (extensao == ".jpeg" || extensao == ".jpg" || extensao == ".png") {

                        var filePath = Path.Combine (uploads, categoria.Id + extensao);

                        using (var fileStream = new FileStream (filePath, FileMode.Create)) {
                            files.CopyTo (fileStream);
                        }
                        categoria.Nome = categoriaTemporaria.Nome;
                        categoria.img = "/uploads/" + categoria.Id + extensao;
                        categoria.Status = true;
                        
                        database.SaveChanges ();

                    }
                }
                return RedirectToAction ("Categorias", "Admin");

            } else {
                return View ("../Admin/NovaCategoria");
            }
        }

        [HttpPost]
        public IActionResult Atualizar (CategoriaDTO categoriaTemporaria) {
            if (ModelState.IsValid) {
                var categoria = database.Categorias.First (cat => cat.Id == categoriaTemporaria.Id);
                categoria.Nome = categoriaTemporaria.Nome;
                database.SaveChanges ();
                return RedirectToAction ("Categorias", "Admin");
            } else {
                return View ("/Admin/EditarCategoria");
            }

        }

        [HttpPost]
        public IActionResult Deletar (int id) {
            if (id > 0) {
                var categoria = database.Categorias.First (cat => cat.Id == id);
                categoria.Status = false;
                database.SaveChanges ();
            }
            return RedirectToAction ("Categorias", "Admin");

        }
    }
}