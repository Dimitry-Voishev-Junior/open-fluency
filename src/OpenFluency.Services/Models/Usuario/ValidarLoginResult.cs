using System;
using System.Collections.Generic;
using System.Text;

namespace OpenFluency.Services.Models.Usuario
{
    public class ValidarLoginResult
    {
        public bool Sucesso { get; set; }
        public string? MensagemErro { get; set; }
    }
}
