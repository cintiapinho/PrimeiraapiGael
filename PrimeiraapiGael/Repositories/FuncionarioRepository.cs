using PrimeiraapiGael.Models;

namespace PrimeiraapiGael.Repositories
{
    // Classe responsável pela persistência de dados (CRUD).
    public class FuncionarioRepository
    {
        // Lista em memória para simular uma tabela de banco de dados.
        private static readonly List<Funcionario> _funcionarios = new();

        public List<Funcionario> ListarTodos() => _funcionarios;

        public void Adicionar(Funcionario funcionario)
        {
            funcionario.Id = _funcionarios.Count + 1;
            _funcionarios.Add(funcionario);
        }

        // Outros métodos do CRUD (ObterPorId, Atualizar, Deletar) virão aqui.
    }
}