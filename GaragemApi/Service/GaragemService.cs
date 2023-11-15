using GaragemApi.Context;
using GaragemApi.Dto;
using GaragemApi.Interface;
using GaragemApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace GaragemApi.Service
{
    public class GaragemService : IGaragem
    {
        private readonly IConfiguration _configuration;
        private readonly AppDbContext _context;

        public GaragemService(IConfiguration configuration, AppDbContext context)
        {
            _configuration = configuration;
            _context = context;
        }

       
        public async Task<IEnumerable<GaragemModel>> GetGaragem()
        {
            return await _context.Garagem.ToListAsync();
        }
        public async Task<bool> DeleteGaragem(int idGaragem)
        {
            var exists = await _context.Garagem.FirstOrDefaultAsync(x => x.IdGaragem == idGaragem);
            if (exists != null)
            {
                await _context.SaveChangesAsync();
                return true;
            }
            else { return false; }
        }
        public  async Task<int> CreateGaragem(GaragemModel newGaragemModel)
        {
            _context.Add(newGaragemModel);
            await _context.SaveChangesAsync();
            return newGaragemModel.IdGaragem;
        }
    }
}
