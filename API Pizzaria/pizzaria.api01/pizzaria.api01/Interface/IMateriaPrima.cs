namespace pizzaria.api01.Interface
{
    public interface IMateriaPrima<MateriaPrimas>
    {
        Task<IEnumerable<MateriaPrimas>> ListarMateriaPrima();
        Task<MateriaPrimas> GetByIdMateriaPrima(int id);
        Task<int> InserirMateriaPrima(MateriaPrimas materiaPrimas);
        Task<bool> AlterarMateriaPrima(MateriaPrimas materiaPrimas);
        Task<bool> ExcluirMateriaPrima(int id);
    }
}
