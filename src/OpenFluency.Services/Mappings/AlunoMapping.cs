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

        public static AlunoResult MapToAlunoResult(this Aluno aluno)
        {
            var result = new AlunoResult
            {
                Id = aluno.Id,
                UsuarioId = aluno.UsuarioId,
                Nome = aluno.Nome,
                Email = aluno.Email,
                Login = aluno.Usuario.Login,
                Senha = aluno.Usuario.Senha,
            };
            return result;
        }
    }
}
