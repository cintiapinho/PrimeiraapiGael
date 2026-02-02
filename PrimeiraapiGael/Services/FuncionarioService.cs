using PrimeiraapiGael.Models;
using PrimeiraapiGael.Repositories;

namespace PrimeiraapiGael.Services
{
    // Classe que contém as regras de negócio da aplicação.
    public class FuncionarioService
    {
        private readonly FuncionarioRepository _repository = new();

        public List<Funcionario> ObterFuncionarios() => _repository.ListarTodos();

        public void CriarFuncionario(Funcionario funcionario)
        {
            // Exemplo de regra de negócio: não cadastrar menores de 14 anos.
            if (funcionario.Idade >= 14)
            {
                _repository.Adicionar(funcionario);
            }
        }
    }
}
