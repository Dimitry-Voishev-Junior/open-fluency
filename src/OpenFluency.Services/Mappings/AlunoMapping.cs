using OpenFluency.Repositories.Entities;
using OpenFluency.Services.Models.Aluno;

namespace OpenFluency.Services.Mappings
{
    public static class AlunoMapping
    {
        public static Aluno MapToAluno(this CriarAlunoRequest request, int usuarioID)
        {
            var aluno = new Aluno
            {
                Nome = request.Nome,
                Email = request.Email,
                UsuarioId = usuarioID
            };

            return aluno;
        }
    }
}
