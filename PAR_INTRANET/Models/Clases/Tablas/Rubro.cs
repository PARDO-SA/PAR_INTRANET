using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PAR_INTRANET.Models.Clases
{
    [Table("NivArt1")]
    public class Rubro
    {
        [Key, Display(Name = "Código Rubro"), StringLength(3)]
        public string CodNivArt1 { get; set; }

        [Display(Name = "Descripción Rubro"), StringLength(30)]
        public string DesNivArt1 { get; set; }

        public bool Inactivo { get; set; }

        public ICollection<SubRubro> SubRubros { get; set; }
    }
}