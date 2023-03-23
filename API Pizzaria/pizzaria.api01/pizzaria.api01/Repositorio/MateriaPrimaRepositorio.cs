using pizzaria.api01.Model;
using System.Data;

namespace pizzaria.api01.Repositorio
{
    public class MateriaPrimaRepositorio : RepositorioBaseMateriaPrima<MateriaPrimas>
    {
        public MateriaPrimaRepositorio(IDbConnection dbConnection) : base(dbConnection)
        {
        }
    }
}
