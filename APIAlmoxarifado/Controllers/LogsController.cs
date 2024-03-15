using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using APIAlmoxarifado.Models;
using APIAlmoxarifado.Repositorios.Interfaces;

namespace APIAlmoxarifado.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogsController : ControllerBase
    {
        private readonly ILogsRepositorio _logsRepositorio;

        public LogsController(ILogsRepositorio logsRepositorio)
        {
            _logsRepositorio = logsRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Logs>>> GetLogs()
        {
            var logs = await _logsRepositorio.BuscarTodosLogs();
            return Ok(logs);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Logs>> GetLog(int id)
        {
            var log = await _logsRepositorio.BuscarPorId(id);
            if (log == null)
            {
                return NotFound();
            }
            return log;
        }

        [HttpPost]
        public async Task<ActionResult<Logs>> PostLog(Logs log)
        {
            var newLog = await _logsRepositorio.Adicionar(log);
            return CreatedAtAction(nameof(GetLog), new { id = newLog.IdLog }, newLog);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLog(int id)
        {
            var log = await _logsRepositorio.BuscarPorId(id);
            if (log == null)
            {
                return NotFound();
            }

            await _logsRepositorio.Apagar(id);
            return NoContent();
        }
    }
}
