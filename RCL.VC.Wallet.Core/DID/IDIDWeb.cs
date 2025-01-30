#nullable disable

namespace RCL.VC.Wallet.Core
{
    public interface IDIDWeb
    {
        public DIDDocument CreateDocument(string didWeb, ECJwk rsaJwk);
    }
}
