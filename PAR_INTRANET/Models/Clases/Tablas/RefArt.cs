using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PAR_INTRANET.Models.Clases
{
    [Table("RefArt")]
    public class RefArt
    {
        [Key]
        public Byte CodRefArt { get; set; }

        [StringLength(30)]
        public string DesRefArt { get; set; }

        public ICollection<Marca> Marcas { get; set; }
    }
}