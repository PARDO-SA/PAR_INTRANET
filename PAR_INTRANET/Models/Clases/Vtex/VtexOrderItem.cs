using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PAR_INTRANET.Models.Clases.Vtex
{
    [Table("VTexOrderItem")]
    public class VtexOrderItem
    {
        [Key, Column(Order = 0), ForeignKey("VtexOrder")]
        public int VTexOrderID { get; set; }
        [Key, Column(Order = 1)]
        public int NroSec { get; set; }
        public string CodArt { get; set; }
        public decimal CanArt { get; set; }
        public decimal PreArt { get; set; }
        public string CodArtVTex { get; set; }

        public virtual VtexOrder VtexOrder { get; set; }
    }
}