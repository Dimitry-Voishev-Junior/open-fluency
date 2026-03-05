using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OpenFluency.Services;
using OpenFluency.Web.Mappings;
using OpenFluency.Web.Models.Turma;

namespace OpenFluency.Web.Controllers
{
    [Route("turma")]
    [Authorize]
    public class TurmaController : Controller
    {
        private readonly ITurmaService _turmaService;
        private readonly IProfessorService _professorService;
        private readonly IAlunoService _alunoService;

        public TurmaController(
            ITurmaService turmaService,
            IProfessorService professorService,
            IAlunoService alunoService)
        {
            _turmaService = turmaService;
            _professorService = professorService;
            _alunoService = alunoService;
        }

        [Route("criar")]
        public IActionResult Criar()
        {
            var model = new CriarViewModel();

            model.Semestres = ObterListaSemestres();

            model.Professores = ObterListaProfessores();

            return View(model);
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
            var result = _turmaService.Criar(model.MapToCriarTurmaRequest());

            if (!result.Sucesso)
            {
                ModelState.AddModelError(string.Empty, result.MensagemErro!);
                return View(model);
            }

            return RedirectToAction("Listar");
        }

        [Route("listar")]
        public IActionResult Listar()
        {
            var turmas = _turmaService.Listar();

            var result = turmas.Select(c => c.MapToListarViewModel()).ToList();

            return View(result);
        }

        [Route("editar/{id}")]
        public IActionResult Editar(int id)
        {
            var turma = _turmaService.ObterPorId(id);

            if (turma == null)
            {
                return RedirectToAction("listar");
            }

            var model = turma.MapToEditarViewModel();

            model.AlunosTurma = _alunoService.ListarPorTurma(id).Select(c => c.MapToAlunoTurmaViewModel()).ToList();

            model.Alunos = _alunoService.Listar().Select(c => c.MapToAlunoTurmaViewModel()).ToList();

            model.Semestres = ObterListaSemestres();

            model.Professores = ObterListaProfessores();    

            return View(model);
        }

        [Route("editar/{id}")]
        [HttpPost]
        public IActionResult Editar(EditarViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var request = model.MapToEditarTurmaRequest();

            var result = _turmaService.Editar(request);

            if (!result.Sucesso)
            {
                ModelState.AddModelError(string.Empty, result.MensagemErro!);

                return View(model);
            }

            return RedirectToAction("Listar");
        }

        [HttpPost]
        [Route("associarAlunos")]
        public IActionResult AssociarAluno(int turmaId)
        {
            foreach (var formItem in Request.Form)
            {
                if (formItem.Key.StartsWith("aluno_"))
                {
                    var alunoId = int.Parse(formItem.Key.Split("_")[1]);

                    _turmaService.AssociarAlunoTurma(alunoId, turmaId);
                }
            }

            return RedirectToAction("Editar", "turma", new {id = turmaId});
        }

        [HttpPost]
        [Route("desassociarAluno")]
        public IActionResult DesassociarAluno(int alunoId, int turmaId)
        {
            _turmaService.DesassociarAlunoTurma(alunoId, turmaId);

            return RedirectToAction("Editar", "Turma", new { id = turmaId });
        }

        [Route("excluir/{id}")]
        [HttpPost]
        public IActionResult Excluir(EditarViewModel model)
        {
            var result = _turmaService.Excluir(model.Id);

            if (!result.Sucesso)
            {
                ModelState.AddModelError(string.Empty, result.MensagemErro!);
                return View(model);
            }

            return RedirectToAction("Listar");
        }

        private List<SelectListItem> ObterListaSemestres()
        {
            return new List<SelectListItem>
            {
                new SelectListItem { Value = "1", Text = "1º Semestre" },
                new SelectListItem { Value = "2", Text = "2º Semestre" }
            };
        }

        private List<SelectListItem> ObterListaProfessores()
        {
            return _professorService.Listar()
                .Select(p => new SelectListItem(p.Nome, p.Id.ToString())).ToList();
        }
    }
}
