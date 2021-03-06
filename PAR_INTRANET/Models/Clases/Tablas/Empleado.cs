﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PAR_INTRANET.Models.Clases.Tablas
{
    [Table("PAR_EMPLE")]
    public class Empleado
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required]
        [Display(Name = "Legajo")]
        public int Legajo { get; set; }

        [Required] 
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Nombre")]
        [StringLength(50)]
        public string Nombre { get; set; }

        [Display(Name = "Cod. Vendedor")]
        [StringLength(4)]
        [CodVenEmpleValidator("FuncionP","FuncionS", ErrorMessage = "Se debe ingresar un valor, ya que una de sus funciones es Vendedor")]
        public string CodVen { get; set; }

        [Required]
        [Display(Name = "Cuil")]
        public long Cuil { get; set; }

        [Required]
        [ForeignKey("Sucursal")]
        [Display(Name = "Sucursal")]
        [StringLength(3)]
        public string CodSuc { get; set; }

        [Required]
        [ForeignKey("FuncionPri")]
        [Display(Name = "Función")]
        [FuncionEmpleValidator(OtraFuncion = "FuncionS", ErrorMessage = "No puede ser la misma Funcion")]
        public int FuncionP { get; set; }

        [ForeignKey("FuncionSec")]
        [Display(Name = "Función Secundaria")]
        [FuncionEmpleValidator(OtraFuncion = "FuncionP", ErrorMessage = "No puede ser la misma Funcion")]
        public int? FuncionS { get; set; }

        [Display(Name = "Estado")]
        public bool Inactivo { get; set; }

        public virtual Sucursal Sucursal { get; set; }
        public virtual FuncionEmple FuncionPri { get; set; }
        public virtual FuncionEmple FuncionSec { get; set; }
    }
}