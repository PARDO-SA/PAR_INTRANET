using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PAR_INTRANET.Models.Clases
{
    [Table("PAR_Emple")]
    public class Empleado
    {
        [Key]
        [Display(Name = "Legajo")]
        public int Legajo { get; set; }

        [Display(Name = "Email")]
        [StringLength(50)]
        public string Email { get; set; }

        [Display(Name = "Nombre")]
        [StringLength(50)]
        public string Nombre { get; set; }

        [Display(Name = "Cod. Vendedor")]
        [StringLength(4)]
        public string CodVen { get; set; }

        [ForeignKey("Sucursal")]
        [Display(Name = "Sucursal")]
        [StringLength(3)]
        public string CodSuc { get; set; }

        [ForeignKey("FuncionPri")]
        [Display(Name = "Función")]
        public int FuncionP { get; set; }

        [ForeignKey("FuncionSec")]
        [Display(Name = "Función Secundaria")]
        public int? FuncionS { get; set; }

        [Display(Name = "Estado")]
        public bool Inactivo { get; set; }

        public virtual Sucursal Sucursal { get; set; }
        public virtual FuncionEmple FuncionPri { get; set; }
        public virtual FuncionEmple FuncionSec { get; set; }

    }
}