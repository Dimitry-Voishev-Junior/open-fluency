using OpenFluency.Repositories.Entities;
using OpenFluency.Services.Models.Professor;

namespace OpenFluency.Services.Mappings
{
    public static class ProfessorMapping
    {
        public static Professor MapToProfessor(this CriarProfessorRequest request, int usuarioID)
        {
            var professor = new Professor
            {
                Nome = request.Nome,
                Email = request.Email,
                UsuarioId = usuarioID
            };

            return professor;
        }

        public static ProfessorResult MapToProfessorResult(this Professor professor)
        {
            var result = new ProfessorResult
            {
                Id = professor.Id,
                Nome = professor.Nome,
                Email = professor.Email,
                Login = professor.Usuario.Login,
                Senha = professor.Usuario.Senha,
            };
            return result;
        }

        public static Professor MapToProfessor(this EditarProfessorRequest request)
        {
            var professor = new Professor
            {
                Id = request.Id,
                Nome = request.Nome,
                Email = request.Email
            };

            return professor;
        }
    }
}
