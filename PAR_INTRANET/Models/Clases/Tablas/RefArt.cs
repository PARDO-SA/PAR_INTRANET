using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PAR_INTRANET.Models.Clases
{
    [Table("RefArt")]
    public class RefArt
    {
        [Key]
        public int CodRefArt { get; set; }

        [StringLength(30)]
        public string DesRefArt { get; set; }

        public ICollection<Marca> Marcas { get; set; }
    }
}