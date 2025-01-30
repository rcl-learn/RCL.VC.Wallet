using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace RCL.VC.Wallet.Core
{
    public static class VCWalletExtension
    {
        public static IServiceCollection AddRCLLearnVCWalletServices(this IServiceCollection services)
        {
            services.TryAddTransient<IHolderService, HolderService>();
            services.TryAddTransient<IEC256OperatorService, EC256OperatorService>();
            services.TryAddTransient<IDIDJwkService, DIDJwkService>();
            return services;
        }
    }
}
