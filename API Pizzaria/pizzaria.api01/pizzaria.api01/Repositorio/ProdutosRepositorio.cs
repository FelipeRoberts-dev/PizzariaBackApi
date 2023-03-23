using pizzaria.api01.Model;
using System.Data;

namespace pizzaria.api01.Repositorio
{
    public class ProdutosRepositorio : RepositorioBaseProdutos<Produtos>
    {
        public ProdutosRepositorio(IDbConnection dbConnection) : base(dbConnection)
        {
        }
    }
}
