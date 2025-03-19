using Microsoft.AspNetCore.Mvc;
using PraticaExamen.Models;
using PraticaExamen.Repositories;

namespace PraticaExamen.ViewComponents
{
    public class MenuMarcasViewComponent : ViewComponent
    {
        private RepositoryCubos repo;

        public MenuMarcasViewComponent(RepositoryCubos repo)
        {
            this.repo = repo;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<Marca> marcas = await this.repo.GetMarcaAsync();
            return View(marcas);
        }
    }
}
