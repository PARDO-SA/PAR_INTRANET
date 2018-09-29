using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PAR_INTRANET.Models.Clases
{
    [Table("PAR_ComisionesBP")]
    public class ComisionesBP
    {
        [Key, Column(Order = 0)]
        [Display(Name = "Sucursal"), StringLength (3)]
        public string CodSuc { get; set; }

        [Key, Column(Order = 1)]
        [Display(Name = "Código Vendedor"), StringLength(4)]
        public string CodVen { get; set; }

        [Column(Order = 2)]
        [Display(Name = "Vendedor"), StringLength(30)]
        public string Vendedor { get; set; }

        [Key]
        [Column(Order = 3)]
        [Display(Name = "Recibo")]
        [Required, StringLength(16)]
        public string Recibo { get; set; }

        [Column(Order = 4)]
        [Display(Name = "Fecha Recibo")]
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        public DateTime FechaRec { get; set; }

        [Key]
        [Column(Order = 5)]
        [Display(Name = "Comprobante"), StringLength(16)]
        public string Comprobante { get; set; }

        [Key]
        [Column(Order = 6)]
        [Display(Name = "Cuota"), Range(0,99)]
        public int Cuota { get; set; }

        [Column(Order = 7)]
        [Display(Name = "Importe Recibo")]
        public decimal ImporteRec { get; set; }

        [Column(Order = 8)]
        [Display(Name = "Cliente")]
        public int CodCli { get; set; }

        [Key]
        [Column(Order = 9)]
        [Display(Name = "Artículo"), StringLength(20)]
        public string CodArt { get; set; }

        [Column(Order = 10)]
        [Display(Name ="Descripción"), StringLength(50)]
        public string DesArt { get; set; }

        [Column(Order = 11)]
        [Display(Name ="Porcentaje Art."), Range(0,100)]
        public decimal Porcentaje { get; set; }

        [Column(Order = 12)]
        [Display(Name ="Importe Art.")]
        public decimal ImporteArt { get; set; }

        [Column(Order = 13)]
        [Display(Name ="Comisión Vendedor")]
        public decimal ComisionVen { get; set; }

        [Column(Order = 14)]
        [Display(Name ="Comisión Resto Suc.")]
        public decimal ComisionSuc { get; set; }

        [Column(Order = 15)]
        [Display(Name ="Período"), StringLength(6)]
        public string Periodo { get; set; }
    }
}