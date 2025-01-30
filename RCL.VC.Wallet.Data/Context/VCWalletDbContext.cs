using Microsoft.EntityFrameworkCore;

namespace RCL.VC.Wallet.Data
{
    public class VCWalletDbContext : DbContext
    {
        public VCWalletDbContext()
        {
        }

        public VCWalletDbContext(DbContextOptions<VCWalletDbContext> options)
         : base(options)
        {
        }

        public virtual DbSet<Holder> Holders { get; set; }
        public virtual DbSet<HolderDID> HolderDIDs { get; set; }
    }
}
