using pizzaria.api01.Model;
using System.Data;

namespace pizzaria.api01.Repositorio
{
    public class UsuariosRepositorio : RepositorioBaseUsuarios<Usuarios>
    {
        public UsuariosRepositorio(IDbConnection dbConnection) : base(dbConnection)
        {

        }
    }
}
