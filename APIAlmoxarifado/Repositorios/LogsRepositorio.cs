using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using APIAlmoxarifado.Models;
using APIAlmoxarifado.Repositorios.Interfaces;
using APIAlmoxarifado.Data;

namespace APIAlmoxarifado.Repositorios
{
    public class LogsRepositorio : ILogsRepositorio
    {
        private readonly SistemaTarefasDBContext _context;

        public LogsRepositorio(SistemaTarefasDBContext context)
        {
            _context = context;
        }

        public async Task<List<Logs>> BuscarTodosLogs()
        {
            return await _context.Logs.ToListAsync();
        }

        public async Task<Logs> BuscarPorId(int id)
        {
            return await _context.Logs.FindAsync(id);
        }

        public async Task<Logs> Adicionar(Logs log)
        {
            _context.Logs.Add(log);
            await _context.SaveChangesAsync();
            return log;
        }

        public async Task<bool> Apagar(int id)
        {
            var log = await _context.Logs.FindAsync(id);
            if (log == null)
            {
                return false;
            }

            _context.Logs.Remove(log);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
