using GaragemApi.Dto;
using GaragemApi.Interface;
using GaragemApi.Models;
using GaragemApi.Service;
using Microsoft.AspNetCore.Mvc;

namespace GaragemApi.Controllers
{
    public class GaragemController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IGaragem _garagem;
        private readonly GaragemService _garagemService;

        public GaragemController(IConfiguration configuration, IGaragem garagem, GaragemService garagemService)
        {
            _configuration = configuration;
            _garagem = garagem;
            _garagemService = garagemService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("api/[controller]/")]
        public async Task<IActionResult> CreateGaragem([FromBody] GaragemDto garagemDto)
        {
            try
            {
                var result = await _garagemService.CreateGaragem(new GaragemModel
                {
                    IdGaragem = garagemDto.IdGaragem,
                    IdTipoEstadia = garagemDto.IdTipoEstadia,
                    IdCarro = garagemDto.IdCarro,
                    DataInicio = DateTime.Now,
                    NroVaga = garagemDto.NroVaga
                });
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
