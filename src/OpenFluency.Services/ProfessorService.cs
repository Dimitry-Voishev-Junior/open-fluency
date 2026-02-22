using OpenFluency.Repositories;
using OpenFluency.Services.Mappings;
using OpenFluency.Services.Models.Professor;

namespace OpenFluency.Services
{
    public interface IProfessorService
    {
        CriarProfessorResult Criar(CriarProfessorRequest request);
        IList<ProfessorResult> Listar();
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

            var usuario = request.MapToUsuario();

            var usuarioId = _usuarioRepository.Inserir(usuario);

            if (!usuarioId.HasValue)
            {
                result.MensagemErro = "Erro ao inserir usuário.";
                return result;
            }

            //inserir professor

            var professor = request.MapToProfessor(usuarioId.Value);

            _professorRepository.Inserir(professor);

            result.Sucesso = true;

            return result;
        }

        public IList<ProfessorResult> Listar()
        {
            var professores = _professorRepository.Listar();

            var result = professores.Select(c => c.MapToProfessorResult()).ToList();

            return result;
        }
    }
}
