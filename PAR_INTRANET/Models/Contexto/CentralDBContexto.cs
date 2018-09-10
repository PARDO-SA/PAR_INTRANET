using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using PAR_INTRANET.Models.Clases;

namespace PAR_INTRANET.Models.Contexto
{
    public class CentralDBContexto : DbContext
    {
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Sucursal> Sucursales { get; set; }
        public DbSet<FuncionEmple> Funciones { get; set; }
    }
}