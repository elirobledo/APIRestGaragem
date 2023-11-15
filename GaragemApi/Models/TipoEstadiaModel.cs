using System.ComponentModel.DataAnnotations;

namespace GaragemApi.Models
{
    public class TipoEstadiaModel
    {
        [Key]
        public int IdTipoEstadia { get; set; }
        public string TipoEstadia { get; set; }
    }
}
