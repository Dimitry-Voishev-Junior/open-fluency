using OpenFluency.Repositories.Entities;
using OpenFluency.Services.Enums;
using OpenFluency.Services.Models.Professor;

namespace OpenFluency.Services.Mappings
{
    public static class UsuarioMapping
    {
        public static Usuario MapToUsuario(this CriarProfessorRequest request)
        {
            var usuario = new Usuario
            {
                Login = request.Login,
                Senha = request.Senha,
                PapelId = (int)Papel.Professor
            };

            return usuario;
        }

        public static Usuario MapToUsuario(this EditarProfessorRequest request)
        {
            var usuario = new Usuario
            {
                Id = request.Id,
                Login = request.Login,
                Senha = request.Senha
            };
            return usuario;
        }
    }
}
