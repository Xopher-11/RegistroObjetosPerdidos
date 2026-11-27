using System.ComponentModel.DataAnnotations;

namespace RegistroObjetosPerdidos.Models
{
    public class Reporte
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string NombreObjeto { get; set; } = string.Empty;

        [Required]
        [StringLength(500)]
        public string Descripcion { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string Tipo { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string Ubicacion { get; set; } = string.Empty;

        public DateTime FechaReporte { get; set; } = DateTime.Now;

        [Required]
        [StringLength(30)]
        public string Estado { get; set; } = "Pendiente";
    }
}