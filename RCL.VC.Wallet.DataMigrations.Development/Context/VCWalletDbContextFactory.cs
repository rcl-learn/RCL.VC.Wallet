using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using RCL.VC.Wallet.Data;

namespace RCL.VC.Wallet.DataMigrations.Development
{
    public class VCWalletDbContextFactory: IDesignTimeDbContextFactory<VCWalletDbContext>
    {
        public VCWalletDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<VCWalletDbContext>();
            optionsBuilder.UseSqlServer(Environment.GetEnvironmentVariable("ConnectionStrings:Database"),
                sqlServerOptions => sqlServerOptions.MigrationsAssembly("RCL.VC.Wallet.DataMigrations.Development"));

            return new VCWalletDbContext(optionsBuilder.Options);
        }
    }
}
