using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PAR_INTRANET.Models.Clases.Tablas
{
    [Table("PAR_TxSuc")]
    public class EstadoSucursal
    {
        [Key]
        [Column("id_txsuc")]
        [Display(Name = "Código")]
        [StringLength(3)]
        public string CodSuc { get; set; }

        [Column("fecultact_txsuc")]
        [Display(Name = "Ultima Act. TX Suc.")]
        public DateTime? TXUltimaActualizacion { get; set; }

        [Column("fecultcon_txsuc")]
        [Display(Name = "Ultima Cons. TX Suc.")]
        public DateTime? TXUltimaConsulta { get; set; }

        [Column("resultado_txsuc")]
        [Display(Name = "Estado Transmisiones")]
        public string TXEstado { get; set; }

        [Column("error_txsuc")]
        [Display(Name = "Estado Ult. Cons. TX Suc.")]
        [StringLength(300)]
        public string TXError { get; set; }

        [Column("fecultact_txcen")]
        [Display(Name = "Ultima Act. TX Central")]
        public DateTime? TXUltimaActualizacionCentral { get; set; }

        [Column("fecultcon_txcen")]
        [Display(Name = "Ultima Cons. TX Central")]
        public DateTime? TXUltimaConsultaCentral { get; set; }

        [Column("resultado_txcen")]
        [Display(Name = "Estado TX Central")]
        public string TXEstadoCentral { get; set; }

        [Column("fecultpadron")]
        [Display(Name = "Ultima actualización Padrón IBBA")]
        public DateTime? IBBAUltimaActualizacion { get; set; }

        [Column("fecultcon_padronsuc")]
        [Display(Name = "Ultima consulta Padrón IBBA")]
        public DateTime? IBBAUltimaConsulta { get; set; }

        [Column("error_padronsuc")]
        [Display(Name = "Estado Ultima Consulta Padrón IBBA")]
        [StringLength(300)]
        public string IBBAError { get; set; }

        //public virtual Sucursal Sucursal { get; set; }
    }
}