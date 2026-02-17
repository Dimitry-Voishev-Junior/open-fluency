using Microsoft.AspNetCore.Mvc;
using OpenFluency.Web.Models.Erro;

namespace OpenFluency.Web.Controllers
{
    public class ErroController : Controller
    {
        public IActionResult Index()
        {
            var exepectionHandlerPathFeature = HttpContext.Features.Get<Microsoft.AspNetCore.Diagnostics.IExceptionHandlerPathFeature>();
            var model = new ErroViewModel
            {
                MensagemErro = exepectionHandlerPathFeature == null ? "Erro inesperado" : exepectionHandlerPathFeature.Error.Message
            };

            return View(model);
        }
    }
}
