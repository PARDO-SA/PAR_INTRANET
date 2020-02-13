using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PAR_INTRANET.Models.Clases
{
    [Table("NivArt2")]
    public class SubRubro
    {
        [Key, Display(Name = "Código Rubro"), Column(Order = 1), ForeignKey("Rubro"), StringLength(3)]
        public string CodNivArt1 { get; set; }

        [Key, Display(Name = "Código SubRubro"), Column(Order = 2), StringLength(3)]
        public string CodNivArt2 { get; set; }

        [Display(Name = "Descripción SubRubro"), StringLength(30)]
        public string DesNivArt2 { get; set; }

        public bool Inactivo { get; set; }

        public virtual Rubro Rubro { get; set; }
    }
}