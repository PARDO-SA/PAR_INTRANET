using PAR_INTRANET.Models.Clases.Tablas;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PAR_INTRANET.Models.Clases
{
    [Table("RefArtEle")]
    public class Marca
    {
        [Key, Column(Order =1), ForeignKey("RefArt")]
        public int CodRefArt { get; set;}

        [Key, Column(Order=2),Display(Name = "Código Marca"), StringLength(10)]
        public string CodEleRefArt { get; set; }

        [Display(Name = "Descripción Marca"), StringLength(30)]
        public string DesEleRefArt { get; set; }

        public virtual RefArt RefArt { get; set; }

        //public ICollection<Articulo> Articulo { get; set; }

    }
}