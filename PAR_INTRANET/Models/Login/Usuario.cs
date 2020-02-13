using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PAR_INTRANET.Models.Login
{
    [Table("SISUsuar")]
    public class Usuario
    {
        [Key]
        [Display(Name = "Usuario")]
        public string CodUsr { get; set; }
        [Display(Name = "Nombre")]
        public string NomUsr { get; set; }
        [Display(Name = "Administrador")]
        public string AdmUsr { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string PwdUsr { get; set; }
        [Display(Name = "Vencimiento Pwd")]
        public DateTime VtoPwdUsr { get; set; }
        [Display(Name = "Inactivo")]
        public Boolean Inactivo { get; set; }
        [Column("codgrp")]
        [Display(Name = "Grupo")]
        public string Grupo { get; set; }
    }
}
