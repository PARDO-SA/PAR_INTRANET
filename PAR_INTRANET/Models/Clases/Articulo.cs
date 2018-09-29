using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PAR_INTRANET.Models.Clases
{
    [Table("Artic")]
    public class Articulo
    {
        [Key]
        [Display(Name = "Código")]
        public string CodArt { get; set; }

        [Display(Name = "Descripción")]
        public string DesArt { get; set; }

        [Display(Name = "Rubro")]
        [StringLength(3)]
        public string CodNivArt1Comi { get; set; }

        [Display(Name = "SubRubro")]
        [StringLength(3)]
        public string CodNivArt2Comi { get; set; }

        [ScaffoldColumn(false)]
        [StringLength(3)]
        public string CodNivArt3Comi { get; set; }

        [Display(Name = "Marca")]
        [StringLength(10)]
        public string MarcaComi { get; set; }

        [Display(Name = "Estado")]
        public bool Inactivo { get; set; }
    }
}