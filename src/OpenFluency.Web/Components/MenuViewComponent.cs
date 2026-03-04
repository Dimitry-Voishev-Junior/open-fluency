using Microsoft.AspNetCore.Mvc;
using OpenFluency.Web.Models.Menu;

namespace OpenFluency.Web.Components
{
    public class MenuViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var model = new MenuViewModel
            {
                Ativo = ViewData["Menu"] as Menu? ?? Menu.Home
            };

            return View(model);
        }
    }
}
