using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PAR_INTRANET.Models.Clases
{
    [Table("PAR_Funciones")]
    public class FuncionComi
    {
        [Key]
        [Column(name: "id")]
        public int IdFuncion { get; set; }

        [StringLength(50)]
        public string DesFuncion { get; set; }

        [StringLength(100)]
        public string SpFuncion { get; set; }

        public bool Comisiones { get; set; }
    }
}