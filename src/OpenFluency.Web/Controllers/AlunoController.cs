using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OpenFluency.Services;
using OpenFluency.Web.Mappings;
using OpenFluency.Web.Models.Aluno;

namespace OpenFluency.Web.Controllers
{
    [Route("aluno")]
    [Authorize]
    public class AlunoController : Controller
    {
        private readonly IAlunoService _alunoService;

        public AlunoController(IAlunoService alunoService)
        {
            _alunoService = alunoService;
        }

        [Route("criar")]
        public IActionResult Criar()
        {
            return View();
        }

        [Route("criar")]
        [HttpPost]

        public IActionResult Criar(CriarViewModel model)
        {
            if (!ModelState.IsValid) 
            {
                return View(model);
            }

            // criar aluno

            var result = _alunoService.Criar(model.MaptoCriarAlunoRequest());

            if (!result.Sucesso)
            {
                ModelState.AddModelError(string.Empty, result.MensagemErro!);
                return View(model);
            }

            return View(model);
        }
    }
}
