using GaragemApi.Interface;
using GaragemApi.Service;
using Microsoft.AspNetCore.Mvc;

namespace GaragemApi.Controllers
{
    public class PagamentoController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IPagamento _ipagamento;
        private readonly PagamentoService _pagamentoService;

        public PagamentoController(IConfiguration configuration, IPagamento ipagamento, PagamentoService pagamentoService)
        {
            _configuration = configuration;
            _ipagamento = ipagamento;
            _pagamentoService = pagamentoService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
