using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PAR_INTRANET.Models.Clases
{
    [Table("PAR_Comisiones")]
    [Serializable]
    public class Comision
    {
        public Comision()
        {
            Articulos = new HashSet<ComisionArticulo>();
        }

        [Key]
        [Display(Name = "Código")]
        public int IdComi { get; set; }

        [Display(Name = "Descripción")]
        [Required(ErrorMessage = "No puede quedar vacío.")]
        [StringLength(100)]
        public string DesComi { get; set; }

        [Display(Name = "Desde")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime FecVigDesComi { get; set; }

        [Display(Name = "Hasta")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime? FecVigHasComi { get; set; }

        [Column("CodNivArt1Comi")]
        [Display(Name = "Rubro")]
        [StringLength(3)]
        public string CodNivArt1 { get; set; }

        [Column("CodNivArt2Comi")]
        [Display(Name = "SubRubro")]
        [StringLength(3)]
        public string CodNivArt2 { get; set; }

        [Column("CodNivArt3Comi")]
        [ScaffoldColumn(false)]
        [StringLength(3)]
        public string CodNivArt3 { get; set; }

        [Column("CodRefArtComi")]
        [ScaffoldColumn(false)]
        public byte? CodRefArt { get; set; }

        [Column("MarcaComi")]
        [Display(Name = "Marca")]
        [StringLength(10)]
        public string CodEleRefArt { get; set; }

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

        public ICollection<ComisionArticulo> Articulos { get; set; }

        public virtual Rubro Nivel1 { get; set; }
        public virtual SubRubro Nivel2 { get; set; }
        public virtual RefArt RefArt { get; set; }
        public virtual Marca Marca { get; set; }
        public virtual FuncionComi FuncionComi { get; set; }
    }
}