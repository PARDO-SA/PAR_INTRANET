using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PAR_INTRANET.Models.Clases
{
    [Table("RefArtEle")]
    public class Marca
    {
        [Key]
        [Column(Order = 0)]
        public char CodRefArt { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(10)]
        public string CodEleRefArt { get; set; }

        [StringLength(30)]
        public string DesEleRefArt { get; set; }
    }
}