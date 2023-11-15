using GaragemApi.Context;
using GaragemApi.Dto;
using GaragemApi.Interface;
using GaragemApi.Models;
using Microsoft.EntityFrameworkCore;

namespace GaragemApi.Service
{
    public class CarroService: ICarro
    {
        private readonly IConfiguration _configuration;
        private readonly AppDbContext _context;

        public CarroService(IConfiguration configuration, AppDbContext context)
        {
            _configuration = configuration;
            _context = context;
        }

        public async Task<CarroModel> GetCarroPorId(int idCarro)
        {
            return await _context.Carro.FirstOrDefaultAsync(x => x.IdCarro == idCarro);
        }

        public async Task<bool> DeleteCarro(int idCarro)
        {
            var exists = await _context.Carro.FirstOrDefaultAsync(x => x.IdCarro == idCarro);
            if(exists != null)
            {
                exists.DataExclusao = DateTime.Now;
                await _context.SaveChangesAsync();
                return true;
            }
            else { return false; }
            
        }

        public async Task<bool> UpdateCarro(CarroDto carroDto)
        {
            var exists = await _context.Carro.FirstOrDefaultAsync(x => x.IdCarro == carroDto.IdCarro);
            if (exists != null)
            {

                exists.Modelo = carroDto.Modelo;
                exists.PlacaCarro = carroDto.PlacaCarro;
                exists.Cor = carroDto.Cor;
                exists.Ano = carroDto.Ano;
                exists.OutrasInformacoes = carroDto.OutrasInformacoes;
                exists.Padrao = carroDto.Padrao;
                exists.IdStatus = carroDto.IdStatus;
                exists.DataAtualizacao = carroDto.DataAtualizacao;
                exists.IdUsuarioAlteracao = carroDto.IdUsuarioAlteracao;
                exists.TipoDeVeiculo = carroDto.TipoDeVeiculo;
                await _context.SaveChangesAsync();
                return true;
            }
            else { return false; }

        }

        public async Task<int> CreateCarro(CarroModel newCarroModel)
        {
            _context.Add(newCarroModel);
            await _context.SaveChangesAsync();
            return newCarroModel.IdCarro;
        }
    }
}
