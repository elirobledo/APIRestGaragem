namespace GaragemApi.Dto
{
    public class CarroDto
    {
        public string? Modelo { get; set; }
        public string PlacaCarro { get; set; }
        public string? Cor { get; set; }
        public string? Ano { get; set; }
        public string? OutrasInformacoes { get; set; }
        public bool Padrao { get; set; }
        public int? IdStatus { get; set; }
        public int IdCarro { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime? DataAtualizacao { get; set; }
        public DateTime? DataExclusao { get; set; }
        public bool Ativo { get; set; }
        public int? IdUsuarioCadastro { get; set; }
        public int? IdUsuarioAlteracao { get; set; }
        public int? IdUsuarioExclusao { get; set; }
        public int? TipoDeVeiculo { get; set; }
    }
}
