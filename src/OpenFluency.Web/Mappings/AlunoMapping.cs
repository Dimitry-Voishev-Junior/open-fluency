using OpenFluency.Services.Models.Aluno;
using OpenFluency.Services.Models.Professor;
using OpenFluency.Web.Models.Aluno;

namespace OpenFluency.Web.Mappings
{
    public static class AlunoMapping
    {
        public static CriarAlunoRequest MaptoCriarAlunoRequest(this CriarViewModel model)
        {
            var request = new CriarAlunoRequest
            {
                Login = model.Login!,
                Senha = model.Senha!,
                Nome = model.Nome!,
                Email = model.Email!
            };

            return request;
        }

        public static ListarViewModel MapToListarViewModel(this AlunoResult model)
        {
            var viewModel = new ListarViewModel
            {
                Id = model.Id,
                Nome = model.Nome,
                Email = model.Email,
                Login = model.Login
            };

            return viewModel;
        }
    }
}
