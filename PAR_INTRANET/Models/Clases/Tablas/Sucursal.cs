using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PAR_INTRANET.Models.Clases.Tablas
{
    [Table("Sucur")]
    public class Sucursal
    {
        [Key]
        [Display(Name = "Código")]
        [StringLength(3)]
        public string CodSuc { get; set; }

        [Display(Name = "Sucursal")]
        [StringLength(30)]
        public string Dessuc { get; set; }

        [Display(Name = "Estado")]
        public bool Inactivo { get; set; }
    }
}