namespace GaragemApi.Dto
{
    public class GaragemDto
    {
        public int IdGaragem { get; set; }
        public int IdTipoEstadia { get; set; }
        public int IdCarro { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
        public int? NroVaga { get; set; }
    }
}
