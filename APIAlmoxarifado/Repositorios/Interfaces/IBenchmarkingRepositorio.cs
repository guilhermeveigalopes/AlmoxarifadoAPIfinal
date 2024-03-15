using System.Collections.Generic;
using System.Threading.Tasks;
using APIAlmoxarifado.Models;

namespace APIAlmoxarifado.Repositorios.Interfaces
{
    public interface IBenchmarkingRepositorio
    {
        Task<List<Benchmarking>> BuscarTodosBenchmarkings();
        Task<Benchmarking> BuscarPorId(int id);
        Task<Benchmarking> Adicionar(Benchmarking benchmarking);
        Task<bool> Apagar(int id);
    }
}
