using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PAR_INTRANET.Models.Clases.Tablas
{
    [Table("Sucur")]
    public class Sucursal
    {
        [Key]
        [Display(Name = "Código")]
        [StringLength(3)]
        public string CodSuc { get; set; }

        [Display(Name = "Sucursal")]
        [StringLength(30)]
        public string Dessuc { get; set; }

        [Display(Name = "Servidor BD")]
        [StringLength(30)]
        public string Srvdbsuc { get; set; }

        [Display(Name = "Nombre BD")]
        [StringLength(30)]
        public string Nomdbsuc { get; set; }

        [Display(Name = "Usuario BD")]
        [StringLength(30)]
        public string Userdbsuc { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Password Usuario BD")]
        [StringLength(30)]
        public string Passdbsuc { get; set; }

        [Display(Name = "Estado")]
        public bool Inactivo { get; set; }
    }
}