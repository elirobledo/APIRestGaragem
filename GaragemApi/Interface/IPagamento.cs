using GaragemApi.Models;

namespace GaragemApi.Interface
{
    public interface IPagamento
    {
        Task<IEnumerable<PagamentoModel>> GetPagamento();
        Task<bool> DeletePagamento(int idPagamento);
        Task<int> CreatePagamento(PagamentoModel newPagamentoModel);
    }
}
