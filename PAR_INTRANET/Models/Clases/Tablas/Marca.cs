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
        [Key, Column(Order = 0), ForeignKey("RefArt")]
        public Byte CodRefArt { get; set; }

        [Key, Column(Order = 1), Display(Name = "Código Marca"), StringLength(10)]
        public string CodeleRefArt { get; set; }

        [Display(Name="Descripción Marca"), StringLength(30)]
        public string DesEleRefArt { get; set; }

        public virtual RefArt RefArt { get; set; }
    }
}