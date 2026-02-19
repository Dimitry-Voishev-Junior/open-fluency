using OpenFluency.Services.Models.Usuario;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenFluency.Services
{
    public interface IUsuarioService
    {
        ValidarLoginResult ValidarLogin(string usuario, string senha);
    }

    public class UsuarioService : IUsuarioService
    {
        public ValidarLoginResult ValidarLogin(string usuario, string senha) 
        {
            var result = new ValidarLoginResult();

            result.Sucesso = true;

            return result;
        }

    }
}
