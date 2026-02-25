using OpenFluency.Services.Models.Aluno;
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
    }
}
