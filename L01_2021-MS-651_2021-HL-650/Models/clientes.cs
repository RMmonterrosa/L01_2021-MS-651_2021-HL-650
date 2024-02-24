using System.ComponentModel.DataAnnotations;
namespace L01_2021_MS_651_2021_HL_650.Models
{
    public class clientes
    {
        [Key]
        public int clienteId { get; set; }
        public string nombreCliente { get; set; }
        public string direccion {  get; set; }
    }
}
