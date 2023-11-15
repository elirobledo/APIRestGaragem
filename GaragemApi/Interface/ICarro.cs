using GaragemApi.Dto;
using GaragemApi.Models;

namespace GaragemApi.Interface
{
    public interface ICarro
    {
        Task<CarroModel> GetCarroPorId(int idCarro);
        Task<bool> DeleteCarro(int idCarro);
        Task<bool> UpdateCarro(CarroDto carroDto);
    }
}