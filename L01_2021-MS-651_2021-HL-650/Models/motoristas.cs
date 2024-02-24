using System.ComponentModel.DataAnnotations;
namespace L01_2021_MS_651_2021_HL_650.Models
{
    public class motoristas
    {
        [Key]
        public int motoristasId { get; set; }
        public string nombreMotorista { get; set; }
    }
}
