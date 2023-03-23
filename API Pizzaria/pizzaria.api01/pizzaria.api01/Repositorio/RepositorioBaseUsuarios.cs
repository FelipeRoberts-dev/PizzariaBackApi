using Dapper;
using pizzaria.api01.Interface;
using System.Data;

namespace pizzaria.api01.Repositorio
{
    public abstract class RepositorioBaseUsuarios<Usuarios> : IUsuario<Usuarios>
    {
        protected readonly IDbConnection _dbConnection;

        public RepositorioBaseUsuarios(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public virtual async Task<IEnumerable<Usuarios>> ListarUsuario()
        {
            return await _dbConnection.QueryAsync<Usuarios>($"SELECT * FROM {typeof(Usuarios).Name}");
        }

        public virtual async Task<Usuarios> GetByIdUsuario(int id)
        {
            return await _dbConnection.QueryFirstOrDefaultAsync<Usuarios>($"SELECT * FROM {typeof(Usuarios).Name} WHERE Id = @id", new { id });
        }

        public virtual async Task<int> InserirUsuarios(Usuarios usuarios)
        {
            var query = $"INSERT INTO {typeof(Usuarios).Name} (Nome, Senha) VALUES (@Nome, @Senha); SELECT SCOPE_IDENTITY();";
            return await _dbConnection.ExecuteScalarAsync<int>(query, usuarios);
        }

        public virtual async Task<bool> AlterarUsuarios(Usuarios usuarios)
        {
            var query = $"UPDATE {typeof(Usuarios).Name} SET Nome = @Nome, Senha = @Senha WHERE Id = @Id";
            var result = await _dbConnection.ExecuteAsync(query, usuarios);
            return result > 0;
        }

        public virtual async Task<bool> ExcluirUsuarios(int id)
        {
            var query = $"DELETE FROM {typeof(Usuarios).Name} WHERE Id = @id";
            var result = await _dbConnection.ExecuteAsync(query, new { id });
            return result > 0;
        }

    }
}
