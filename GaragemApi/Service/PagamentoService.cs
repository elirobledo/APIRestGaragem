using GaragemApi.Context;
using GaragemApi.Interface;
using GaragemApi.Models;
using Microsoft.EntityFrameworkCore;

namespace GaragemApi.Service
{
    public class PagamentoService : IPagamento
    {
        private readonly IConfiguration _configuration;
        private readonly AppDbContext _context;

        public PagamentoService(IConfiguration configuration, AppDbContext context)
        {
            _configuration = configuration;
            _context = context;
        }


        public async Task<IEnumerable<PagamentoModel>> GetPagamento()
        {
            return await _context.Pagamento.ToListAsync();
        }
        public async Task<bool> DeletePagamento(int idPagamento)
        {
            var exists = await _context.Pagamento.FirstOrDefaultAsync(x => x.IdPagamento == idPagamento);
            if (exists != null)
            {
                await _context.SaveChangesAsync();
                return true;
            }
            else { return false; }
        }
        public async Task<int> CreatePagamento(PagamentoModel newPagamentoModel)
        {
            _context.Add(newPagamentoModel);
            await _context.SaveChangesAsync();
            return newPagamentoModel.IdPagamento;
        }
    }
}
