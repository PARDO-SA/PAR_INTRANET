using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using PAR_INTRANET.Models.Clases;
using PAR_INTRANET.Models.Clases.Tablas;

namespace PAR_INTRANET.Models.Contexto
{
    public class CentralDBContexto : DbContext
    {
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Sucursal> Sucursales { get; set; }
        public DbSet<FuncionEmple> Funciones { get; set; }

        public DbSet<Comision> Comisiones { get; set; }
        public DbSet<ComisionArticulo> ComisionesArticulos { get; set; }
        public DbSet<FuncionComi> FuncionesComisiones { get; set; }
        public DbSet<Marca> Marcas { get; set; }
        public DbSet<Rubro> Rubros { get; set; }
        public DbSet<SubRubro> SubRubros { get; set; }
    }
}