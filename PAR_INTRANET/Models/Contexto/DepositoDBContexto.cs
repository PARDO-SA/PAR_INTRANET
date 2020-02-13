using PAR_INTRANET.Models.Clases.Vtex;
using System.Data.Entity;

namespace PAR_INTRANET.Models.Contexto
{
    public partial class DepositoDBContexto : DbContext
    {
        public DepositoDBContexto() : base("name=DepositoDBContexto") { }

        public virtual DbSet<VtexOrder> VtexOrders { get; set; }

        public virtual DbSet<VtexOrderItem> VtexOrderItems { get; set; }
    }
}