using Dapper;
using pizzaria.api01.Interface;
using System.Data;

namespace pizzaria.api01.Repositorio
{
    public  abstract class RepositorioBaseMateriaPrima<MateriaPrimas> : IMateriaPrima<MateriaPrimas>
    {
        protected readonly IDbConnection _dbConnection;

        public RepositorioBaseMateriaPrima(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public virtual async Task<IEnumerable<MateriaPrimas>> ListarMateriaPrima()
        {
            return await _dbConnection.QueryAsync<MateriaPrimas>($"SELECT * FROM {typeof(MateriaPrimas).Name}");
        }

        public virtual async Task<MateriaPrimas> GetByIdMateriaPrima(int id)
        {
            return await _dbConnection.QueryFirstOrDefaultAsync<MateriaPrimas>($"SELECT * FROM {typeof(MateriaPrimas).Name} WHERE Id = @id", new { id });
        }
        public virtual async Task<int> InserirMateriaPrima(MateriaPrimas materiaPrima)
        {
            var query = $"INSERT INTO {typeof(MateriaPrimas).Name} (Descricao, Estoque) VALUES (@Descricao, @Estoque); SELECT SCOPE_IDENTITY();";
            return await _dbConnection.ExecuteScalarAsync<int>(query, materiaPrima);
        }
        public virtual async Task<bool> AlterarMateriaPrima(MateriaPrimas materiaPrima)
        {
            var query = $"UPDATE {typeof(MateriaPrimas).Name} SET Descricao = @Descricao, Estoque = @Estoque WHERE Id = @Id";
            var result = await _dbConnection.ExecuteAsync(query, materiaPrima);
            return result > 0;
        }
        public virtual async Task<bool> ExcluirMateriaPrima(int id)
        {
            var query = $"DELETE FROM {typeof(MateriaPrimas).Name} WHERE Id = @id";
            var result = await _dbConnection.ExecuteAsync(query, new { id });
            return result > 0;
        }

    }
}
