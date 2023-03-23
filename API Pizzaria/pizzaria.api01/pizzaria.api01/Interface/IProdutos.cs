namespace pizzaria.api01.Interface
{
    public interface IProdutos<Produtos>
    {
        Task<IEnumerable<Produtos>> ListarProdutos();
        Task<Produtos> GetByIdProdutos(int id);
        Task<int> InserirProdutos(Produtos produtos);
        Task<bool> AlterarProdutos(Produtos produtos);
        Task<bool> ExcluirProdutos(int id);
    }
}
