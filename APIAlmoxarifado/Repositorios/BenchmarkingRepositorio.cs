using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using APIAlmoxarifado.Models;
using APIAlmoxarifado.Repositorios.Interfaces;
using APIAlmoxarifado.Data;

namespace APIAlmoxarifado.Repositorios
{
    public class BenchmarkingRepositorio : IBenchmarkingRepositorio
    {
        private readonly SistemaTarefasDBContext _context;

        public BenchmarkingRepositorio(SistemaTarefasDBContext context)
        {
            _context = context;
        }

        public async Task<List<Benchmarking>> BuscarTodosBenchmarkings()
        {
            return await _context.Benchmarking.ToListAsync();
        }

        public async Task<Benchmarking> BuscarPorId(int id)
        {
            return await _context.Benchmarking.FindAsync(id);
        }

        public async Task<Benchmarking> Adicionar(Benchmarking benchmarking)
        {
            _context.Benchmarking.Add(benchmarking);
            await _context.SaveChangesAsync();
            return benchmarking;
        }

        public async Task<bool> Apagar(int id)
        {
            var benchmarking = await _context.Benchmarking.FindAsync(id);
            if (benchmarking == null)
            {
                return false;
            }

            _context.Benchmarking.Remove(benchmarking);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
