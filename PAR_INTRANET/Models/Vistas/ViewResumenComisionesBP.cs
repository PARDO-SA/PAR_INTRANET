using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PAR_INTRANET.Models.Vistas
{
    public class ViewResumenComisionesBP
    {
        [DisplayFormat(DataFormatString ="{0:0##}")]
        public int Sucursal { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        [DisplayFormat(DataFormatString = "{0:##,###,##0}")]
        public decimal Puntos { get; set; }
    }
}