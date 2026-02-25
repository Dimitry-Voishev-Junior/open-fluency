using OpenFluency.Repositories;
using OpenFluency.Services.Mappings;
using OpenFluency.Services.Models.Aluno;

namespace OpenFluency.Services
{
    public interface IAlunoService
    {
        CriarAlunoResult Criar(CriarAlunoRequest request);
    }

    public class AlunoService : IAlunoService
    {
        private readonly IAlunoRepository _alunoRepository;
        private readonly IUsuarioRepository _usuarioRepository;

        public AlunoService(IAlunoRepository alunoRepository, IUsuarioRepository usuarioRepository)
        {
            _alunoRepository = alunoRepository;
            _usuarioRepository = usuarioRepository;
        }

        public CriarAlunoResult Criar(CriarAlunoRequest request)
        {
            var result = new CriarAlunoResult();
            var usuarioExistente = _usuarioRepository.ObterPorLogin(request.Login);

            if (usuarioExistente != null)
            {
                result.MensagemErro = "Login já existe.";
                return result;
            }

            //inserir usuario

            var usuario = request.MapToUsuario();

            var usuarioId = _usuarioRepository.Inserir(usuario);

            if (!usuarioId.HasValue)
            {
                result.MensagemErro = "Erro ao inserir usuário.";
                return result;
            }

            //inserir aluno

            var aluno = request.MapToAluno(usuarioId.Value);

            _alunoRepository.Inserir(aluno);

            result.Sucesso = true;

            return result;
        }
    }
}
