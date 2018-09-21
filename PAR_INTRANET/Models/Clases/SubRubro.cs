using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PAR_INTRANET.Models.Clases
{
    [Table("NivArt2")]
    public class SubRubro
    {
        [Key]
        [Column(Order =0)]
        [StringLength(3)]
        public string CodNivArt1 { get; set; }

        [Key]
        [Column(Order =1)]
        [StringLength(3)]
        public string CodNivArt2 { get; set; }

        [StringLength(30)]
        public string DesNivArt1 { get; set; }

        public bool Inactivo { get; }
    }
}