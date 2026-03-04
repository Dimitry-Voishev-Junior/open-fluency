using OpenFluency.Services.Models.Aluno;
using OpenFluency.Web.Models.Aluno;

namespace OpenFluency.Web.Mappings
{
    public static class AlunoMapping
    {
        public static CriarAlunoRequest MapToCriarAlunoRequest(this CriarViewModel model)
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

        public static Models.Turma.AlunoTurmaViewModel MapToAlunoTurmaViewModel(this AlunoResult model)
        {
            var viewModel = new Models.Turma.AlunoTurmaViewModel    
            {
                Id = model.Id,
                Nome = model.Nome,
                Email = model.Email,
                Login = model.Login
            };

            return viewModel;
        }

        public static EditarViewModel MapToEditarViewModel(this AlunoResult model)
        {
            var viewModel = new EditarViewModel
            {
                Id = model.Id,
                UsuarioId = model.UsuarioId,
                Login = model.Login,
                Senha = model.Senha,
                Nome = model.Nome,
                Email = model.Email
            };
            return viewModel;
        }

        public static EditarAlunoRequest MapToEditarAlunoRequest(this EditarViewModel model)
        {
            var request = new EditarAlunoRequest
            {
                Id = model.Id,
                UsuarioId = model.UsuarioId,
                Login = model.Login!,
                Senha = model.Senha!,
                Nome = model.Nome!,
                Email = model.Email!
            };
            return request;
        }
    }
}
