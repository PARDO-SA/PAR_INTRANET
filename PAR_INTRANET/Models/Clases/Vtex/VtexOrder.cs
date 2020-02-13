using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PAR_INTRANET.Models.Clases.Vtex
{
    [Table("VTexOrder")]
    public partial class VtexOrder
    {
        public VtexOrder()
        {
            Items = new HashSet<VtexOrderItem>();
        }
        [Key]
        public int VTexOrderId { get; set; }
        public string OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public Int16 CodTipDoc { get; set; }
        [StringLength(10)]
        public string DocumentType { get; set; }
        [StringLength(15)]
        public string NroDocCli { get; set; }
        [StringLength(50)]
        public string NomCli { get; set; }
        [StringLength(50)]
        public string NomCliWeb { get; set; }
        [StringLength(50)]
        public string DomCli { get; set; }
        [StringLength(50)]
        public string DomCliEnv { get; set; }
        [StringLength(10)]
        public string IVASujeto { get; set; }
        [StringLength(50)]
        public string Email { get; set; }
        [StringLength(5)]
        public string CodLocCli { get; set; }
        [StringLength(8)]
        public string CodPosCli { get; set; }
        [StringLength(20)]
        public string Tel1Cli { get; set; }
        [StringLength(8)]
        public string CodPosEnv { get; set; }
        [StringLength(5)]
        public string CodLocEnv { get; set; }
        public decimal ImpTotCbt { get; set; }
        public decimal ImpTotFle { get; set; }
        [StringLength(10)]
        public string CourierID { get; set; }
        [StringLength(50)]
        public string CourierName { get; set; }
        [StringLength(3)]
        public string CodSuc { get; set; }
        [StringLength(4)]
        public string CodAlm { get; set; }
        public DateTime DownloadDate { get; set; }
        public string Json { get; set; }
        [StringLength(40)]
        public string CSIDNotVen { get; set; }
        [StringLength(40)]
        public string CSIDVta { get; set; }
        [StringLength(20)]
        public string Status { get; set; }
        [StringLength(1)]
        public string InvoiceNotificationStatus { get; set; }
        public DateTime? InvoiceNotificationDate { get; set; }
        public string TrackingUrl { get; set; }
        [StringLength(50)]
        public string DesLocCli { get; set; }
        [StringLength(50)]
        public string DesProvCli { get; set; }
        [StringLength(50)]
        public string DesLocEnv { get; set; }
        [StringLength(50)]
        public string DesProvEnv { get; set; }


        public ICollection<VtexOrderItem> Items { get; set; }
    }
}