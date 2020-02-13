using PAR_INTRANET.Models.Clases.Tablas;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PAR_INTRANET.Models.Clases
{
    [Table("PAR_Comisiones_Articulos")]
    public class ComisionArticulo
    {
        [Key, Column(Order = 0), ForeignKey("Comision")]
        public int IdComi { get; set; }
        [Key, Column("CodArtComi", Order = 1)]
        [StringLength(20)]
        public string CodArt { get; set; }
        [Key, Column(Order = 2)]
        [StringLength(1)]
        public string Tipo { get; set; }
        public virtual Comision Comision { get; set; }
        public virtual Articulo Articulo { get; set; }

    }
}