using System;
using System.Linq;
using CasaDeShow.Data;
using CasaDeShow.DTO;
using CasaDeShow.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
namespace CasaDeShow.Controllers
{
    [Authorize(Policy="Admin")]
    public class CasaShowController : Controller
    {
        private readonly ApplicationDbContext database;
        public CasaShowController(ApplicationDbContext database){
            this.database = database;
        }

        [HttpPost]
        public IActionResult Salvar(CasaShowDTO casaTemporaria){
            if(ModelState.IsValid){
                CasaShow casashow = new CasaShow();
                casashow.Nome = casaTemporaria.Nome;
                casashow.Local = casaTemporaria.Local;
                casashow.Status = true;
                database.CasasShows.Add(casashow);
                database.SaveChanges();
                return RedirectToAction("CasaShows", "Admin");
            }else{
                return View("../Admin/NovoCasaShow");
            }
        }
        [HttpPost]
        public IActionResult Atualizar (CasaShowDTO casashowTemporaria) {
            if (ModelState.IsValid) {
                var casashow = database.CasasShows.First (cat => cat.Id == casashowTemporaria.Id);
                casashow.Nome = casashowTemporaria.Nome;
                casashow.Local = casashowTemporaria.Local;
                database.SaveChanges ();
                return RedirectToAction ("CasaShows", "Admin");
            } else {
                return View ("/Admin/EditarCasaShow");
            }

        }

        [HttpPost]
        public IActionResult Deletar (int id) {
            if (id > 0) {
                var casashow = database.CasasShows.First (cat => cat.Id == id);
                casashow.Status = false;
                database.SaveChanges ();
            }
            return RedirectToAction ("CasaShows", "Admin");

        }
    }
}