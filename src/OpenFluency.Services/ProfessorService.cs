using OpenFluency.Repositories;
using OpenFluency.Services.Enums;
using OpenFluency.Services.Models.Professor;

namespace OpenFluency.Services
{
    public interface IProfessorService
    {
        CriarProfessorResult Criar(CriarProfessorRequest request);
    }

    public class ProfessorService : IProfessorService
    {
        private readonly IProfessorRepository _professorRepository;
        private readonly IUsuarioRepository _usuarioRepository;

        public ProfessorService(IProfessorRepository professorRepository, IUsuarioRepository usuarioRepository)
        {
            _professorRepository = professorRepository;
            _usuarioRepository = usuarioRepository;
        }

        public CriarProfessorResult Criar(CriarProfessorRequest request)
        {
            var result = new CriarProfessorResult();
            var usuarioExistente = _usuarioRepository.ObterPorLogin(request.Login);

            if (usuarioExistente != null)
            {
                result.MensagemErro = "Usuário já existe.";
                return result;
            }

            //inserir usuário

            var usuarioID = _usuarioRepository.Inserir(new Repositories.Entities.Usuario
             {
               Login = request.Login,
               Senha = request.Senha,
               PapelId = (int)Papel.Professor
             });

            if (!usuarioID.HasValue)
            {
                result.MensagemErro = "Erro ao inserir usuário.";
                return result;
            }

            //inserir professor
            _professorRepository.Inserir(new Repositories.Entities.Professor
            {
                Nome = request.Nome,
                Email = request.Email,
                UsuarioId = usuarioID.Value
            }); 

            result.Sucesso = true;

            return result;
        }
    }
}
