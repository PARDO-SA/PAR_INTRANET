using PAR_INTRANET.Models.Clases;
using PAR_INTRANET.Models.Clases.Tablas;
using System.Data.Entity;

namespace PAR_INTRANET.Models.Contexto
{
    public partial class CentralDBContexto : DbContext
    {
        public CentralDBContexto() : base("name=CentralDBContexto") { }

        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Sucursal> Sucursales { get; set; }
        public DbSet<FuncionEmple> Funciones { get; set; }
        public DbSet<Comision> Comisiones { get; set; }
        public DbSet<ComisionArticulo> ComisionesArticulos { get; set; }
        public DbSet<FuncionComi> FuncionesComisiones { get; set; }
        public DbSet<RefArt> RefArts { get; set; }
        public DbSet<Marca> Marcas { get; set; }
        public DbSet<Rubro> Rubros { get; set; }
        public DbSet<SubRubro> SubRubros { get; set; }
        public DbSet<EstadoSucursal> EstadoSucursales { get; set; }
        public DbSet<Articulo> Articulos { get; set; }

        protected override void OnModelCreating(System.Data.Entity.DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Articulo>()
            //    .HasRequired(a => a.Marca)
            //    .WithMany()
            //    .HasForeignKey(m => new { m.CodRefArt, m.CodEleRefArt });
            //modelBuilder.Entity<Articulo>().Ignore(a => a.CodRefArt);
            //base.OnModelCreating(modelBuilder);
        }
    }
}