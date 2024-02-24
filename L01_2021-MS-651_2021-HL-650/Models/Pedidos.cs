using System.ComponentModel.DataAnnotations;

namespace L01_2021_MS_651_2021_HL_650.Models
{
    public class Pedidos
    {

        [Key]
        public int pedidoId { get; set; }
        public int motoristaId { get; set; }
        public int clienteId { get; set; }
        public int platoId { get; set; }
        public int? cantidad { get; set; } 
        public decimal? precio { get; set; }

    }
}
