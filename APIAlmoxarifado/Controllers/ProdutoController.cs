using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using APIAlmoxarifado.Models;
using APIAlmoxarifado.Repositorios.Interfaces;

namespace APIAlmoxarifado.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoRepositorio _produtoRepositorio;

        public ProdutoController(IProdutoRepositorio produtoRepositorio)
        {
            _produtoRepositorio = produtoRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<Produto>>> BuscarTodosProdutos()
        {
            try
            {
                var produtos = await _produtoRepositorio.BuscarTodosProdutos();
                return Ok(produtos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Produto>> BuscarProdutoPorId(int id)
        {
            try
            {
                var produto = await _produtoRepositorio.BuscarPorId(id);
                if (produto == null)
                    return NotFound();

                return Ok(produto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Produto>> AdicionarProduto([FromBody] Produto produto)
        {
            try
            {
                var novoProduto = await _produtoRepositorio.Adicionar(produto);
                return CreatedAtAction(nameof(BuscarProdutoPorId), new { id = novoProduto.IdProduto }, novoProduto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }

        // Outros métodos para atualizar e excluir produtos podem ser adicionados conforme necessário
    }
}
