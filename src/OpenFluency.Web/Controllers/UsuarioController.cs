using Microsoft.AspNetCore.Mvc;

namespace OpenFluency.Web.Controllers
{
    public class UsuarioController : Controller
    {
        [Route("login")]
        public IActionResult Login()
        {
            return View();
        }
    }
}
