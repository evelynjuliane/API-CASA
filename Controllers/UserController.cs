using System.Linq;
using System.Threading.Tasks;
using CasaDeShow.Data;
using CasaDeShow.DTO;
using CasaDeShow.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
namespace CasaDeShow.Controllers {
    [Authorize]
    public class UserController : Controller {
        private readonly ApplicationDbContext database;
        private readonly UserManager<IdentityUser> _userManager;
       
        public UserController (ApplicationDbContext database, UserManager<IdentityUser> userManager) {
            this.database = database;
            _userManager = userManager;

        }
       
        //Eventos
        public IActionResult Index () {
            var eventos = database.Eventos.Include (p => p.Categoria).Include (p => p.CasaShow).Where (e => e.Status == true).ToList ();
            
            
            return View (eventos);
        }
        //HISTORICO DE COMPRAS
        public async Task<ActionResult> Historico () {
            var user = await _userManager.GetUserAsync(User);
            
            var vendas = database.Vendas.Where(c => c.User == user.NormalizedUserName).ToList();
            
            return View (vendas);
        }
        //  PRÉ ATRIBUIÇÃO
        [HttpPost]
        public async Task<IActionResult> Exibir(int id){
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);
                VendaDTO compra = new VendaDTO();
                var evento = database.Eventos.Include(e => e.CasaShow).Include(c => c.Categoria).First(e => e.Id == id);

                compra.EventoID = evento.Id;
                compra.Nome = evento.Nome;
                compra.QuantidadeDeIngressos = evento.QuantDeIngressos;
                compra.Data = evento.Data;
                compra.Preco = evento.ValorDoIngresso;
                compra.CasaShowID = evento.CasaShow.Id;
                compra.CategoriaID = evento.Categoria.Id;
                compra.img = evento.img;
                compra.QuantidadeComprada = compra.QuantidadeComprada;
                compra.User = user.NormalizedUserName;
                ViewBag.CasasShows = database.CasasShows.Where(p => p.Status == true).ToList();
                ViewBag.Categorias = database.Categorias.Where(p => p.Status == true).ToList();
                ViewBag.NomeCategoria = evento.Categoria.Nome;
                ViewBag.NomeCasa = evento.CasaShow.Nome;
                ViewBag.Local = evento.CasaShow.Local;
                ViewBag.QuantidadeDeIngressos = evento.QuantDeIngressos;
                
                compra.Status = true;

                return View(compra);
            }else{
                
                ViewBag.CasasShows = database.CasasShows.ToList ();
                ViewBag.Categorias = database.Categorias.ToList ();
                return View ("../User/Index");
                
            }
        }
        //SALVANDO VENDA
        [HttpPost]
        public async Task<IActionResult> Salvar (VendaDTO compra) {
            var user = await _userManager.GetUserAsync(User);
            

            if (ModelState.IsValid) {
                Venda venda = new Venda ();
                venda.Nome = compra.Nome;
                venda.QuantidadeDeIngressos = compra.QuantidadeDeIngressos;
                venda.Data = compra.Data;
                venda.ValorDeIngressos = compra.Preco;
                venda.CasaShow = database.CasasShows.First (casadeshow => casadeshow.Id == compra.CasaShowID);
                venda.Categoria = database.Categorias.First(cat => cat.Id == compra.CategoriaID);
                venda.User = user.NormalizedUserName;
                var aux = database.Eventos.First(s => s.Id == compra.EventoID);
                aux.QuantDeIngressos -= compra.QuantidadeComprada;
                venda.QuantidadeDeIngressos -= compra.QuantidadeComprada;
                venda.QuantidadeComprada = compra.QuantidadeComprada;
                venda.Total = compra.QuantidadeComprada * compra.Preco;
                database.Vendas.Add (venda);
                database.SaveChanges ();
                ViewBag.CasasShow = database.CasasShows.ToList ();

                return RedirectToAction ("Historico");

            } else {
                ViewBag.CasasShow = database.CasasShows.Where (p => p.Status == true).ToList ();
                return View ("../User/Index");
            }

        }
    }
}