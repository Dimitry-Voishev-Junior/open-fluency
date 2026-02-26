using OpenFluency.Repositories;
using OpenFluency.Services.Mappings;
using OpenFluency.Services.Models.Aluno;

namespace OpenFluency.Services
{
    public interface IAlunoService
    {
        CriarAlunoResult Criar(CriarAlunoRequest request);
        IList<AlunoResult> Listar();
        EditarAlunoResult Editar(EditarAlunoRequest request);
        ExcluirAlunoResult Excluir(int id);
        AlunoResult? ObterPorId(int id);
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

        public IList<AlunoResult> Listar()
        {
            var alunos = _alunoRepository.Listar();

            var result = alunos.Select(a => a.MapToAlunoResult()).ToList();

            return result;
        }

        public EditarAlunoResult Editar(EditarAlunoRequest request)
        {
            var result = new EditarAlunoResult();
            var usuarioExistente = _usuarioRepository.ObterPorLogin(request.Login);

            if (usuarioExistente != null && usuarioExistente.Id != request.UsuarioId)
            {
                result.MensagemErro = "Já existe outro usuário com esse login.";
                return result;
            }

            var aluno = request.MapToAluno();

            var affectedRows = _alunoRepository.Atualizar(aluno);

            if (affectedRows == 0)
            {
                result.MensagemErro = "Não foi possível atualizar o aluno.";
                return result;
            }

            var usuario = request.MapToUsuario();

            affectedRows = _usuarioRepository.Atualizar(usuario);

            if (affectedRows == 0)
            {
                result.MensagemErro = "Não foi possível atualizar o professor.";
                return result;
            }

            result.Sucesso = true;

            return result;
        }

        public ExcluirAlunoResult Excluir(int id)
        {
            var result = new ExcluirAlunoResult();

            var aluno = _alunoRepository.ObterPorId(id);

            if (aluno == null)
            {
                result.MensagemErro = "Aluno não encontrado.";
                return result;
            }

            var affectedRows = _alunoRepository.Apagar(id);

            if (affectedRows == 0)
            {
                result.MensagemErro = "Não foi possível excluir o aluno.";
                return result;
            }

            affectedRows = _usuarioRepository.Apagar(aluno.UsuarioId);

            if (affectedRows == 0)
            {
                result.MensagemErro = "Não foi possível excluir o usuário.";
                return result;
            }

            result.Sucesso = true;

            return result;
        }

        public AlunoResult? ObterPorId(int id)
        {
            var aluno = _alunoRepository.ObterPorId(id);

            if (aluno == null)
            {
                return null;
            }
            var result = aluno.MapToAlunoResult();

            return result;
        }
    }
}