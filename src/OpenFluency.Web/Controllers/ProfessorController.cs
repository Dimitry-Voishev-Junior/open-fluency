using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OpenFluency.Services;
using OpenFluency.Services.Models.Professor;
using OpenFluency.Web.Models.Professor;

namespace OpenFluency.Web.Controllers
{

    [Route("professor")]
    [Authorize]
    public class ProfessorController : Controller
    {
        private readonly IProfessorService _professorService;
        public ProfessorController(IProfessorService professorService) 
        { 
            _professorService = professorService;
        }

        [Route("criar")]
        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        [Route("criar")]
       public IActionResult Criar(CriarViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // criar o professor
            var result = _professorService.Criar(new CriarProfessorRequest
            {
                Login = model.Login!,
                Senha = model.Senha!,
                Nome = model.Nome!,
                Email = model.Email!,
            });

            if (!result.Sucesso)
            {
                ModelState.AddModelError(string.Empty, result.MensagemErro!);
                return View(model);
            }

            return RedirectToAction("Index", "Home");
        }
    }
}
