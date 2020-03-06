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
    public class EventosController : Controller {
        private readonly ApplicationDbContext database;
        private IWebHostEnvironment _hostingEnvironment;
        public EventosController (ApplicationDbContext database, IWebHostEnvironment host) {
            this.database = database;
            _hostingEnvironment = host;
        }

        [HttpPost]
        public IActionResult Salvar (EventoDTO eventoTemporaria, IFormFile files) {
            if (ModelState.IsValid) {
                Evento evento = new Evento ();
                database.Eventos.Add (evento);
                database.SaveChanges();
                var uploads = Path.Combine (_hostingEnvironment.WebRootPath, "uploads");

                if (files.Length > 0) {

                    var extensao = Path.GetExtension (files.FileName).ToLower ();

                    if (extensao == ".jpeg" || extensao == ".jpg" || extensao == ".png") {

                        var filePath = Path.Combine (uploads, evento.Id + extensao);

                        using (var fileStream = new FileStream (filePath, FileMode.Create)) {
                            files.CopyTo (fileStream);
                        }

                        evento.Nome = eventoTemporaria.Nome;
                        evento.Categoria = database.Categorias.First (categoria => categoria.Id == eventoTemporaria.CategoriaID);
                        evento.CasaShow = database.CasasShows.First (casashow => casashow.Id == eventoTemporaria.CasaShowID);
                        evento.QuantDeIngressos = eventoTemporaria.QuantDeIngressos;
                        evento.Data = eventoTemporaria.Data;

                        evento.ValorDoIngresso = eventoTemporaria.ValorDoIngresso;
                        evento.img = "/uploads/" + evento.Id + extensao;
                        evento.Status = true;

                        
                        database.SaveChanges ();
                    }
                }
                return RedirectToAction ("Eventos", "Admin");
            } else {
                ViewBag.Categorias = database.Categorias.ToList ();
                ViewBag.CasasShows = database.CasasShows.ToList ();
                return View ("../Admin/NovoEvento");
            }

        }

        [HttpPost]
        public IActionResult Atualizar (EventoDTO eventoTemporaria) {
            if (ModelState.IsValid) {
                var evento = database.Eventos.First (cat => cat.Id == eventoTemporaria.Id);
                evento.Nome = eventoTemporaria.Nome;
                evento.Categoria = database.Categorias.First (categoria => categoria.Id == eventoTemporaria.CategoriaID);
                evento.CasaShow = database.CasasShows.First (casashow => casashow.Id == eventoTemporaria.CasaShowID);
                evento.QuantDeIngressos = eventoTemporaria.QuantDeIngressos;
                evento.Data = eventoTemporaria.Data;

                evento.ValorDoIngresso = eventoTemporaria.ValorDoIngresso;

                database.SaveChanges ();
                return RedirectToAction ("Eventos", "Admin");
            } else {
                return RedirectToAction ("Eventos", "Admin");

            }
        }

        [HttpPost]
        public IActionResult Delete (int id) {
            if (id > 0) {
                var evento = database.Eventos.First (eve => eve.Id == id);
                evento.Status = false;
                database.SaveChanges ();
            }
            return RedirectToAction ("Eventos", "Admin");

        }
    }
}