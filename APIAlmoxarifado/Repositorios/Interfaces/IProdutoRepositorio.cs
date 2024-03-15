using System.Collections.Generic;
using System.Threading.Tasks;
using APIAlmoxarifado.Models;

namespace APIAlmoxarifado.Repositorios.Interfaces
{
    public interface IProdutoRepositorio
    {
        Task<List<Produto>> BuscarTodosProdutos();
        Task<Produto> Adicionar(Produto produto);
        Task<Produto> Atualizar(Produto produto, int id);
        Task<bool> Apagar(int id);
        Task<Produto> BuscarPorId(int id);
    }
}
