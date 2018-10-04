using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PAR_INTRANET.Models.Clases
{
    [Table("PAR_Comisiones_Articulos")]
    public class ComisionArticulo
    {
        [Key]
        [Column(Order=0)]
        public int IdComi { get; set; }

        [Key]
        [Column(Order=1)]
        [StringLength(20)]
        [ForeignKey("Articulo")]
        public string CodArtComi { get; set; }

        [RegularExpression("EIei")]
        [StringLength(1)]
        public string Tipo { get; set; }

        public virtual Articulo Articulo { get; set; }
    }
}