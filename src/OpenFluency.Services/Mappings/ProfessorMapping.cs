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
    }
}
