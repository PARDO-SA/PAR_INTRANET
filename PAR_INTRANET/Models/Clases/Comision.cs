﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PAR_INTRANET.Models.Clases
{
    [Table("PAR_Comisiones")]
    public class Comision
    {
        [Key]
        [Display(Name = "Código")]
        public int IdComi { get; set; }

        [Display(Name = "Descripción")]
        [Required(ErrorMessage = "No puede quedar vacío.")]
        [StringLength(100)]
        public string DesComi { get; set; }

        [Display(Name = "Desde")]
        public DateTime FecVigDesComi { get; set; }

        [Display(Name = "Hasta")]
        public DateTime? FecVigHasComi { get; set; }

        [Display(Name = "Rubro")]
        [StringLength(3)]
        public string CodNivArt1Comi { get; set; }

        [Display(Name = "SubRubro")]
        [StringLength(3)]
        public string CodNivArt2Comi { get; set; }

        [ScaffoldColumn(false)]
        [StringLength(3)]
        public string CodNivArt3Comi { get; set; }

        [Display(Name = "Marca")]
        [StringLength(10)]
        public string MarcaComi { get; set; }

        [Display(Name = "Incluye Artículos")]
        public bool ArtIncComi { get; set; }

        [Display(Name = "Excluye Artículos")]
        public bool ArtExcComi { get; set; }

        [Display(Name = "Vendedores")]
        public bool VendeComi { get; set; }

        [Display(Name = "Importe")]
        public decimal ImpComi { get; set; } 

        [Display(Name = "Porcentaje")]
        public decimal PorComi { get; set; }

        [Display(Name = "Resto de la Sucursal")]
        public bool RestoComi { get; set; }

        [Display(Name = "Importe")]
        public decimal ImpRestoComi { get; set; }

        [Display(Name = "Porcentaje")]
        public decimal PorRestoComi { get; set; }

        [Display(Name = "Estado")]
        public bool Inactivo { get; set; }

        [Display(Name = "Función")]
        public int IdFuncion { get; set; }

        public List<ComisionArticulo> ArticulosInc { get; set; }
        public List<ComisionArticulo> ArticulosExc { get; set; }

        public virtual Rubro Rubro { get; }
        public virtual SubRubro SubRubro { get; }
        public virtual Marca Marca { get; }
        public virtual FuncionComi FuncionComi { get; set; }
    }
}