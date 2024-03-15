using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using APIAlmoxarifado.Data;
using APIAlmoxarifado.Models;
using APIAlmoxarifado.Repositorios.Interfaces;

namespace APIAlmoxarifado.Repositorios
{
    public class ProdutoRepositorio : IProdutoRepositorio
    {
        private readonly SistemaTarefasDBContext _context;

        public ProdutoRepositorio(SistemaTarefasDBContext context)
        {
            _context = context;
        }

        public async Task<List<Produto>> BuscarTodosProdutos()
        {
            return await _context.Produtos.ToListAsync();
        }

        public async Task<Produto> Adicionar(Produto produto)
        {
            _context.Produtos.Add(produto);
            await _context.SaveChangesAsync();
            return produto;
        }

        public async Task<Produto> Atualizar(Produto produto, int id)
        {
            var produtoExistente = await _context.Produtos.FindAsync(id);
            if (produtoExistente == null)
                return null;

            produtoExistente.Descricao = produto.Descricao;
            produtoExistente.Preco = produto.Preco;
            produtoExistente.EstoqueAtual = produto.EstoqueAtual;
            produtoExistente.EstoqueMinimo = produto.EstoqueMinimo;
            produtoExistente.Status = produto.Status;
            produtoExistente.EmailStatus = produto.EmailStatus;

            await _context.SaveChangesAsync();

            return produtoExistente;
        }

        public async Task<bool> Apagar(int id)
        {
            var produto = await _context.Produtos.FindAsync(id);
            if (produto == null)
                return false;

            _context.Produtos.Remove(produto);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Produto> BuscarPorId(int id)
        {
            return await _context.Produtos.FindAsync(id);
        }
    }
}
