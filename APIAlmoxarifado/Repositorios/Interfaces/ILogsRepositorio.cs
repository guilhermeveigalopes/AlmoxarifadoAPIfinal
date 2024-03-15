using System.Collections.Generic;
using System.Threading.Tasks;
using APIAlmoxarifado.Models;

namespace APIAlmoxarifado.Repositorios.Interfaces
{
    public interface ILogsRepositorio
    {
        Task<List<Logs>> BuscarTodosLogs();
        Task<Logs> BuscarPorId(int id);
        Task<Logs> Adicionar(Logs log);
        Task<bool> Apagar(int id);
    }
}
