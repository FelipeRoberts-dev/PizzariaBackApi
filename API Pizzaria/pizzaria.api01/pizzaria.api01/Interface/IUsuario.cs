
namespace pizzaria.api01.Interface
{
    public interface IUsuario<Usuarios>
    {
        Task<IEnumerable<Usuarios>> ListarUsuario();
        Task<Usuarios> GetByIdUsuario(int id);
        Task<int> InserirUsuarios(Usuarios usuarios);
        Task<bool> AlterarUsuarios(Usuarios usuarios);
        Task<bool> ExcluirUsuarios(int id);
    }
}
