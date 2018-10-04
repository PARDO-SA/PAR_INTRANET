using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PAR_INTRANET.Models.Clases
{
    [Table("NivArt1")]
    public class Rubro
    {
        [Key]
        [StringLength(3)]
        public string CodNivArt1 { get; set; }

        [StringLength(30)]
        public string DesNivArt1 { get; set; }

        public bool Inactivo { get; set; }
    }
}