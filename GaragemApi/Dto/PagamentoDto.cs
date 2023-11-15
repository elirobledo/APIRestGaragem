using System.ComponentModel.DataAnnotations;

namespace GaragemApi.Dto
{
    public class PagamentoDto
    {
        public int IdPagamento { get; set; }
        public decimal? ValorEntrada { get; set; }
        public decimal? ValorSaida { get; set; }
        public decimal? ValorMensal { get; set; }
        public int IdCarro { get; set; }
        public decimal? ValorTotal { get; set; }
        public int IdTipoEstadia { get; set; }
    }
}
