using OpenFluency.Services.Models.Professor;
using OpenFluency.Web.Models.Professor;

namespace OpenFluency.Web.Mappings
{
    public static class ProfessorMapping
    {
        public static CriarProfessorRequest MaptoCriarProfessorRequest(this CriarViewModel model)
        {
            var request = new CriarProfessorRequest
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
