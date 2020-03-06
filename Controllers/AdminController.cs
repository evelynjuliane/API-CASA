using System.Linq;
using CasaDeShow.Data;
using CasaDeShow.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
namespace CasaDeShow.Controllers {
    [Authorize(Policy="Admin")]
        public class AdminController : Controller {
        private readonly ApplicationDbContext database;
        public AdminController (ApplicationDbContext database) {
            this.database = database;
        }
        public IActionResult Index () {
            var eventos = database.Eventos.Include (p => p.Categoria).Include (p => p.CasaShow).Where (e => e.Status == true).ToList ();
            
            
            return View (eventos);
        }

        //CATEGORIAS
        public IActionResult Categorias () {
            var categorias = database.Categorias.Where (cat => cat.Status == true).ToList ();

            return View (categorias);
        }
        public IActionResult EditarCategoria (int id) {
            var categoria = database.Categorias.First (cat => cat.Id == id);
            CategoriaDTO categoriaView = new CategoriaDTO ();
            categoriaView.Id = categoria.Id;
            categoriaView.Nome = categoria.Nome;
            return View (categoriaView);
        }
        public IActionResult NovaCategoria () {
            return View ();
        }
        //CASA DE SHOWS
        public IActionResult CasaShows () {
            var casashow = database.CasasShows.Where (cat => cat.Status == true).ToList ();
            return View (casashow);
        }
        public IActionResult EditarCasaShow (int id) {
            var casashow = database.CasasShows.First (casa => casa.Id == id);
            CasaShowDTO casashowView = new CasaShowDTO ();
            casashowView.Id = casashow.Id;
            casashowView.Nome = casashow.Nome;
            return View (casashowView);
        }
        public IActionResult NovoCasaShow () {
            return View ();
        }
        //EVENTOS
        public IActionResult Eventos () {
            var eventos = database.Eventos.Include (p => p.Categoria).Include (p => p.CasaShow).Where (e => e.Status == true).ToList ();
            
            
            return View (eventos);
        }
        public IActionResult EditarEvento (int id) {
            var evento = database.Eventos.Include (p => p.Categoria).Include (p => p.CasaShow).First (ev => ev.Id == id);
            EventoDTO eventoView = new EventoDTO ();
            eventoView.Id = evento.Id;
            eventoView.Nome = evento.Nome;
            if(evento.Categoria.Status == true && evento.CasaShow.Status == true){
                eventoView.CategoriaID = evento.Categoria.Id;
                eventoView.CasaShowID = evento.CasaShow.Id;
            }
          
            eventoView.QuantDeIngressos = evento.QuantDeIngressos;
            eventoView.Data = evento.Data;

            eventoView.ValorDoIngresso = evento.ValorDoIngresso;

            ViewBag.Categorias = database.Categorias.ToList ();
            ViewBag.CasasShows = database.CasasShows.ToList ();
            return View (eventoView);
        }
        public IActionResult NovoEvento () {
            ViewBag.Categorias = database.Categorias.Where (e => e.Status == true).ToList ();
            ViewBag.CasasShows = database.CasasShows.Where (e => e.Status == true).ToList ();
            return View ();
        }

    }
}