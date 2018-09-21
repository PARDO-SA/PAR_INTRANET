using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PAR_INTRANET.Models.Clases
{
    [Table("PAR_Funciones")]
    public class FuncionComi
    {
        [Key]
        [Column(name:"id")]
        public int IdFuncion { get; set; }

        [StringLength(50)]
        public string DesFuncion { get; set; }

        [StringLength(100)]
        public string SpFuncion { get; set; }

        public bool Comisiones { get; set; }
    }
}