using APIAlmoxarifado.Models;

namespace APIAlmoxarifado.Repositorios.Interfaces
{
    public interface IUsuarioRepositorio
    {
        Task<List<UsuarioModel>> BuscarTodosUsuarios();

        Task<UsuarioModel> Adicionar(UsuarioModel usuario);
        Task<UsuarioModel> Atualizar(UsuarioModel usuario, int id);
        Task<bool> Apagar(int id);
        Task<UsuarioModel> BuscarPorId(int id);
        Task<UsuarioModel> Atualizar(UsuarioModel usuarioModel);
    }
}
