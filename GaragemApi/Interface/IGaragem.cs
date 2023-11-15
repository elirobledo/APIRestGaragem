using GaragemApi.Dto;
using GaragemApi.Models;

namespace GaragemApi.Interface
{
    public interface IGaragem
    {
        Task<IEnumerable<GaragemModel>> GetGaragem();
        Task<bool> DeleteGaragem(int idGaragem);
        Task<int> CreateGaragem(GaragemModel newGaragemModel);
    }
}
