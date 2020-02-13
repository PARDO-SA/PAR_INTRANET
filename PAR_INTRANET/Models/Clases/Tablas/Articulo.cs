using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PAR_INTRANET.Models.Clases.Tablas
{
    [Table("Artic")]
    public class Articulo
    {
        [Key]
        [Display(Name="Código")]
        public string CodArt { get; set; }
        [Display(Name ="Descripción")]
        public string DesArt { get; set; }
        [Display(Name ="Rubro")]
        public string CodNivArt1 { get; set; }
        [Display(Name ="SubRubro")]
        public string CodNivArt2 { get; set; }
        [NotMapped]
        public int CodRefArt { get { return 1; } set { CodRefArt = 1; } }
        [Display(Name ="Marca"), Column("CodEleRefArt1")]
        public string CodEleRefArt { get; set; }

        public virtual Rubro Nivel1 { get; set; }
        public virtual SubRubro Nivel2 { get; set; }
        public virtual RefArt RefArt { get; set; }
        public virtual Marca Marca { get; set; }
    }
}