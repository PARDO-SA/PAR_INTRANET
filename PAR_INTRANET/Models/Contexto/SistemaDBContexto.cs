using PAR_INTRANET.Models.Login;
using System.Data.Entity;

namespace PAR_INTRANET.Models.Contexto
{
    public partial class SistemaDBContexto : DbContext
    {
        public SistemaDBContexto() : base("name=SistemaDBContexto") { }

        public DbSet<Usuario> Usuarios { get; set; }
    }

}