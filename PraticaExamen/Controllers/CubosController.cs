using Microsoft.AspNetCore.Mvc;
using PraticaExamen.Extension;
using PraticaExamen.Filters;
using PraticaExamen.Models;
using PraticaExamen.Repositories;
using System.Security.Claims;

namespace PracticaExamen.Controllers
{
    public class CubosController : Controller
    {
        private RepositoryCubos repo;

        public CubosController(RepositoryCubos repo)
        {
            this.repo = repo;
        }

        [AuthorizeUsuarios]
        public IActionResult Index()
        {
            return View();
        }

        // Listado de cubos por marca
        public async Task<IActionResult> Cubos(int? idmarca)
        {
            List<Cubo> cubos;
            if (idmarca != null)
                cubos = await this.repo.GetCubosByMarcaAsync(idmarca.Value);
            else
                cubos = await this.repo.GetCubosAsync();
            return View(cubos);
        }

        // Detalles de un cubo específico
        public async Task<IActionResult> Details(int idcubo)
        {
            Cubo cubo = await this.repo.FindCuboAsync(idcubo);
            return View(cubo);
        }

        // Agregar un cubo al carrito de compras
        public IActionResult ComprarCubo(int? idcubo)
        {
            if (idcubo != null)
            {
                List<int> carrito;
                if (HttpContext.Session.GetObject<List<int>>("CARRITO") == null)
                    carrito = new List<int>();
                else
                    carrito = HttpContext.Session.GetObject<List<int>>("CARRITO");
                carrito.Add(idcubo.Value);
                HttpContext.Session.SetObject("CARRITO", carrito);
            }
            return RedirectToAction("Carrito");
        }

        // Quitar un cubo del carrito de compras
        public async Task<IActionResult> QuitarCubo(int? idcubo)
        {
            if (idcubo != null)
            {
                List<int> carrito = HttpContext.Session.GetObject<List<int>>("CARRITO");
                carrito.Remove(idcubo.Value);
                if (carrito.Count() == 0)
                    HttpContext.Session.Remove("CARRITO");
                else
                    HttpContext.Session.SetObject("CARRITO", carrito);
            }
            return RedirectToAction("Carrito");
        }

        // Mostrar el carrito de compras
        public async Task<IActionResult> Carrito()
        {
            List<int> carrito = HttpContext.Session.GetObject<List<int>>("CARRITO");
            if (carrito != null)
            {
                List<Cubo> cubos = await this.repo.GetCubosCarritoAsync(carrito);
                return View(cubos);
            }
            return View();
        }

        // Finalizar compra de los cubos en el carrito
        [AuthorizeUsuarios]
        public async Task<IActionResult> FinalizarCompra()
        {
            List<int> carrito = HttpContext.Session.GetObject<List<int>>("CARRITO");
            int idusuario = int.Parse(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
            await this.repo.FinalizarCompraAsync(carrito, idusuario);
            HttpContext.Session.Remove("CARRITO");
            return RedirectToAction("ComprasUsuario");
        }

        // Ver los pedidos realizados por el usuario
        public async Task<IActionResult> ComprasUsuarios()
        {
            int idusuario = int.Parse(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
            List<VistaCompra> vistaCompras = await this.repo.GetPedidosUsuarioAsync(idusuario);
            return View(vistaCompras);
        }

        // Perfil del usuario
        public IActionResult _Perfil()
        {
            return PartialView("_Perfil");
        }
    }
}
