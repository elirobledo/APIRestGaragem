using GaragemApi.Context;
using GaragemApi.Dto;
using GaragemApi.Interface;
using GaragemApi.Models;
using GaragemApi.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.NetworkInformation;
using System.Runtime.ConstrainedExecution;
using System.Security.Claims;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GaragemApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarroController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ICarro _icarro;
        private readonly CarroService _carroService;

        public CarroController(IConfiguration configuration, ICarro icarro, CarroService carroService)
        {
            _configuration = configuration;
            _icarro = icarro;
            _carroService = carroService;
        }


        // GET api/<CarroController>/5
        [HttpGet("api/[controller]/{id}")]
        public ActionResult GetCarroPorId(int id)
        {
            try
            {
                var carro = _icarro.GetCarroPorId(id);
                return Ok(carro);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


        [HttpPost("api/[controller]/")]
        public async Task<IActionResult> CreateCarro(CarroDto carroDto)
        {
            try
            {
                var userId = HttpContext.User.FindFirst(ClaimTypes.Sid).Value;

                var result = await _carroService.CreateCarro(new CarroModel
                {
                    Modelo = carroDto.Modelo,
                    PlacaCarro = carroDto.PlacaCarro,
                    Cor = carroDto.Cor,
                    Ano = carroDto.Ano,
                    OutrasInformacoes = carroDto.OutrasInformacoes,
                    Padrao = carroDto.Padrao,
                    IdStatus = carroDto.IdStatus,
                    IdCarro = carroDto.IdCarro,
                    DataCadastro = DateTime.Now,
                    DataAtualizacao = null,
                    DataExclusao = null,
                    Ativo = true,
                    IdUsuarioCadastro = Convert.ToInt32(userId),
                    IdUsuarioAlteracao = null,
                    IdUsuarioExclusao = null,
                    TipoDeVeiculo = carroDto.TipoDeVeiculo
                });
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<CarroController>/5
        [HttpDelete("api/[controller]/{id}")]
        public async Task<IActionResult> DeleteCarro(int id)
        {
            try
            {
                var result = await _icarro.DeleteCarro(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //patch
        [HttpPatch("api/[controller]/{id}")]
        public async Task<IActionResult> UpdateCarro(int id, [FromBody] CarroDto carroDto)
        {
            try
            {
                carroDto.IdCarro = id;
                carroDto.DataAtualizacao = DateTime.Now;
                await _icarro.UpdateCarro(carroDto);
                return Ok(carroDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        //POST


    }
}
