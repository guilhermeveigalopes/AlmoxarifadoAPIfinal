using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using APIAlmoxarifado.Models;
using APIAlmoxarifado.Repositorios.Interfaces;

namespace APIAlmoxarifado.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BenchmarkingController : ControllerBase
    {
        private readonly IBenchmarkingRepositorio _benchmarkingRepositorio;

        public BenchmarkingController(IBenchmarkingRepositorio benchmarkingRepositorio)
        {
            _benchmarkingRepositorio = benchmarkingRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Benchmarking>>> GetBenchmarkings()
        {
            var benchmarkings = await _benchmarkingRepositorio.BuscarTodosBenchmarkings();
            return Ok(benchmarkings);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Benchmarking>> GetBenchmarking(int id)
        {
            var benchmarking = await _benchmarkingRepositorio.BuscarPorId(id);
            if (benchmarking == null)
            {
                return NotFound();
            }
            return benchmarking;
        }

        [HttpPost]
        public async Task<ActionResult<Benchmarking>> PostBenchmarking(Benchmarking benchmarking)
        {
            var newBenchmarking = await _benchmarkingRepositorio.Adicionar(benchmarking);
            return CreatedAtAction(nameof(GetBenchmarking), new { id = newBenchmarking.Id }, newBenchmarking);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBenchmarking(int id)
        {
            var benchmarking = await _benchmarkingRepositorio.BuscarPorId(id);
            if (benchmarking == null)
            {
                return NotFound();
            }

            await _benchmarkingRepositorio.Apagar(id);
            return NoContent();
        }
    }
}
