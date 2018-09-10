using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using PAR_INTRANET.Models.Login;

namespace PAR_INTRANET.Models.Contexto
{
    public class SistemaDBContexto : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
    }
    
}