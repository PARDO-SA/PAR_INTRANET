using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PAR_INTRANET.Models.Clases.Tablas
{
    [Table("PAR_FuncionEmple")]
    public class FuncionEmple
    {
        [Key]
        [Display(Name = "Código")]
        public int Id { get; set; }

        [Display(Name = "Función")]
        [StringLength(30)]
        public string Descripcion { get; set; }
    }
}